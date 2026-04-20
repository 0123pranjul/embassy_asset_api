using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblUserRole
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? Parentid { get; set; }

    public virtual TblUserMaster? Parent { get; set; }

    public virtual TblRoleMaster Role { get; set; } = null!;

    public virtual TblUserMaster User { get; set; } = null!;
}
