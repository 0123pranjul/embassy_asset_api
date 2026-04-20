using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmbassyAassetManagementAPI.Models;
using EmbassyAassetManagementAPI.Service;
using EmbassyAassetManagementAPI.Models;

namespace EmbassyAassetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TblUserMastersController : ControllerBase
    {
        private readonly EmbassyAssetManagementContext _context;
        private readonly IConfiguration configuration;

        public TblUserMastersController(EmbassyAssetManagementContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }

        [HttpGet("GetTblUserMasters")]
        public async Task<ActionResult<IEnumerable<TblUserMaster>>> GetTblUserMasters()
        {
            try
            {
                if (_context.TblUserMasters == null)
                {
                    return NotFound();
                }
                return await _context.TblUserMasters.Where(x => x.IsActive == true).OrderByDescending(x => x.UserId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("GetTblUserMaster")]
        public async Task<ActionResult<TblUserMaster>> GetTblUserMaster(int id)
        {
            try
            {
                if (_context.TblUserMasters == null)
                {
                    return NotFound();
                }
                var tblChallanSubCategory = await _context.TblUserMasters.FirstOrDefaultAsync(x => x.UserId == id);

                if (tblChallanSubCategory == null)
                {
                    return NotFound();
                }
                return tblChallanSubCategory;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        [HttpPost("PutTblUserMaster")]
        public async Task<IActionResult> PutTblUserMaster( int UserId , TblUserMaster typemaster)
        {

            try
            {
                var chk = await _context.TblUserMasters.FirstOrDefaultAsync(x => x.UserId == typemaster.UserId);
                if (chk != null)
                {
                    chk.Username = typemaster.Username;
                    chk.UpdatedDate = DateTime.Now;
                    chk.CreatedBy = typemaster.CreatedBy;
                    chk.UpdatedBy = typemaster.UpdatedBy;
                    _context.Entry(chk).State = EntityState.Modified;

                    await _context.SaveChangesAsync();
                    string message = "{\"Status\":\"user  updated successfully...!\"}";
                    return Ok(message);
                }
                else
                {
                    string response = "{\"Status\":\" Something went wrong...!\"}";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                string error = "{\"Status\":\"" + ex.InnerException?.Message?.Replace('"', ' ').Trim() + "\"}";
                return StatusCode(500, error);
            }
        }

       
        [HttpPost("PostTblUserMaster")]
        public async Task<ActionResult<TblUserMaster>> PostTblUserMaster(TblUserMaster typechalan)
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

        [HttpPost("DeleteTblUserMaster")]
        public async Task<IActionResult> DeleteTblUserMaster(TblUserMaster chalantype)
        {
            try
            {
                var chk = await _context.TblUserMasters.FirstOrDefaultAsync(e => e.UserId == chalantype.UserId);
                if (chk != null)
                {
                    chk.IsActive = false;
                    chk.UpdatedBy = chalantype.UpdatedBy;
                    chk.UpdatedDate = DateTime.Now;

                    _context.Entry(chk).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    string status = "{\"Status\":\" UserId Deleted Successfully...!\"}";
                    return Ok(status);
                }
                else
                {
                    string response = "{\"Status\":\" Something went wrong..!\"}";
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                string error = "{\"Status\":\"" + ex.InnerException?.Message?.Replace('"', ' ').Trim() + "\"}";
                return StatusCode(500, error);
            }
        }
    }
}
