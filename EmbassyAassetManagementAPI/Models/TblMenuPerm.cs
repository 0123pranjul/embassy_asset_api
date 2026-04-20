using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblMenuPerm
{
    public int PermissionId { get; set; }

    public int? RoleId { get; set; }

    public int? MenuId { get; set; }

    public bool? CanRead { get; set; }

    public bool? CanWrite { get; set; }

    public bool? CanDelete { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TblPopupMenu? Menu { get; set; }

    public virtual TblRoleMaster? Role { get; set; }
}
