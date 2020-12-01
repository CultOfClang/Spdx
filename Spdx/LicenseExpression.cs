using System;
using System.Collections.Generic;
using System.Text;

namespace Spdx
{
    public enum Conjunction
    {
        Or, And
    }
    public class LicenseExpression
    {
        public LicenseExpression Left { get; set; }
        public LicenseExpression Right { get; set; }

        public Exception Exception { get; set; }
        public License License { get; set; }
    }

}
