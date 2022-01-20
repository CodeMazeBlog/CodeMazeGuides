using TimespanInCSharp.Classes;
using static TimespanInCSharp.Classes.Variables;

namespace Application
{
    public class Program
    {
        static string seprator = "---------------------";
        static string newLine = Environment.NewLine;

        public static void Main(string[] args)
        {
            InitiateTimeSpan();
            PropertiesOfTimespan();
            OperationsInTimespan();
        }

        static void InitiateTimeSpan()
        {
            var initHelper = new InitiationHelper();

            Console.WriteLine(string.Concat("Diffrent Ways to Initiate a Timespan Value", newLine, seprator));

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

            TimeSpan hms = initHelper.InitiateTimespan(5, 23, 31);
            Console.WriteLine($"Duration in Hour,Minute,Second: {hms:g}");

            TimeSpan dhms = initHelper.InitiateTimespan(2, 5, 23, 31);
            Console.WriteLine($"Duration in Day,Hour,Minute,Second,Millisecond: {dhms:G}");

            TimeSpan dhmsm = initHelper.InitiateTimespan(2, 5, 23, 31, 532);
            Console.WriteLine($"Duration in Day,Hour,Minute,Second,Millisecond: {dhmsm:G}");

            TimeSpan ticks2 = initHelper.InitiateTimespan(100);
            Console.WriteLine($"Duration in Day,Hour,Minute,Second,Millisecond: {ticks2:G}");

            int year = 2021;
            int month = 12;
            int day = 31;
            int hour = 10;
            int minute = 15;
            int second = 30;
            int millisecond = 731;

            var currentDateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
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

            Console.WriteLine(String.Concat(newLine, "Properties of Timespan Value", newLine, seprator));

            var timespan = new TimeSpan(day, hour, minute, second, millisecond);
            Console.WriteLine($"Total Days: {timespan.TotalDays:N2}, Days: {timespan.Days:N2}");
            Console.WriteLine($"Total Hours: {timespan.TotalHours:N2}, Hours:  {timespan.Hours:N2}");
            Console.WriteLine($"Total Minutes: {timespan.TotalMinutes:N2}, Minutes: {timespan.Minutes:N2}");
            Console.WriteLine($"Total Seconds: {timespan.TotalSeconds:N2}, Seconds: {timespan.Seconds:N2}");
            Console.WriteLine($"Total Milliseconds: {timespan.TotalMilliseconds:N2}, Milliseconds: {timespan.Milliseconds:N2}");
            Console.WriteLine($"Ticks: {timespan.Ticks:N2}");
        }

        private static void OperationsInTimespan()
        {
            var operationHelper = new OperationHelper();

            Console.WriteLine(String.Concat(newLine, "Operations in a Timespan Value", newLine, seprator));

            TimeSpan oprationExampleParse = operationHelper.Operate("01:45:00", Operation.Parse);
            Console.WriteLine($"Timespan.Parse result: {oprationExampleParse.TotalHours:N2}");

            TimeSpan oprationExampleTryParse = operationHelper.Operate("01:30:00", Operation.TryParse);
            Console.WriteLine($"Timespan.TryParse result: {oprationExampleTryParse.TotalHours:N2}");

            TimeSpan oprationExampleParseEx = operationHelper.Operate("01:30", Operation.ParseExact);
            Console.WriteLine($"Timespan.ParseExact result: {oprationExampleParseEx.TotalHours:N2}");

            TimeSpan oprationExampleTryParseEx = operationHelper.Operate("00:45", Operation.TryParseExact);
            Console.WriteLine($"Timespan.TryParseExact result: {oprationExampleTryParseEx.TotalHours:N2}");

            TimeSpan oprationExampleAdd = operationHelper.Operate(oprationExampleParse, oprationExampleTryParse, Operation.Add);
            Console.WriteLine($"Timespan.Add result: {oprationExampleAdd.ToString(@"hh\:mm\:ss")}");

            TimeSpan oprationExampleSub = operationHelper.Operate(oprationExampleParse, oprationExampleTryParse, Operation.Substract);
            Console.WriteLine($"Timespan.Substract result: {oprationExampleSub.ToString(@"hh\:mm\:ss")}");
        }
    }
}
