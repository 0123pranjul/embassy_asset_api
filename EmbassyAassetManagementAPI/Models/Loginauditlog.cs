using System;
using System.Collections.Generic;

namespace EmbassyAassetManagementAPI.Models;

public partial class Loginauditlog
{
    public long Logid { get; set; }

    public string? Username { get; set; }

    public string? Appname { get; set; }

    public string? Ipaddress { get; set; }

    public string? Country { get; set; }

    public string? Region { get; set; }

    public string? City { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public string? Browserinfo { get; set; }

    public DateTime? Loggedinat { get; set; }

    public string? Zipcode { get; set; }

    public string? Timezone { get; set; }

    public string? Isp { get; set; }

    public string? Org { get; set; }

    public string? Asinfo { get; set; }

    public string? Countrycode { get; set; }

    public string? Regionname { get; set; }
}
