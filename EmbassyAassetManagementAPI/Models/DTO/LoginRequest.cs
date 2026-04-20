namespace EmbassyAassetManagementAPI.Models.DTO
{
    public class LoginRequest
    {
        public string mobno { get; set; }
        public int? otp { get; set; }
        public string? Password { get; set; }
    }
}
