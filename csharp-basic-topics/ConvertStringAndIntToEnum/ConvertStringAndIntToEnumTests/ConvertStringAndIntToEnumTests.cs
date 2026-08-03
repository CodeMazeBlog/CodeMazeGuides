using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConvertStringAndIntToEnumTests
{
    [TestClass]
    public class ConvertStringAndIntToEnumTests
    {
        [TestMethod]
        public void GivenValidEnumAsString_WhenConvertingToEnum_ThenCorrectlyConverted()
        {
            var inputString = "Sunday";
            
            DayOfWeek dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), inputString);
            
            Assert.AreEqual(DayOfWeek.Sunday, dayOfWeek);
        }

        [TestMethod]
        public void GivenInvalidEnumAsString_WhenConvertingToEnum_ThenFails()
        {
            var inputString = "Today";
            
            var isEnumParsed = Enum.TryParse(inputString, true, out DayOfWeek dayOfWeek);
            
            Assert.IsFalse(isEnumParsed);
        }

        [TestMethod]
        public void GivenValidEnumAsStringInteger_WhenConvertingToEnum_ThenCorrectlyConverted()
        {
            var inputString = "0";
            
            var isEnumParsed = Enum.TryParse(inputString, true, out DayOfWeek dayOfWeek);
            
            Assert.IsTrue(isEnumParsed);
            Assert.AreEqual(DayOfWeek.Monday, dayOfWeek);
        }

        [TestMethod]
        public void GivenValidEnumAsInteger_WhenConvertingToEnum_ThenCorrectlyConverted()
        {
            var inputInt = 2;
            
            var isEnumParsed = Enum.IsDefined(typeof(DayOfWeek), inputInt);
            
            Assert.IsTrue(isEnumParsed);
            DayOfWeek dayOfWeek = (DayOfWeek)inputInt;
            Assert.AreEqual(DayOfWeek.Wednesday, dayOfWeek);
        }

        [TestMethod]
        public void GivenInvalidEnumAsInteger_WhenConvertingToEnum_ThenFails()
        {
            var inputInt = 9;
            
            var isEnumParsed = Enum.IsDefined(typeof(DayOfWeek), inputInt);
            
            Assert.IsFalse(isEnumParsed);
        }

        [TestMethod]
        public void GivenValidFlagsEnumAsInteger_WhenConvertingToEnum_ThenCorrectlyConverted()
        {
            var inputInt = 3;
            var parsedEnum = (UserType)inputInt;
            
            var isEnumParsed = Enum.IsDefined(typeof(UserType), inputInt) || parsedEnum.ToString().Contains(",");
            
            Assert.IsTrue(isEnumParsed);
            Assert.AreEqual(UserType.Customer| UserType.Driver, parsedEnum);
        }

        [TestMethod]
        public void GivenInvalidFlagsEnumAsInteger_WhenConvertingToEnum_ThenFails()
        {
            var inputInt = 8;
            var parsedEnum = (UserType)inputInt;
            
            var isEnumParsed = Enum.IsDefined(typeof(UserType), inputInt) || parsedEnum.ToString().Contains(",");
            
            Assert.IsFalse(isEnumParsed);
        }
    }
}