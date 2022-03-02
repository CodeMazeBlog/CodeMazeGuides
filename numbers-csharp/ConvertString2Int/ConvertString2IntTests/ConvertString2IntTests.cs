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
        public void GivenStringNotANumber_WhenConvertedWithIntParse_ThenThrowsException()
        {
            var stringValue = "NotANumber";
            var numberConvertedFromString = 0;

            Assert.ThrowsException<FormatException>(() => numberConvertedFromString = int.Parse(stringValue));
        }

        [TestMethod]
        public void GivenString3_WhenConvertedWithIntTryParse_ThenReturnInt()
        {
            var number = 3;
            var stringValue = "3";
            var numberConvertedFromString = 0;

            int.TryParse(stringValue, out numberConvertedFromString);

            Assert.AreEqual(number, numberConvertedFromString);
        }
        
        [TestMethod]
        public void GivenStringNotANumber_WhenConvertedWithIntTryParse_ThenReturn0()
        {
            var number = 0;
            var stringValue = "NotANumber";
            var numberConvertedFromString = 0;

            int.TryParse(stringValue, out numberConvertedFromString);

            Assert.AreEqual(number, numberConvertedFromString);
        }

        [TestMethod]
        public void GivenStringEmpty_WhenConvertedWithIntTryParse_ThenReturn0()
        {
            var number = 0;
            var stringValue = string.Empty;
            var numberConvertedFromString = 0;

            int.TryParse(stringValue, out numberConvertedFromString);

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
        public void GivenNull_WhenConvertedWithConvertToInt32_ThenReturn0()
        {
            var number = 0;
            var numberConvertedFromString = Convert.ToInt32(null);

            Assert.AreEqual(number, numberConvertedFromString);
        }

        [TestMethod]
        public void GivenStringEmpty_WhenConvertedWithConvertToInt32_ThenThrowsException()
        {
            var stringValue = string.Empty;
            var numberConvertedFromString = 0;

            Assert.ThrowsException<FormatException>(() => numberConvertedFromString = Convert.ToInt32(stringValue));
        }

        [TestMethod]
        public void GivenString_WhenConvertedWithCustomConvert_ThenReturnInt()
        {
            var number = 333;
            var stringValue = "333";
            var numberConvertedFromString = 0;

            for (var i = 0; i < stringValue.Length; i++)
            {
                numberConvertedFromString = numberConvertedFromString * 10 + (stringValue[i] - '0');
            }

            Assert.AreEqual(number, numberConvertedFromString);
        }
    }
}