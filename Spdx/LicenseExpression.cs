using System;
using System.Collections.Generic;
using System.Text;
using static Spdx.Parser;

namespace Spdx
{
    public class LicenseExpression : IExpr
    {
        public LicenseExpression Left { get; set; }
        public LicenseExpression Right { get; set; }
        public Conjunction Conjunction { get; set; }

        public LicenseException Exception { get; set; }
        public License License { get; set; }

        public bool Equals(IExpr other)
        {
            return obj is LicenseExpression expression &&
          EqualityComparer<LicenseExpression>.Default.Equals(Left, expression.Left) &&
          EqualityComparer<LicenseExpression>.Default.Equals(Right, expression.Right) &&
          Conjunction == expression.Conjunction &&
          EqualityComparer<LicenseException>.Default.Equals(Exception, expression.Exception) &&
          EqualityComparer<License>.Default.Equals(License, expression.License);
        }
    }

}
