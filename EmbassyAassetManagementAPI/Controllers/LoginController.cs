using EmbassyAassetManagementAPI.Models;
using EmbassyAassetManagementAPI.Models.DTO;
using EmbassyAassetManagementAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using EmbassyAassetManagementAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmbassyAassetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly EmbassyAssetManagementContext _context;
        public readonly IConfiguration _configuration;
        public LoginController(EmbassyAssetManagementContext context, IConfiguration config)
        {
            this._context = context;
            _configuration = config;
        }


       
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest _userData)
        {
            try
            {
                if (_userData.mobno == null)
                    return BadRequest(new { Error = "Invalid request data. Mob No. and Password/OTP are required." });

                string encryptedMob = _userData.mobno;
                int? encryptedOTP = _userData.otp;
                string passdata = _userData.Password;

                var userr = await _context.TblUserMasters.AsNoTracking().ToListAsync();

                if (string.IsNullOrEmpty(passdata) && encryptedOTP == null)
                {
                   
                    return BadRequest("Either Mobile number or OTP/Password is required.");
                }

                string encryptedPassword = Password.Encrypt(_userData.Password);

                var user = await GetUser(encryptedMob, encryptedPassword, encryptedOTP);
                if (user == null)
                    return Unauthorized(new { Error = "Invalid credentials." });
                var pass = user.Password;
                // 🔍 Fetch only roles assigned to the user
                var roles = await (from ur in _context.TblUserRoles
                                   join rm in _context.TblRoleMasters on ur.RoleId equals rm.RoleId
                                   where ur.UserId == user.UserId && ur.IsActive == true && rm.IsActive == true
                                   select new
                                   {
                                       rm.RoleId,
                                       rm.RoleName
                                   }).ToListAsync();


                if (!roles.Any())
                    return Unauthorized(new { Error = "User does not have any role assigned." });

                // ✅ Create claims — use all assigned roles
                var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
            new Claim("UserId", user.UserId.ToString()),
            new Claim(ClaimTypes.Name, user.Username ?? "")
        };

                // 👉 Add all roles as individual claims
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                    claims.Add(new Claim("RoleId", role.RoleId.ToString())); // optional: if needed in token
                }

                // 🔐 Create token
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: creds
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                // ✅ Save Token to DB (optional)
                user.Token = tokenString;
                user.Password = pass;
                _context.TblUserMasters.Update(user);
                await _context.SaveChangesAsync();

                var candidateid = await _context.TblUserMasters.AsNoTracking().
                    Where(x=> x.MobileNo==_userData.mobno).
                    Select(x => x.Candidateid).FirstOrDefaultAsync();
           


                var response = new UsaerInformation
                {
                    UserId = user.UserId,
                    Username = user.Username,
                    Name = user.Name,
                    MobileNo = user.MobileNo,
                    salesmanid = user.Salesmanid,
                    EmailId = user.EmailId,
                    Address = user.Address,
                    IsActive = user.IsActive,
                    Candidateid = candidateid ,
                    Token = tokenString,
                    RoleId = roles.Select(x => x.RoleId).FirstOrDefault(),
                    RoleName = roles.Select(x => x.RoleName).FirstOrDefault()
                    
                }; 

                return Ok(response);


            }
            catch (Exception ex)
            {
                var errorMessage = ex.InnerException?.Message ?? ex.Message;
                return StatusCode(500, new { Error = "An internal error occurred.", Details = errorMessage });
            }
        }


        [Authorize]
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                // 🔐 Get UserId from claims
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
                if (userIdClaim == null)
                    return Unauthorized(new { Error = "Invalid token." });

                var userId = Convert.ToInt32(userIdClaim.Value);

                // 🔍 Find user
                var user = await _context.TblUserMasters.FindAsync(userId);
                if (user == null)
                    return NotFound(new { Error = "User not found." });

                // ❌ Invalidate the token
                user.Token = null;

                _context.TblUserMasters.Update(user);
                await _context.SaveChangesAsync();

                return Ok(new { Message = "Logged out successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "An internal error occurred.", Details = ex.Message });
            }
        }

        [HttpPost("UserRegistration")]
        public async Task<ActionResult<TblUserMaster>> UserRegistration(TblUserMaster typechalan)
        {
            try
            {
                if (_context.TblUserMasters == null)
                {
                    return Problem("Entity set 'EmbassyAssetManagementContext.TblPoliceRegistrations' is null.");
                }

                bool userMasterExists = await _context.TblUserMasters.AnyAsync(e => e.Username.ToLower() == typechalan.Username.ToLower());

                if (userMasterExists)
                {
                    string ConflictMsg = "Username already exists.";
                    return Ok(new { Success = true, Message = ConflictMsg });
                }

                int maxId = _context.TblUserMasters.Any() ? _context.TblUserMasters.Max(e => e.UserId) : 0;
                int max = maxId + 1;
                typechalan.UserId = max;
                typechalan.Password = Password.Encrypt(typechalan.Password);
                typechalan.IsActive = true;
                typechalan.CreatedDate = DateTime.Now;
                typechalan.UpdatedBy = "NA";
                typechalan.UpdatedDate = DateTime.Now;
                _context.TblUserMasters.Add(typechalan);
                await _context.SaveChangesAsync();

                string successMessage = "User Created Successfully with UserId: " + typechalan.Username;
                return Ok(new { Success = true, Message = successMessage });
            }
            catch (Exception ex)
            {
                string error = "{\"Status\":\"" + ex.InnerException?.Message?.Replace('"', ' ').Trim() + "\"}";
                return StatusCode(500, error);
            }
        }

        private async Task<TblUserMaster?> GetUser(
    string uid,
    string? encryptedPassword,
    int? encryptedOTP)
        {
            if (string.IsNullOrWhiteSpace(uid))
                return null;

            try
            {
                uid = uid.Trim();

                IQueryable<TblUserMaster> query = _context.TblUserMasters
                    .Where(u => (u.MobileNo == uid || u.Username == uid) && u.IsActive== true);

                if (encryptedOTP.HasValue)
                {
                    query = query.Where(u => u.Otp == encryptedOTP.Value);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(encryptedPassword))
                        return null;

                    query = query.Where(u => u.Password == encryptedPassword);
                }

                return await query.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // Ideally use a logger instead of Console
                Console.Error.WriteLine($"GetUser failed: {ex}");

                return null;
            }
        }

        //    private async Task<TblUserMaster?> GetUser(string uid, string? encryptedPassword,int? encryptedOTP)
        //    {
        //        if (string.IsNullOrWhiteSpace(uid) )
        //        {
        //            return null;
        //        }
        //        try
        //        {
        //            if (encryptedOTP != null )
        //            {
        //                var user = await _context.TblUserMasters.FirstOrDefaultAsync(u => (u.MobileNo == uid || u.Username == uid) && u.Otp == encryptedOTP && u.IsActive == true);


        //                return user;
        //            }
        //            else
        //            {
        //                var user = await _context.TblUserMasters.FirstOrDefaultAsync(u => (u.MobileNo == uid || u.Username == uid) && u.Password == encryptedPassword && u.IsActive == true);

        //                return user;
        //            }



        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"An error occurred: {ex.Message}");
        //            return null;
        //        }
        //    }
    }
}
