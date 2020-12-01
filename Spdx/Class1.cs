using System;

namespace Spdx
{
    public class Class1
    {
    }
    public class Rootobject
    {
        public string LicenseListVersion { get; set; }
        public License[] Licenses { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    public class License
    {
        public string Reference { get; set; }
        public bool IsDeprecatedLicenseId { get; set; }
        public Uri DetailsUrl { get; set; }
        public string ReferenceNumber { get; set; }
        public string Name { get; set; }
        public string LicenseId { get; set; }
        public Uri[] SeeAlso { get; set; }
        public bool IsOsiApproved { get; set; }
        public bool IsFsfLibre { get; set; }
    }

}
