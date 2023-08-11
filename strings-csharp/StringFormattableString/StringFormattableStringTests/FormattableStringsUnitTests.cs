using StringFormattableString;
using System.Runtime.CompilerServices;

namespace StringFormattableStringTests
{
    [TestClass]
    public class FormattableStringsUnitTests
    {
        private readonly FormattableStringsMethods _formattableStringMethods;
        private readonly string _sampleString;
        private readonly FormattableString _sampleFormattableString;

        public FormattableStringsUnitTests()
        {
            _formattableStringMethods = new FormattableStringsMethods();
            _sampleString = _formattableStringMethods.StringExample();
            _sampleFormattableString = _formattableStringMethods.FormattableStringExample();
        }

        [TestMethod]
        public void GivenAStringObject_WhenStringOperationsApplied_VerifyAccurateResults()
        {
            var stringObj = "Jane";

            Assert.AreEqual(stringObj.Count(), stringObj.Length);
            Assert.IsFalse(stringObj.Equals(_sampleString));
            Assert.AreEqual(_sampleString.CompareTo(stringObj), 1);
            Assert.IsInstanceOfType(_sampleString, typeof(string));
        }
        [TestMethod]
        public void GivenAFormattableStringObject_WhenFormattableStringOperationsApplied_VerifyAccurateResults()
        {
            Assert.AreEqual("John", _sampleFormattableString.GetArgument(0));
            Assert.AreEqual(_sampleFormattableString.ArgumentCount, 2);
            Assert.IsInstanceOfType(_sampleFormattableString, typeof(FormattableString));
            Assert.IsInstanceOfType(_sampleFormattableString.ToString(), typeof(string));
        }

        [TestMethod]
        public void GivenAnIFormattableStringObject_WhenIFormattableStringOperationsApplied_VerifyAccurateResults()
        {
            var temperature = new TemperatureFormat(20.0);
            
            var formattedCelsius = string.Format("Temperature: {0:C}", temperature);
            var formattedFahrenheit = string.Format("Temperature: {0:F}", temperature);
            var formattedKelvins = string.Format("Temperature: {0}", temperature);

            Assert.AreEqual("Temperature: 20 C", formattedCelsius);
            Assert.AreEqual("Temperature: 68 F", formattedFahrenheit);
            Assert.AreEqual("Temperature: 293.15 K", formattedKelvins);
        }
    }
}