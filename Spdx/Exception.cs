namespace Spdx
{
    public class Exception
    {
        public string reference { get; set; }
        public bool isDeprecatedLicenseId { get; set; }
        public string detailsUrl { get; set; }
        public string referenceNumber { get; set; }
        public string name { get; set; }
        public string[] seeAlso { get; set; }
        public string licenseExceptionId { get; set; }
    }

}
