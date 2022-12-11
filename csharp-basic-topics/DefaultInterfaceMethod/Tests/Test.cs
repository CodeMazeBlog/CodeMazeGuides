using DefaultInterfaceMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{

    [TestClass]
    public class Test
    {
        [TestMethod]
        public void WhenCalendarYear_ThenItIsLeap()
        {
            IYearCalendar impl = new MyYearCalendar();
            impl.date = new DateTime(2000, 12, 1);
            Assert.IsTrue(impl.IsLeapYear());
        }
        [TestMethod]
        public void WhenCalendarMonth_ThenItIs31Days()
        {
            IMonthCalendar impl = new MyMonthCalendar();
            impl.date = new DateTime(2000, 12, 1);
            Assert.IsTrue(impl.Is31DaysMonth());
        }

        [TestMethod]
        public void WhenCalendar_ThenDisplayDate()
        {
            var impl = new MyCalendar();
            impl.date = new DateTime(2000, 12, 1);
            Assert.IsTrue(impl is ICalendar);
        }

    }
}
