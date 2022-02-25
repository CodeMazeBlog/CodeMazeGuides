using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConvertString2IntTests
{
    [TestClass]
    public class ConvertString2IntTests
    {
        [TestMethod]
        public void GivenString_WhenConvertedWithIntParse_ThenReturnInt()
        {
            var number = 3;
            var stringValue = "3";
            
            var numberConvertedFromString = int.Parse(stringValue);

            Assert.AreEqual(number, numberConvertedFromString);
        }

        [TestMethod]
        public void GivenString_WhenConvertedWithIntTryParse_ThenReturnInt()
        {
            var number = 3;
            var stringValue = "3";

            int numberConvertedFromString = int.TryParse(stringValue, out numberConvertedFromString) ? numberConvertedFromString : 0;

            Assert.AreEqual(number, numberConvertedFromString);
        }

        [TestMethod]
        public void GivenString_WhenConvertedWithConvertToInt32_ThenReturnInt()
        {
            var number = 3;
            var stringValue = "3";

            var numberConvertedFromString = Convert.ToInt32(stringValue);

            Assert.AreEqual(number, numberConvertedFromString);
        }

        [TestMethod]
        public void GivenString_WhenConvertedWithCustomConvert_ThenReturnInt()
        {
            var number = 3;
            var stringValue = "3";

            int numberConvertedFromString = 0;
            for (int i = 0; i < stringValue.Length; i++)
            {
                numberConvertedFromString = numberConvertedFromString * 10 + (stringValue[i] - '0');
            }

            Assert.AreEqual(number, numberConvertedFromString);
        }
    }

}