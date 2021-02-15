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
            var val = "M610.04";

            var code = BoqItemCode.Parse(val);

            Assert.AreEqual(val, code.StringValue);
        }
    }
}
