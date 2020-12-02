using System;
using System.Text.Json.Serialization;

namespace Spdx
{
    public class License : HasDetails<Details>
    {
        [JsonPropertyName("reference")] public string Reference { get; set; }
        [JsonPropertyName("isDeprecatedLicenseId")] public bool IsDeprecatedLicenseId { get; set; }
        [JsonPropertyName("detailsUrl")] public Uri DetailsUrl { get; set; }
        [JsonPropertyName("referenceNumber")] public string ReferenceNumber { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
        [JsonPropertyName("licenseId")] public string LicenseId { get; set; }
        [JsonPropertyName("seeAlso")]  public Uri[] SeeAlso { get; set; }
        [JsonPropertyName("isOsiApproved")]  public bool IsOsiApproved { get; set; }
        [JsonPropertyName("isFsfLibre")]  public bool IsFsfLibre { get; set; }

        public override string Id => LicenseId;
    }

}
