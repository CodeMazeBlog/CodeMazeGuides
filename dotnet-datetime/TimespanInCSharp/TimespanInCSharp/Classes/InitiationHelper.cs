using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TimespanInCSharp.Classes.Variables;

namespace TimespanInCSharp.Classes
{
    public class InitiationHelper
    {
        public TimeSpan InitiateTimespan(int TimeValue, TimePart TimePartVal)
        {
            TimeSpan duration;
            switch (TimePartVal)
            {
                case TimePart.Day:
                    duration = TimeSpan.FromDays(TimeValue);
                    break;
                case TimePart.Hour:
                    duration = TimeSpan.FromHours(TimeValue);
                    break;
                case TimePart.Minute:
                    duration = TimeSpan.FromMinutes(TimeValue);
                    break;
                case TimePart.Second:
                    duration = TimeSpan.FromSeconds(TimeValue);
                    break;
                case TimePart.MilliSecond:
                    duration = TimeSpan.FromMilliseconds(TimeValue);
                    break;
                default:
                    duration = TimeSpan.FromTicks(TimeValue);
                    break;
            }
            return duration;
        }

        public TimeSpan InitiateTimespan(int Hour, int Minute, int Second)
        {
            TimeSpan duration = new TimeSpan(Hour, Minute, Second);
            return duration;
        }

        public TimeSpan InitiateTimespan(int Day, int Hour, int Minute, int Second)
        {
            TimeSpan duration = new TimeSpan(Day, Hour, Minute, Second);
            return duration;
        }

        public TimeSpan InitiateTimespan(int Day, int Hour, int Minute, int Second, int Millisecond)
        {
            TimeSpan duration = new TimeSpan(Day, Hour, Minute, Second, Millisecond);
            return duration;
        }

        public TimeSpan InitiateTimespan(int Ticks)
        {
            TimeSpan duration = new TimeSpan(Ticks);
            return duration;
        }

        public TimeSpan InitiateTimespan(DateTime StartDate, DateTime EndDate)
        {
            TimeSpan duration = EndDate - StartDate;
            return duration;
        }
    }
}
