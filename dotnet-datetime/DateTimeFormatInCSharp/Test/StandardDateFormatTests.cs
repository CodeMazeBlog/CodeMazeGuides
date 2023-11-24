using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;

namespace Test
{
    [TestClass]
    public class StandardDateFormatTests
    {
        [TestMethod]
        public void WhenUsingStandardFormatSpecifiers_ThenCurrentCultureFormatIsApplied()
        {
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24);
            Console.WriteLine(datetime.ToString("d")); // 8/24/2017

            Assert.AreEqual($"8/24/2017{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingStandardFormatSpecifiers_ThenOutputChangesAccordingToCulture()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24);
            Console.WriteLine(datetime.ToString("d", CultureInfo.CreateSpecificCulture("en-US"))); // 8/24/2017
            Console.WriteLine(datetime.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))); // 24/8/2017
            Console.WriteLine(datetime.ToString("d", CultureInfo.CreateSpecificCulture("ja-JP"))); // 2017/08/24

            Assert.AreEqual($"8/24/2017{Environment.NewLine}" +
                                $"24/8/2017{Environment.NewLine}" +
                                $"2017/08/24{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingDateTimeFormatInfo_ThenOutputChangesAccordingToCustomFormatInfo()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24);
            var formatInfo = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat;
            formatInfo.DateSeparator = "-";

            Console.WriteLine(datetime.ToString("d", formatInfo)); // 8-24-2017

            Assert.AreEqual($"8-24-2017{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingFormatSpecifierAndCulture_ThenCanParseCorrectString()
        {
            var dateLiteral = "8/24/2017";
            var date = DateTime.ParseExact(dateLiteral, "d", CultureInfo.CreateSpecificCulture("en-US"));

            Assert.AreEqual(date.ToString("d", CultureInfo.CreateSpecificCulture("en-US")), dateLiteral);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void WhenUsingFormatSpecifierAndWrongCulture_ThenThrowsException()
        {
            var dateLiteral = "8/24/2017";
            DateTime.ParseExact(dateLiteral, "d", CultureInfo.CreateSpecificCulture("ja-JP"));
        }

        [TestMethod]
        public void WhenUsingLongDateStandardFormat_ThenOutputChangesAccordingToCulture()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24);
            Console.WriteLine(datetime.ToString("D", CultureInfo.CreateSpecificCulture("en-US"))); // Thursday, August 24, 2017
            Console.WriteLine(datetime.ToString("D", CultureInfo.CreateSpecificCulture("es-ES"))); // jueves, 24 de agosto de 2017
            Console.WriteLine(datetime.ToString("D", CultureInfo.CreateSpecificCulture("de-DE"))); // Donnerstag, 24. August 2017

            Assert.AreEqual($"Thursday, August 24, 2017{Environment.NewLine}" +
                                $"jueves, 24 de agosto de 2017{Environment.NewLine}" +
                                $"Donnerstag, 24. August 2017{Environment.NewLine}", sw.ToString());
        }
    }
}
