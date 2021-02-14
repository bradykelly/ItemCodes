using System;
using ItemCodes.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItemCodes.Tests
{
    [TestClass]
    public class FirstSectionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidPrefix()
        {
            var section = new BoqItemCodeFirstSection {Content = "_999.9"};
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidNumber1()
        {
            var section = new BoqItemCodeFirstSection { Content = "M9a9.9" };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidNumber2()
        {
            var section = new BoqItemCodeFirstSection { Content = "M99.9" };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidNumber3()
        {
            var section = new BoqItemCodeFirstSection { Content = "M9990.9" };
        }

        [TestMethod]
        public void TestValidPattern()
        {
            var section = new BoqItemCodeFirstSection { Content = "M111.1" };

            Assert.AreEqual(13 * 111.1, section.Value);
        }
    }
}
