using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblPopupMenu
{
    public int MenuId { get; set; }

    public string MenuName { get; set; } = null!;

    public string? Href { get; set; }

    public int? ParentId { get; set; }

    public string? Icon { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? Helperurl { get; set; }

    public int? Orderby { get; set; }

    public virtual ICollection<TblMenuPerm> TblMenuPerms { get; } = new List<TblMenuPerm>();
}
