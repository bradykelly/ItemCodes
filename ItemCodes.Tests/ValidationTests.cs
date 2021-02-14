using System;
using ItemCodes.Console;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItemCodes.Tests
{
    [TestClass]
    public class ValidationTests
    {
        //"\bx{0,3}(ix|iv|v?i{0,3})\b"
        // There are too many combinations of invalid to test for all, but we're not here to test the regex

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStartsWithInvalid()
        {
            var section = new ItemCodeSection {Content = "xviii)"};
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestEndsWithInvalid()
        {
            var section = new ItemCodeSection {Content = "(xviii"};
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidPattern1()
        {
            var section = new ItemCodeSection { Content = "(xZiii" };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidPattern2()
        {
            var section = new ItemCodeSection { Content = "(xxxxviii" };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidPattern3()
        {
            var section = new ItemCodeSection { Content = "vv" };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidPattern4()
        {
            var section = new ItemCodeSection { Content = "iiii" };
        }
    }
}
