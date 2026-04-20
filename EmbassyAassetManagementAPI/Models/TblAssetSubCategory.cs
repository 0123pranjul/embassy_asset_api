using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblAssetSubCategory
{
    public int SubcategoryId { get; set; }

    public string? SubcategoryCode { get; set; }

    public int? CategoryId { get; set; }

    public string? SubcategoryName { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblAssetCategory? Category { get; set; }

    public virtual ICollection<TblAssetRegistration> TblAssetRegistrations { get; } = new List<TblAssetRegistration>();
}
