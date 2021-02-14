using System;
using System.Collections.Generic;
using System.Text;
using ItemCodes.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItemCodes.Tests
{
    [TestClass]
    public class SecondSectionTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidPattern1()
        {
            var section = new BoqItemCodeSecondSection {Content = "()"};
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidPattern2()
        {
            var section = new BoqItemCodeSecondSection { Content = "(aaa)" };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidPattern3()
        {
            var section = new BoqItemCodeSecondSection { Content = "(1)" };
        }

        [TestMethod]
        public void TestValidPattern()
        {
            var section = new BoqItemCodeSecondSection {Content = "(ab)"};

            Assert.AreEqual(28, section.Value);
        }
    }
}
