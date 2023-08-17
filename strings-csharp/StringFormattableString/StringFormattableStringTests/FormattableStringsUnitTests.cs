namespace StringFormattableStringTests
{
    [TestClass]
    public class FormattableStringsUnitTests
    {
        private readonly FormattableStringsMethods _formattableStringMethods = new();
    
        [TestMethod]
        public void GivenAStringObject_WhenStringOperationsApplied_VerifyAccurateResults()
        {
            var stringObj = "Jane";
            var sampleString = _formattableStringMethods.StringExample();

            Assert.AreEqual(stringObj.Count(), stringObj.Length);
            Assert.IsFalse(stringObj.Equals(sampleString));
            Assert.AreEqual(sampleString.CompareTo(stringObj), 1);
            Assert.IsInstanceOfType(sampleString, typeof(string));
        }

        [TestMethod]
        public void GivenAFormattableStringObject_WhenFormattableStringOperationsApplied_VerifyAccurateResults()
        {
            var sampleFormattableString = _formattableStringMethods.FormattableStringExample();

            Assert.AreEqual("Sean", sampleFormattableString.GetArgument(0));
            Assert.AreEqual(sampleFormattableString.ArgumentCount, 2);
            Assert.IsInstanceOfType(sampleFormattableString, typeof(FormattableString));
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