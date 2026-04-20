using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblCountryMaster
{
    public int CountryId { get; set; }

    public string? CountryCode { get; set; }

    public string CountryName { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblCurrencyMaster> TblCurrencyMasters { get; } = new List<TblCurrencyMaster>();

    public virtual ICollection<TblEmbassyMaster> TblEmbassyMasters { get; } = new List<TblEmbassyMaster>();
}
