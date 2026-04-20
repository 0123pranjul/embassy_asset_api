using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblEmbassyMaster
{
    public int EmbassyId { get; set; }

    public string? EmbassyCode { get; set; }

    public int? CountryId { get; set; }

    public string? EmbassyType { get; set; }

    public string? EmbassyName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public string? ContactPerson { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblCountryMaster? Country { get; set; }

    public virtual ICollection<TblAssetRegistration> TblAssetRegistrations { get; } = new List<TblAssetRegistration>();

    public virtual ICollection<TblDepartmentMaster> TblDepartmentMasters { get; } = new List<TblDepartmentMaster>();
}
