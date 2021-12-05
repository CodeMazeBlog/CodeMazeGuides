using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace StringBuilderTests
{
    [TestClass]
    public class StringBuilderCheckEmptyTests
    {
        [TestMethod]
        public void GivenStringBuilder_WhenZeroChar_ThenLengthEqualZero()
        {
            var filledStringBuilder = new StringBuilder();
            
            Assert.AreEqual(0, filledStringBuilder.Length);
        }

        [TestMethod]
        public void GivenStringBuilder_WhenConvertedToString_ThenStringEqualZero()
        {
            var emptyStringBuilder = new StringBuilder();

            var converted2String = emptyStringBuilder.ToString();

            Assert.IsTrue(string.Empty == converted2String);
        }
    }
}