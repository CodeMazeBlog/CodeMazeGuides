using Microsoft.Extensions.Logging;

namespace StringFormattableStringTests
{
    [TestClass]
    public class FormattableStringsUnitTests
    {
        private readonly FormattableStringsMethods _formattableStringMethods = new();
    
        [TestMethod]
        public void GivenAStringObject_WhenStringOperationsApplied_VerifyAccurateResults()
        {
            const string studentName = "John";
            const int studentAge = 30;
            var sampleString = _formattableStringMethods.StringExample(studentName, studentAge);

            Assert.IsInstanceOfType(sampleString, typeof(string)); 
            Assert.IsTrue(sampleString.Contains(studentName));
            Assert.IsTrue(sampleString.Contains(studentAge.ToString()));
        }

        [TestMethod]
        public void GivenAFormattableStringObject_WhenFormattableStringOperationsApplied_VerifyAccurateResults()
        {
            const string studentName = "Sean";
            const int studentAge = 40;
            var sampleFormattableString = _formattableStringMethods.FormattableStringExample(studentName, studentAge);

            Assert.IsInstanceOfType(sampleFormattableString, typeof(FormattableString));
            Assert.AreEqual(studentName, sampleFormattableString.GetArgument(0));
            Assert.AreEqual(studentAge, sampleFormattableString.GetArgument(1));
            Assert.AreEqual(sampleFormattableString.ArgumentCount, 2);
        }

        [TestMethod]
        public void GivenAFormattableStringSQLObject_WhenFormattableStringOperationsApplied_VerifyAccurateResults()
        {
            const string userName = "John";
            var sampleFormattableString = _formattableStringMethods.FormattableSQLStringExample(userName);

            Assert.IsInstanceOfType(sampleFormattableString, typeof(FormattableString));
            Assert.AreEqual(userName, sampleFormattableString.GetArgument(0));
        }

        [TestMethod]
        public void GivenAFormattableStringDateObject_WhenFormattableStringOperationsApplied_VerifyAccurateResults()
        {
            var currentDate = DateTime.Now;
            var sampleFormattableString = _formattableStringMethods.FormattableStringDateExample(currentDate);

            Assert.IsInstanceOfType(sampleFormattableString, typeof(FormattableString));
            Assert.IsInstanceOfType(sampleFormattableString.GetArgument(0), typeof(DateTime));
            Assert.IsTrue(sampleFormattableString.ToString().Contains(currentDate.ToString("D")));
        }

        [TestMethod]
        public void GivenAFormattableStringLogObject_WhenFormattableStringOperationsApplied_VerifyAccurateResults()
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
        public void GivenAFormattableDynamicStringObject_WhenFormattableStringOperationsApplied_VerifyAccurateResults()
        {
            const string itemName = "Laptop";
            const int itemCount = 3;
            var sampleFormattableString = _formattableStringMethods.FormattableStringDynamicStringExample(itemName, itemCount);

            Assert.IsInstanceOfType(sampleFormattableString, typeof(FormattableString));
            Assert.AreEqual(itemCount, sampleFormattableString.GetArgument(0));
            Assert.AreEqual(itemName, sampleFormattableString.GetArgument(1));
        }

        [TestMethod]
        public void GivenAnIFormattableStringObject_WhenIFormattableStringOperationsApplied_VerifyAccurateResults()
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