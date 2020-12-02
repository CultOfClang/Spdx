using System;
using System.Text.Json.Serialization;

namespace Spdx
{
    internal class LicensesData
    {
        [JsonPropertyName("licenseListVersion")] public string LicenseListVersion { get; set; }
        [JsonPropertyName("licenses")] public License[] Licenses { get; set; }
        [JsonPropertyName("releaseDate")] public DateTime ReleaseDate { get; set; }
        [JsonPropertyName("exceptions")]  public LicenseException[] Exceptions { get; set; }

    }

}
