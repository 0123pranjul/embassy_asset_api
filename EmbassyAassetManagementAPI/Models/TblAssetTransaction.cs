using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class TblAssetTransaction
{
    public int TransactionId { get; set; }

    public int? AssetId { get; set; }

    public string? ActionType { get; set; }

    public int? FromEmbassy { get; set; }

    public int? ToEmbassy { get; set; }

    public string? Remarks { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual TblAssetRegistration? Asset { get; set; }
}
