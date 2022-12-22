using NUnit.Framework;
using DefaultInterfaceMethod;

namespace Tests
{
    public class Test
    {
        [Test]
        public void WhenCalendarYear_ThenItIsLeap()
        {
            IYearCalendar impl = new MyYearCalendar();
            impl.Date = new DateTime(2000, 12, 1);

            Assert.IsTrue(impl.IsLeapYear());
        }

        [Test]
        public void WhenCalendarMonth_ThenItIs31Days()
        {
            IMonthCalendar impl = new MyMonthCalendar();
            impl.Date = new DateTime(2000, 12, 1);

            Assert.IsTrue(impl.Is31DaysMonth());
        }

        [Test]
        public void WhenCalendar_ThenDisplayDate()
        {
            var impl = new MyCalendar();
            impl.Date = new DateTime(2000, 12, 1);

            Assert.IsTrue(impl is ICalendar);
        }
    }
}
