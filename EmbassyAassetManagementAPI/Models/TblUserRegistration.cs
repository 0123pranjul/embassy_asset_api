using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblUserRegistration
{
    public int Sno { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? MobileNo { get; set; }

    public string? EmailId { get; set; }

    public string? Address { get; set; }

    public int? ZoneId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Token { get; set; }

    public string? DeviceId { get; set; }

  
}
