using EmbassyAassetManagementAPI.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmbassyAassetManagementAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly Idata _idata;

        public TestController(Idata idata)
        {
            this._idata = idata;
        }
        [HttpGet]
        [Route("GetAllUserDetails")]
        public async Task<IActionResult> GetAllUserDetails()
        {
            var r = await _idata.GetAllUserDetails();
            return Ok(r);
        }
    }
}
