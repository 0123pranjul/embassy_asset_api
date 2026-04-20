using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using EmbassyAassetManagementAPI.Models;
using EmbassyAassetManagementAPI.Models.DTO;
using System.Net;
using System.Net.Mail;
using System.Text.Json;

namespace EmbassyAassetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoLocationController : ControllerBase
    {

        private readonly EmbassyAssetManagementContext _context;
        public readonly IConfiguration _configuration;
        public GeoLocationController(EmbassyAssetManagementContext context, IConfiguration config)
        {
            this._context = context;
            _configuration = config;
        }
        [HttpPost("log-login")]
        public async Task<IActionResult> LogLogin([FromBody] LoginAuditDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid request data");

            if (dto.IPAddress == "::1" || dto.IPAddress == "127.0.0.1")
                dto.IPAddress = "8.8.8.8";

            string token = "a8b7fea64e564f";  // ipinfo.io token
            string apiUrl = $"https://ipinfo.io/{dto.IPAddress}/json?token={token}";
            string json;

            try
            {
                using var http = new HttpClient();
                json = await http.GetStringAsync(apiUrl);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"IP lookup failed: {ex.Message}");
            }

            dynamic loc = JsonConvert.DeserializeObject(json);

            string[] latLong = loc.loc != null
                ? loc.loc.ToString().Split(',')
                : new string[] { "0", "0" };

            var log = new Loginauditlog
            {
                Username = dto.UserName,
                Appname = dto.AppName,
                Ipaddress = dto.IPAddress,
                Country = loc.country ?? "Unknown",
                Region = loc.region ?? "Unknown",
                City = loc.city ?? "Unknown",
                Zipcode = loc.postal ?? "",
                Latitude = latLong[0],
                Longitude = latLong[1],
                Timezone = loc.timezone ?? "",
                Org = loc.org ?? "",
                Isp = loc.org ?? "",
                Browserinfo = dto.BrowserInfo,
                Loggedinat = DateTime.Now
            };

            _context.Loginauditlogs.Add(log);
            await _context.SaveChangesAsync();

            return Ok(new { Status = "Logged", IP = dto.IPAddress });
        }


       
    }


}

