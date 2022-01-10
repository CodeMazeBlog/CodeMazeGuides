using System;
using System.Globalization;

namespace Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InitiateTimeSpan();
            PropertiesOfTimespan();
            OperationsInTimespan();
        }
        static void InitiateTimeSpan()
        {
            string Seprator = "---------------------";
            string NewLine = Environment.NewLine;


            Console.WriteLine(string.Concat("Diffrent Ways to Initiate a Timespan Value", NewLine, Seprator));

            TimeSpan dayTimespan = InitiateTimespan(2, TimePart.Day);
            Console.WriteLine("Duration in Days: {0:%d} day(s)", dayTimespan);

            TimeSpan hourTimespan = InitiateTimespan(3, TimePart.Hour);
            Console.WriteLine("Duration in Hours: {0:%h} hour(s)", hourTimespan);

            TimeSpan minuteTimespan = InitiateTimespan(45, TimePart.Minute);
            Console.WriteLine("Duration in Minutes: {0:%m} minute(s)", minuteTimespan);

            TimeSpan secondTimespan = InitiateTimespan(34, TimePart.Second);
            Console.WriteLine("Duration in Seconds: {0:%s} second(s)", secondTimespan);

            TimeSpan millisecondTimespan = InitiateTimespan(1120, TimePart.MilliSecond);
            Console.WriteLine("Duration in Milliseconds: {0:%ffff} millisecond(s)", millisecondTimespan);

            TimeSpan ticksTimespan = InitiateTimespan(50000, TimePart.Ticks);
            Console.WriteLine("Duration in Milliseconds: {0:%ffffffff} millisecond(s)", ticksTimespan);

            TimeSpan HMS = InitiateTimespan(5, 23, 31);
            Console.WriteLine("Duration in Hour,Minute,Second: {0:g}", HMS);

            TimeSpan DHMS = InitiateTimespan(2, 5, 23, 31);
            Console.WriteLine("Duration in Day,Hour,Minute,Second,Millisecond: {0:G}", DHMS);

            TimeSpan DHMSM = InitiateTimespan(2, 5, 23, 31, 532);
            Console.WriteLine("Duration in Day,Hour,Minute,Second,Millisecond: {0:G}", DHMSM);

            TimeSpan ticks2 = InitiateTimespan(100);
            Console.WriteLine("Duration in Day,Hour,Minute,Second,Millisecond: {0:G}", ticks2);

            int year = 2021;
            int month = 12;
            int day = 31;
            int hour = 10;
            int minute = 15;
            int second = 30;
            int millisecond = 731;
            DateTime currentDateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
            TimeSpan diffrence = InitiateTimespan(new DateTime(2021, 1, 1), currentDateTime);
            Console.WriteLine("The number of total days since 01 Jan 2021: {0:N2}", diffrence.TotalDays);
        }
        public static TimeSpan InitiateTimespan(int TimeValue, TimePart TimePartVal)
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
        public static TimeSpan InitiateTimespan(int Hour, int Minute, int Second)
        {
            TimeSpan duration = new TimeSpan(Hour, Minute, Second);
            return duration;
        }
        public static TimeSpan InitiateTimespan(int Day, int Hour, int Minute, int Second)
        {
            TimeSpan duration = new TimeSpan(Day, Hour, Minute, Second);
            return duration;
        }
        public static TimeSpan InitiateTimespan(int Day, int Hour, int Minute, int Second, int Millisecond)
        {
            TimeSpan duration = new TimeSpan(Day, Hour, Minute, Second, Millisecond);
            return duration;
        }
        public static TimeSpan InitiateTimespan(int Ticks)
        {
            TimeSpan duration = new TimeSpan(Ticks);
            return duration;
        }
        public static TimeSpan InitiateTimespan(DateTime StartDate, DateTime EndDate)
        {
            TimeSpan duration = EndDate - StartDate;
            return duration;
        }
        private static void PropertiesOfTimespan()
        {
            string Seprator = "---------------------";
            string NewLine = Environment.NewLine;
            int day = 31;
            int hour = 10;
            int minute = 15;
            int second = 30;
            int millisecond = 731;

            Console.WriteLine(String.Concat(NewLine, "Properties of Timespan Value", NewLine, Seprator));
            TimeSpan timespan = new TimeSpan(day, hour, minute, second, millisecond);
            Console.WriteLine("The number of total days in timespan value: {0:N2}", timespan.TotalDays);
            Console.WriteLine("The number of days in in timespan value: {0:N2}", timespan.Days);
            Console.WriteLine("The number of total hours in timespan value: {0:N2}", timespan.TotalHours);
            Console.WriteLine("The number of hours in in timespan value: {0:N2}", timespan.Hours);
            Console.WriteLine("The number of total minutes in timespan value: {0:N2}", timespan.TotalMinutes);
            Console.WriteLine("The number of minutes in time in timespan value: {0:N2}", timespan.Minutes);
            Console.WriteLine("The number of total seconds in timespan value: {0:N2}", timespan.TotalSeconds);
            Console.WriteLine("The number of seconds in timespan value: {0:N2}", timespan.Seconds);
            Console.WriteLine("The number of total milliseconds in timespan value: {0:N2}", timespan.TotalMilliseconds);
            Console.WriteLine("The number of millisecond in timespan value: {0:N2}", timespan.Milliseconds);
            Console.WriteLine("The number of ticks in timespan value: {0:N2}", timespan.Ticks);
        }
        private static void OperationsInTimespan()
        {
            string Seprator = "---------------------";
            string NewLine = Environment.NewLine;

            Console.WriteLine(String.Concat(NewLine, "Operations in a Timespan Value", NewLine, Seprator));

            TimeSpan OprationExampleParse = Operate("01:45:00", Operation.Parse);
            Console.WriteLine("The number of total hours in timespan value resulted by passing string {0} to Timespan.Parse: {1:N2}", "01:45:00", OprationExampleParse.TotalHours);

            TimeSpan OprationExampleTryParse = Operate("01:30:00", Operation.TryParse);
            Console.WriteLine("The number of total hours in timespan value resulted by passing string {0} to Timespan.TryParse: {1:N2}", "01:30:00", OprationExampleTryParse.TotalHours);

            TimeSpan OprationExampleParseEx = Operate("01:30", Operation.ParseExact);
            Console.WriteLine("The number of total hours in timespan value resulted by passing string {0} to Timespan.ParseExact: {1:N2}", "01:30", OprationExampleParseEx.TotalHours);

            TimeSpan OprationExampleTryParseEx = Operate("00:45", Operation.TryParseExact);
            Console.WriteLine("The number of total hours in timespan value resulted by passing string {0} to Timespan.TryParseExact: {1:N2}", "00:45", OprationExampleTryParseEx.TotalHours);

            TimeSpan OprationExampleAdd = Operate(OprationExampleParse, OprationExampleTryParse, Operation.Add);
            Console.WriteLine("The number of total hours in timespan value resulted by adding timespan values with {0:N2} and {1:N2} hours: {2:N2}", OprationExampleParse.TotalHours, OprationExampleTryParseEx.TotalHours, OprationExampleAdd.TotalHours);

            TimeSpan OprationExampleSub = Operate(OprationExampleParse, OprationExampleTryParse, Operation.Substract);
            Console.WriteLine("The number of total hours in timespan value resulted by adding timespan values with {0:N2} and {1:N2} hours: {2:N2}", OprationExampleParse.TotalHours, OprationExampleTryParseEx.TotalHours, OprationExampleSub.TotalHours);
        }
        public static TimeSpan Operate(TimeSpan Timespan1, TimeSpan Timespan2, Operation OperationType)
        {
            TimeSpan duration;
            switch (OperationType)
            {
                case Operation.Add:
                    duration = Timespan1.Add(TimeSpan.FromTicks(0));
                    break;
                case Operation.Substract:
                    duration = Timespan1.Subtract(TimeSpan.FromTicks(0));
                    break;
                default:
                    duration = TimeSpan.FromTicks(0);
                    break;
            }
            return duration;
        }
        public static TimeSpan Operate(string Timespan1, Operation OperationType)
        {
            TimeSpan duration = TimeSpan.FromTicks(0);
            TimeSpan outDuration;
            switch (OperationType)
            {
                case Operation.Parse:
                    try
                    {
                        duration = TimeSpan.Parse(Timespan1);
                    }
                    catch (FormatException)
                    {
                        duration = TimeSpan.FromTicks(0);
                    }
                    catch (OverflowException)
                    {
                        duration = TimeSpan.FromTicks(0);
                    }
                    break;
                case Operation.ParseExact:
                    try
                    {
                        duration = TimeSpan.ParseExact(Timespan1, "h\\:mm", CultureInfo.CurrentCulture);
                    }
                    catch (FormatException)
                    {
                        duration = TimeSpan.FromTicks(0);
                    }
                    catch (OverflowException)
                    {
                        duration = TimeSpan.FromTicks(0);
                    }
                    break;
                case Operation.TryParse:
                    if (TimeSpan.TryParse(Timespan1, out outDuration))
                    {
                        duration = outDuration;
                    }
                    break;
                case Operation.TryParseExact:
                    if (TimeSpan.TryParseExact(Timespan1, "h\\:mm", CultureInfo.CurrentCulture, out outDuration))
                    {
                        duration = outDuration;
                    }
                    break;
                default:
                    duration = TimeSpan.FromTicks(0);
                    break;
            }
            return duration;
        }
        public enum TimePart
        {
            Day,
            Hour,
            Minute,
            Second,
            MilliSecond,
            Ticks
        }
        public enum Operation
        {
            Add,
            Substract,
            Parse,
            ParseExact,
            TryParse,
            TryParseExact
        }
    }
}

