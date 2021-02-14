using System;
using System.Collections.Generic;
using System.Text;
using ItemCodes.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItemCodes.Tests
{
    [TestClass]
    public class ItemCodeParseTests
    {
        [TestMethod]
        public void TestValidItemCode1()
        {
            var val = "M250.01(a)(ii)(iii)";

            var code = BoqItemCode.Parse(val);

            Assert.AreEqual(val, code.StringValue);
        }
    }
}
