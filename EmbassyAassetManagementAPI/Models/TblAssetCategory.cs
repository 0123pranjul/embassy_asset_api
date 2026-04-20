using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblAssetCategory
{
    public int CategoryId { get; set; }

    public string? CategoryCode { get; set; }

    public string? CategoryName { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblAssetRegistration> TblAssetRegistrations { get; } = new List<TblAssetRegistration>();

    public virtual ICollection<TblAssetSubCategory> TblAssetSubCategories { get; } = new List<TblAssetSubCategory>();
}
