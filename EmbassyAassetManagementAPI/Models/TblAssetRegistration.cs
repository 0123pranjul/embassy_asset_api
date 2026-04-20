using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblAssetRegistration
{
    public int AssetId { get; set; }

    public string? AssetCode { get; set; }

    public string? AssetName { get; set; }

    public int? EmbassyId { get; set; }

    public int? DepartmentId { get; set; }

    public int? CategoryId { get; set; }

    public int? SubcategoryId { get; set; }

    public int? CurrencyId { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public decimal? PurchaseAmount { get; set; }

    public string? InvoiceNo { get; set; }

    public string? VendorName { get; set; }

    public string? SerialNumber { get; set; }

    public string? ModelNumber { get; set; }

    public string? Brand { get; set; }

    public DateOnly? WarrantyStartDate { get; set; }

    public DateOnly? WarrantyEndDate { get; set; }

    public string? DepreciationType { get; set; }

    public decimal? DepreciationRate { get; set; }

    public string? AssetCondition { get; set; }

    public string? AssetStatus { get; set; }

    public string? LocationDetails { get; set; }

    public string? BarcodePath { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblAssetCategory? Category { get; set; }

    public virtual TblCurrencyMaster? Currency { get; set; }

    public virtual TblDepartmentMaster? Department { get; set; }

    public virtual TblEmbassyMaster? Embassy { get; set; }

    public virtual TblAssetSubCategory? Subcategory { get; set; }

    public virtual ICollection<TblAssetTransaction> TblAssetTransactions { get; } = new List<TblAssetTransaction>();
}
