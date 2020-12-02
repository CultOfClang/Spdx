using System;

namespace Spdx
{
    public abstract class HasDetails<T>
    {
        Lazy<T> details => new Lazy<T>(LoadDetails);
        public T Details => details.Value;

        public abstract string Id { get; }
        internal string DetailFamily => typeof(T).Name.ToLowerInvariant();
        internal T LoadDetails()
        {
            return Spdx.Load<T>($"Spdx.{DetailFamily}.{Id}.json");

        }
    }

    public class Exceptions
    {
        public bool isDeprecatedLicenseId { get; set; }
        public string licenseExceptionText { get; set; }
        public string name { get; set; }
        public string[] seeAlso { get; set; }
        public string licenseExceptionId { get; set; }
    }

    public class Details
    {
        public bool isDeprecatedLicenseId { get; set; }
        public string licenseText { get; set; }
        public string standardLicenseTemplate { get; set; }
        public string name { get; set; }
        public string licenseId { get; set; }
        public Crossref[] crossRef { get; set; }
        public string[] seeAlso { get; set; }
        public bool isOsiApproved { get; set; }
    }

    public class Crossref
    {
        public bool isLive { get; set; }
        public bool isValid { get; set; }
        public bool isWayBackLink { get; set; }
        public string match { get; set; }
        public string url { get; set; }
        public int order { get; set; }
        public string timestamp { get; set; }
    }

}
