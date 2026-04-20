using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblDepartmentMaster
{
    public int DepartmentId { get; set; }

    public string? DepartmentCode { get; set; }

    public int? EmbassyId { get; set; }

    public string? DepartmentName { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblEmbassyMaster? Embassy { get; set; }

    public virtual ICollection<TblAssetRegistration> TblAssetRegistrations { get; } = new List<TblAssetRegistration>();
}
