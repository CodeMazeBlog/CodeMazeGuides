using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;

namespace Test
{
    [TestClass]
    public class StandardTimeFormatTests
    {
        [TestMethod]
        public void WhenUsingShortTimeStandardFormat_ThenTimeIsRepresented()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0, DateTimeKind.Utc);
            Console.WriteLine(datetime.ToString("t", CultureInfo.CreateSpecificCulture("en-US"))); // 2:35 PM
            Console.WriteLine(datetime.ToString("t", CultureInfo.CreateSpecificCulture("es-ES"))); // 14:35

            Assert.AreEqual($"2:35 PM{Environment.NewLine}" +
                                $"14:35{Environment.NewLine}", sw.ToString());
        }

        [TestMethod]
        public void WhenUsingLongTimeStandardFormat_ThenTimeIsRepresented()
        {
            var sw = new StringWriter();
            Console.SetOut(sw);

            var datetime = new DateTime(2017, 8, 24, 14, 35, 0, DateTimeKind.Utc);
            Console.WriteLine(datetime.ToString("T", CultureInfo.CreateSpecificCulture("en-US"))); // 2:35:00 PM
            Console.WriteLine(datetime.ToString("T", CultureInfo.CreateSpecificCulture("es-ES"))); // 14:35:00

            Assert.AreEqual($"2:35:00 PM{Environment.NewLine}" +
                                $"14:35:00{Environment.NewLine}", sw.ToString());
        }
    }
}
