using System;
using System.Globalization;
using TimespanInCSharp.Classes;
using static TimespanInCSharp.Classes.Variables;

namespace Application
{
    public class Program
    {
        static string Seprator = "---------------------";
        static string NewLine = Environment.NewLine;
        public static void Main(string[] args)
        {
            InitiateTimeSpan();
            PropertiesOfTimespan();
            OperationsInTimespan();
        }

        static void InitiateTimeSpan()
        {
            InitiationHelper initHelper = new InitiationHelper();

            Console.WriteLine(string.Concat("Diffrent Ways to Initiate a Timespan Value", NewLine, Seprator));

            TimeSpan dayTimespan = initHelper.InitiateTimespan(2, TimePart.Day);
            Console.WriteLine($"Duration in Days: {dayTimespan:%d} day(s)");

            TimeSpan hourTimespan = initHelper.InitiateTimespan(3, TimePart.Hour);
            Console.WriteLine($"Duration in Hours: {hourTimespan:%h} hour(s)");

            TimeSpan minuteTimespan = initHelper.InitiateTimespan(45, TimePart.Minute);
            Console.WriteLine($"Duration in Minutes: {minuteTimespan:%m} minute(s)");

            TimeSpan secondTimespan = initHelper.InitiateTimespan(34, TimePart.Second);
            Console.WriteLine($"Duration in Seconds: {secondTimespan:%s} second(s)");

            TimeSpan millisecondTimespan = initHelper.InitiateTimespan(1120, TimePart.MilliSecond);
            Console.WriteLine($"Duration in Milliseconds: {millisecondTimespan:%ffff} millisecond(s)");

            TimeSpan ticksTimespan = initHelper.InitiateTimespan(50000, TimePart.Ticks);
            Console.WriteLine($"Duration in Milliseconds: {ticksTimespan:%ffffffff} millisecond(s)");

            TimeSpan HMS = initHelper.InitiateTimespan(5, 23, 31);
            Console.WriteLine($"Duration in Hour,Minute,Second: {HMS:g}");

            TimeSpan DHMS = initHelper.InitiateTimespan(2, 5, 23, 31);
            Console.WriteLine($"Duration in Day,Hour,Minute,Second,Millisecond: {DHMS:G}");

            TimeSpan DHMSM = initHelper.InitiateTimespan(2, 5, 23, 31, 532);
            Console.WriteLine($"Duration in Day,Hour,Minute,Second,Millisecond: {DHMSM:G}");

            TimeSpan ticks2 = initHelper.InitiateTimespan(100);
            Console.WriteLine($"Duration in Day,Hour,Minute,Second,Millisecond: {ticks2:G}");

            int year = 2021;
            int month = 12;
            int day = 31;
            int hour = 10;
            int minute = 15;
            int second = 30;
            int millisecond = 731;
            DateTime currentDateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
            TimeSpan diffrence = initHelper.InitiateTimespan(new DateTime(2021, 1, 1), currentDateTime);
            Console.WriteLine($"The number of total days since 01 Jan 2021: {diffrence.TotalDays:N2}");
        }

        private static void PropertiesOfTimespan()
        {
            int day = 31;
            int hour = 10;
            int minute = 15;
            int second = 30;
            int millisecond = 731;

            Console.WriteLine(String.Concat(NewLine, "Properties of Timespan Value", NewLine, Seprator));
            TimeSpan timespan = new TimeSpan(day, hour, minute, second, millisecond);
            Console.WriteLine($"The number of total days in timespan value: {timespan.TotalDays:N2}");
            Console.WriteLine($"The number of days in in timespan value: {timespan.Days:N2}");
            Console.WriteLine($"The number of total hours in timespan value: {timespan.TotalHours:N2}");
            Console.WriteLine($"The number of hours in in timespan value: {timespan.Hours:N2}");
            Console.WriteLine($"The number of total minutes in timespan value: {timespan.TotalMinutes:N2}");
            Console.WriteLine($"The number of minutes in time in timespan value: {timespan.Minutes:N2}");
            Console.WriteLine($"The number of total seconds in timespan value: {timespan.TotalSeconds:N2}");
            Console.WriteLine($"The number of seconds in timespan value: {timespan.Seconds:N2}");
            Console.WriteLine($"The number of total milliseconds in timespan value: {timespan.TotalMilliseconds:N2}");
            Console.WriteLine($"The number of millisecond in timespan value: {timespan.Milliseconds:N2}");
            Console.WriteLine($"The number of ticks in timespan value: {timespan.Ticks:N2}");
        }

        private static void OperationsInTimespan()
        {
            OperationHelper operationHelper = new OperationHelper();

            Console.WriteLine(String.Concat(NewLine, "Operations in a Timespan Value", NewLine, Seprator));

            TimeSpan OprationExampleParse = operationHelper.Operate("01:45:00", Operation.Parse);
            Console.WriteLine($"The number of total hours in timespan value resulted by passing string 01:45:00 to Timespan.Parse: {OprationExampleParse.TotalHours:N2}");

            TimeSpan OprationExampleTryParse = operationHelper.Operate("01:30:00", Operation.TryParse);
            Console.WriteLine($"The number of total hours in timespan value resulted by passing string 01:30:00 to Timespan.TryParse: {OprationExampleTryParse.TotalHours:N2}");

            TimeSpan OprationExampleParseEx = operationHelper.Operate("01:30", Operation.ParseExact);
            Console.WriteLine($"The number of total hours in timespan value resulted by passing string 01:30 to Timespan.ParseExact: {OprationExampleParseEx.TotalHours:N2}");

            TimeSpan OprationExampleTryParseEx = operationHelper.Operate("00:45", Operation.TryParseExact);
            Console.WriteLine($"The number of total hours in timespan value resulted by passing string 00:45 to Timespan.TryParseExact: {OprationExampleTryParseEx.TotalHours:N2}");

            TimeSpan OprationExampleAdd = operationHelper.Operate(OprationExampleParse, OprationExampleTryParse, Operation.Add);
            Console.WriteLine($"The timespan value resulted by adding timespan values with {OprationExampleParse.ToString(@"hh\:mm\:ss")} and {OprationExampleTryParseEx.ToString(@"hh\:mm\:ss")}: {OprationExampleAdd.ToString(@"hh\:mm\:ss")}");

            TimeSpan OprationExampleSub = operationHelper.Operate(OprationExampleParse, OprationExampleTryParse, Operation.Substract);
            Console.WriteLine($"The timespan value resulted by substracting timespan value {OprationExampleTryParse.ToString(@"hh\:mm\:ss")} from {OprationExampleParse.ToString(@"hh\:mm\:ss")}: {OprationExampleSub.ToString(@"hh\:mm\:ss")}");
        }
    }
}

