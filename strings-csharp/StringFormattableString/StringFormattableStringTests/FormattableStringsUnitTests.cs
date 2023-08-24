using Microsoft.Extensions.Logging;

namespace StringFormattableStringTests
{
    [TestClass]
    public class FormattableStringsUnitTests
    {
        private readonly FormattableStringsMethods _formattableStringMethods = new();
    
        [TestMethod]
        public void WhenStringOperationsAppliedOnAStringObject_ThenVerifyAccurateResults()
        {
            const string StudentName = "John";
            const int StudentAge = 30;
            var sampleString = _formattableStringMethods.StringExample(StudentName, StudentAge);

            Assert.IsInstanceOfType(sampleString, typeof(string)); 
            Assert.IsTrue(sampleString.Contains(StudentName));
            Assert.IsTrue(sampleString.Contains(StudentAge.ToString()));
        }

        [TestMethod]
        public void WhenFormattableStringOperationsApplied_ThenVerifyAccurateResults()
        {
            const string StudentName = "Sean";
            const int StudentAge = 40;
            var sampleFormattableString = _formattableStringMethods.FormattableStringExample(StudentName, StudentAge);

            Assert.IsInstanceOfType(sampleFormattableString, typeof(FormattableString));
            Assert.AreEqual(StudentName, sampleFormattableString.GetArgument(0));
            Assert.AreEqual(StudentAge, sampleFormattableString.GetArgument(1));
            Assert.AreEqual(sampleFormattableString.ArgumentCount, 2);
        }

        [TestMethod]
        public void WhenFormattableStringOperationsAppliedOnDateObject_ThenVerifyAccurateResults()
        {
            var currentDate = DateTime.Now;
            var sampleFormattableString = _formattableStringMethods.FormattableStringDateExample(currentDate);

            Assert.IsInstanceOfType(sampleFormattableString, typeof(FormattableString));
            Assert.IsInstanceOfType(sampleFormattableString.GetArgument(0), typeof(DateTime));
            Assert.IsTrue(sampleFormattableString.ToString().Contains(currentDate.ToString("D")));
        }

        [TestMethod]
        public void WhenFormattableStringOperationsAppliedOnLogObjects_ThenVerifyAccurateResults()
        {
            var level = LogLevel.Information;
            var message = "Logging method invoked";
            var sampleFormattableString = _formattableStringMethods.FormattableStringLoggingExample(level, message);

            Assert.IsInstanceOfType(sampleFormattableString, typeof(FormattableString));
            Assert.IsInstanceOfType(sampleFormattableString.GetArgument(0), typeof(DateTime));
            Assert.IsInstanceOfType(sampleFormattableString.GetArgument(1), typeof(LogLevel));
            Assert.IsInstanceOfType(sampleFormattableString.GetArgument(2), typeof(string));
        }

        [TestMethod]
        public void WhenFormattableStringOperationsAppliedOnDynamicStringObject_ThenVerifyAccurateResults()
        {
            const string itemName = "Laptop";
            const int itemCount = 3;
            var sampleFormattableString = _formattableStringMethods.FormattableStringDynamicStringExample(itemName, itemCount);

            Assert.IsInstanceOfType(sampleFormattableString, typeof(FormattableString));
            Assert.AreEqual(itemCount, sampleFormattableString.GetArgument(0));
            Assert.AreEqual(itemName, sampleFormattableString.GetArgument(1));
        }

        [TestMethod]
        public void WhenIFormattableStringOperationsApplied_ThenVerifyAccurateResults()
        {
            var temperature = new TemperatureFormat(20.0);
            
            var formattedKelvins = string.Format("Temperature: {0:K}", temperature);
            var formattedFahrenheit = string.Format("Temperature: {0:F}", temperature);
            var formattedCelsius = string.Format("Temperature: {0}", temperature);

            Assert.AreEqual("Temperature: 20 C", formattedCelsius);
            Assert.AreEqual("Temperature: 68 F", formattedFahrenheit);
            Assert.AreEqual("Temperature: 293.15 K", formattedKelvins);
        }
    }
}