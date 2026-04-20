using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblRoleMaster
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TblMenuPerm> TblMenuPerms { get; } = new List<TblMenuPerm>();

    public virtual ICollection<TblUserRole> TblUserRoles { get; } = new List<TblUserRole>();
}
