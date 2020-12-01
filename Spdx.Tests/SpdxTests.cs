using NUnit.Framework;
using Spdx;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spdx.Tests
{
    [TestFixture()]
    public class SpdxTests
    {
        [TestCase]
        public void LoadTest()
        {
            var licences = Spdx.Licenses;
            Assert.Greater(licences.Count, 10);
        }
    }
}