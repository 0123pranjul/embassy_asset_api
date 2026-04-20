namespace EmbassyAassetManagementAPI.Models.DTO
{
    public class UsaerInformation
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

      //  public string? Password { get; set; }

        public string? Name { get; set; }

        public string? MobileNo { get; set; }

        public string? EmailId { get; set; }

        public string? Address { get; set; }


        public bool? IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? Token { get; set; }

        public int? HeadquarterId { get; set; }
        public int? Candidateid { get; set; }
        public int? salesmanid { get; set; }
        public string? Headquarter { get; set; }

        public int? ZoneId { get; set; }
        public int? EmployerId { get; set; }
        public string? Zone { get; set; }

        public int? PoliceStationId { get; set; }
        public string? PoliceStation { get; set; }
        public int? RoleId { get; set; }
       public string? RoleName { get; set; }
       
    }

}
