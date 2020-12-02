using NUnit.Framework;
using Spdx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spdx.Tests
{
    [TestFixture()]
    public class SpdxTests
    {
        [TestCase]
        public void LoadTest()
        {
            Assert.Greater(Spdx.Licenses.Count, 10);
            Assert.Greater(Spdx.Exceptions.Count, 10);
        }

        [TestCase]
        public void Details()
        {
            Assert.NotNull(Spdx.Licenses.First().Details);
        }
    }
}