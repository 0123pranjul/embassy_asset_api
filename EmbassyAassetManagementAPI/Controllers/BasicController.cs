using EmbassyAassetManagementAPI.Models;
using EmbassyAassetManagementAPI.Models.DTO;
using EmbassyAassetManagementAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using EmbassyAassetManagementAPI.Models;

namespace EmbassyAassetManagementAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        private readonly EmbassyAssetManagementContext _context;
        private readonly IConfiguration configuration;

        public BasicController(EmbassyAssetManagementContext context, IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;
        }
      
        [HttpGet("GetMenusByRoleID")]
        public async Task<IActionResult> GetMenusByRoleID(int id)
        {
            try
            {
                var menus = await _context.TblPopupMenus
          .Where(m => m.IsActive ==true &&
                      m.TblMenuPerms.Any(p =>
                          p.RoleId == id &&
                          p.IsActive ==true &&
                          p.CanRead ==true))
          .OrderBy(m => m.Orderby)
          .Select(m => new MenuDto
          {
              MenuId = m.MenuId,
              MenuName = m.MenuName,
              Href = m.Href,
              Icon = m.Icon,
              ParentId = m.ParentId,
              Orderby = m.Orderby
          })
          .ToListAsync();


                if (!menus.Any())
                {
                    return NotFound(new { Message = "No menu found for this role." });
                }

                return Ok(menus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Internal Server Error", Details = ex.Message });
            }
        }

        [HttpGet("GetMenusByRole")]
        public async Task<IActionResult> GetMenusByRole(int id)
        {
            try
            {
                // Step 1: Get flat menu list based on role and read permission
                var flatMenus = await _context.TblPopupMenus
                    .Join(_context.TblMenuPerms,
                          menu => menu.MenuId,
                          perm => perm.MenuId,
                          (menu, perm) => new { menu, perm })
                    .Where(x => x.perm.RoleId == id
                             && x.menu.IsActive == true
                             && x.perm.IsActive == true
                             && (x.perm.CanRead ?? false)) // null-safe bool?
                    .Select(x => new MenuDto
                    {
                        MenuId = x.menu.MenuId,
                        MenuName = x.menu.MenuName,
                        Href = x.menu.Href,
                        Icon = x.menu.Icon,
                        ParentId = x.menu.ParentId
                    })
                    .ToListAsync();

                if (!flatMenus.Any())
                    return NotFound(new { Message = "No menu found for this role." });

                // Step 2: Build tree hierarchy
                var menuDict = flatMenus.ToDictionary(m => m.MenuId);
                var rootMenus = new List<MenuDto>();

                foreach (var menu in flatMenus)
                {
                    if (menu.ParentId.HasValue && menuDict.ContainsKey(menu.ParentId.Value))
                    {
                        menuDict[menu.ParentId.Value].Children.Add(menu);
                    }
                    else
                    {
                        rootMenus.Add(menu); // Top-level menu
                    }
                }

                return Ok(rootMenus);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Internal Server Error", Details = ex.Message });
            }
        }
        [HttpPost("MappingUserbasisOfRole")]
        public async Task<ActionResult<TblUserMaster>> MappingUserbasisOfRole(TblUserRole map)
        {
            try
            {
                if (_context.TblUserRoles == null)
                {
                    return Problem("Entity set 'EmbassyAssetManagementContext.TblPoliceRegistrations' is null.");
                }

                bool userMasterExists = await _context.TblUserRoles.AnyAsync(e => e.UserId == map.UserId);
                if (userMasterExists)
                {
                    var existing = _context.TblUserRoles.Where(p => p.UserId == map.UserId);
                    _context.TblUserRoles.RemoveRange(existing);
                }
                map.UserId = map.UserId;
                map.RoleId = map.RoleId;
                map.Parentid = map.Parentid;
                map.IsActive = true;
                map.CreatedDate = DateTime.Now;
                map.UpdatedBy = "NA";
                map.UpdatedDate = DateTime.Now;
                _context.TblUserRoles.Add(map);
                await _context.SaveChangesAsync();

                string successMessage = "User Created Successfully with UserId: " + map.UserId;
                return Ok(new { Success = true, Message = successMessage });
            }
            catch (Exception ex)
            {
                string error = "{\"Status\":\"" + ex.InnerException?.Message?.Replace('"', ' ').Trim() + "\"}";
                return StatusCode(500, error);
            }
        }







    }
}
