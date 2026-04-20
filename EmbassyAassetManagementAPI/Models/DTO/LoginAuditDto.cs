namespace EmbassyAassetManagementAPI.Models.DTO
{
    public class LoginAuditDto
    {
        public string UserName { get; set; }
        public string AppName { get; set; }
        public string IPAddress { get; set; }
        public string BrowserInfo { get; set; }
    }
}
