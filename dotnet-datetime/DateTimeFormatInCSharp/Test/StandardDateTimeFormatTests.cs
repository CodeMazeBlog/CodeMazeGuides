using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;

namespace Test
{
    [TestClass]
    public class StandardDateTimeFormatTests
    {
        [TestMethod]
        public void WhenUsingFullDateShortTimeStandardFormat_ThenOutputChangesAccordingToCulture()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0);
            Console.WriteLine(datetime.ToString("f", CultureInfo.CreateSpecificCulture("en-US"))); // Thursday, August 24, 2017 2:35 PM
            Console.WriteLine(datetime.ToString("f", CultureInfo.CreateSpecificCulture("es-ES"))); // jueves, 24 de agosto de 2017 14:35
            Console.WriteLine(datetime.ToString("f", CultureInfo.CreateSpecificCulture("de-DE"))); // Donnerstag, 24. August 2017 14:35

            Assert.AreEqual($"Thursday, August 24, 2017 2:35 PM{Environment.NewLine}" +
                                $"jueves, 24 de agosto de 2017 14:35{Environment.NewLine}" +
                                $"Donnerstag, 24. August 2017 14:35{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingFullDateLongTimeStandardFormat_ThenOutputChangesAccordingToCulture()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0);
            Console.WriteLine(datetime.ToString("F", CultureInfo.CreateSpecificCulture("en-US"))); // Thursday, August 24, 2017 2:35:00 PM
            Console.WriteLine(datetime.ToString("F", CultureInfo.CreateSpecificCulture("es-ES"))); // jueves, 24 de agosto de 2017 14:35:00
            Console.WriteLine(datetime.ToString("F", CultureInfo.CreateSpecificCulture("de-DE"))); // Donnerstag, 24. August 2017 14:35:00

            Assert.AreEqual($"Thursday, August 24, 2017 2:35:00 PM{Environment.NewLine}" +
                                $"jueves, 24 de agosto de 2017 14:35:00{Environment.NewLine}" +
                                $"Donnerstag, 24. August 2017 14:35:00{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingGeneralDateShortTimeStandardFormat_ThenOutputChangesAccordingToCulture()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0);
            Console.WriteLine(datetime.ToString("g", CultureInfo.CreateSpecificCulture("en-US"))); // 8/24/2017 2:35 PM
            Console.WriteLine(datetime.ToString("g", CultureInfo.CreateSpecificCulture("es-ES"))); // 24/8/2017 14:35
            Console.WriteLine(datetime.ToString("g", CultureInfo.CreateSpecificCulture("de-DE"))); // 24.08.2017 14:35

            Assert.AreEqual($"8/24/2017 2:35 PM{Environment.NewLine}" +
                                $"24/8/2017 14:35{Environment.NewLine}" +
                                $"24.08.2017 14:35{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingGeneralDateLongTimeStandardFormat_ThenOutputChangesAccordingToCulture()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0);
            Console.WriteLine(datetime.ToString("G", CultureInfo.CreateSpecificCulture("en-US"))); // 8/24/2017 2:35:00 PM
            Console.WriteLine(datetime.ToString("G", CultureInfo.CreateSpecificCulture("es-ES"))); // 24/8/2017 14:35:00
            Console.WriteLine(datetime.ToString("G", CultureInfo.CreateSpecificCulture("de-DE"))); // 24.08.2017 14:35:00

            Assert.AreEqual($"8/24/2017 2:35:00 PM{Environment.NewLine}" +
                                $"24/8/2017 14:35:00{Environment.NewLine}" +
                                $"24.08.2017 14:35:00{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenRoundTripStandardFormat_ThenTimeZoneIsPreserved()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var dateTimeUtc = new DateTime(2017, 8, 24, 14, 35, 0, DateTimeKind.Utc);
            Console.WriteLine(dateTimeUtc.ToString("O")); // 2017-08-24T14:35:00.0000000Z
            
            var dateTimeOffset = new DateTimeOffset(2017, 8, 24, 14, 35, 0, TimeSpan.FromHours(2));
            Console.WriteLine(dateTimeOffset.ToString("O")); // 2017-08-24T14:35:00.0000000+02:00

            Assert.AreEqual($"2017-08-24T14:35:00.0000000Z{Environment.NewLine}" +
                                $"2017-08-24T14:35:00.0000000+02:00{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingRfc1123StandardFormat_ThenUtcDateTimeMustBeUsed()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0, DateTimeKind.Unspecified);
            Console.WriteLine(datetime.ToUniversalTime().ToString("R")); // Thu, 24 Aug 2017 14:35:00 GMT

            var datetimeOffset = new DateTimeOffset(2017, 8, 24, 14, 35, 0, TimeSpan.FromHours(2));
            Console.WriteLine(datetimeOffset.ToString("R")); // Thu, 24 Aug 2017 12:35:00 GMT

            Assert.AreEqual($"Thu, 24 Aug 2017 14:35:00 GMT{Environment.NewLine}" +
                                $"Thu, 24 Aug 2017 12:35:00 GMT{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingSortableStandardFormat_ThenTimeZoneIsntPreserved()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0);
            Console.WriteLine(datetime.ToString("s")); // 2017-08-24T14:35:00

            Assert.AreEqual($"2017-08-24T14:35:00{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingUniversalSortableStandardFormat_ThenUtcTimeIsRepresented()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0);
            Console.WriteLine(datetime.ToUniversalTime().ToString("u")); // 2017-08-24 14:35:00Z

            Assert.AreEqual($"2017-08-24 14:35:00Z{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingUniversalFullFormatStandardFormat_ThenUtcTimeIsRepresented()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0, DateTimeKind.Utc);
            Console.WriteLine(datetime.ToUniversalTime().ToString("U", CultureInfo.CreateSpecificCulture("en-US"))); // Thursday, August 24, 2017 2:35:00 PM
            Console.WriteLine(datetime.ToUniversalTime().ToString("U", CultureInfo.CreateSpecificCulture("es-ES"))); // jueves, 24 de agosto de 2017 14:35:00

            Assert.AreEqual($"Thursday, August 24, 2017 2:35:00 PM{Environment.NewLine}" +
                                $"jueves, 24 de agosto de 2017 14:35:00{Environment.NewLine}", sw.ToString());
        }
    }
}
