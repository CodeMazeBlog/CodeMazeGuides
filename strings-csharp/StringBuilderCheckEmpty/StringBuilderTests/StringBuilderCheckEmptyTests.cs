using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace StringBuilderTests
{
    [TestClass]
    public class StringBuilderCheckEmptyTests
    {
        [TestMethod]
        public void givenStringBuilder_whenZeroChar_thenLengthEqualZero()
        {
            var filledStringBuilder = new StringBuilder();
            
            Assert.AreEqual(0, filledStringBuilder.Length);
        }

        [TestMethod]
        public void givenStringBuilder_whenConvertedToString_thenStringEqualZero()
        {
            var emptyStringBuilder = new StringBuilder();

            string converted2String = emptyStringBuilder.ToString();

            Assert.IsTrue(string.Empty == converted2String);
        }
    }
}