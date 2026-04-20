using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblUserMaster
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string? Password { get; set; }

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

    public string? Lastname { get; set; }

    public string? Empid { get; set; }

    public string? Nationalid { get; set; }

    public int? Deviceid { get; set; }

    public int? Candidateid { get; set; }

    public int? Salesmanid { get; set; }

    public string? Companyname { get; set; }

    public string? Companytype { get; set; }

    public int? Otp { get; set; }

    public virtual ICollection<TblUserRole> TblUserRoleParents { get; } = new List<TblUserRole>();

    public virtual ICollection<TblUserRole> TblUserRoleUsers { get; } = new List<TblUserRole>();
}
