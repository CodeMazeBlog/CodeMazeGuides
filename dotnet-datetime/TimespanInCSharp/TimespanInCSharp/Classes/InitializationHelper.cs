using static TimespanInCSharp.Classes.Variables;

namespace TimespanInCSharp.Classes
{
    public class InitializationHelper
    {
        public TimeSpan InitializeTimespan(int timeValue, TimePart timePartVal)
        {
            TimeSpan duration;
            switch (timePartVal)
            {
                case TimePart.Day:
                    duration = TimeSpan.FromDays(timeValue);
                    break;
                case TimePart.Hour:
                    duration = TimeSpan.FromHours(timeValue);
                    break;
                case TimePart.Minute:
                    duration = TimeSpan.FromMinutes(timeValue);
                    break;
                case TimePart.Second:
                    duration = TimeSpan.FromSeconds(timeValue);
                    break;
                case TimePart.MilliSecond:
                    duration = TimeSpan.FromMilliseconds(timeValue);
                    break;
                default:
                    duration = TimeSpan.FromTicks(timeValue);
                    break;
            }
            return duration;
        }

        public TimeSpan InitializeTimespan(int hour, int minute, int second)
        {
            var duration = new TimeSpan(hour, minute, second);
            return duration;
        }

        public TimeSpan InitializeTimespan(int day, int hour, int minute, int second)
        {
            var duration = new TimeSpan(day, hour, minute, second);
            return duration;
        }

        public TimeSpan InitializeTimespan(int day, int hour, int minute, int second, int millisecond)
        {
            var duration = new TimeSpan(day, hour, minute, second, millisecond);
            return duration;
        }

        public TimeSpan InitializeTimespan(int ticks)
        {
            var duration = new TimeSpan(ticks);
            return duration;
        }

        public TimeSpan InitializeTimespan(DateTime startDate, DateTime endDate)
        {
            var duration = endDate - startDate;
            return duration;
        }
    }
}
