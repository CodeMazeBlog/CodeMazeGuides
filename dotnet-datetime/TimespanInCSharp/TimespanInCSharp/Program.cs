using TimespanInCSharp.Classes;
using static TimespanInCSharp.Classes.Variables;

namespace Application
{
    public class Program
    {
        static string seprator = "---------------------";
        static string newLine = Environment.NewLine;

        public static void Main()
        {
            InitiateTimeSpan();
            PropertiesOfTimespan();
            OperationsInTimespan();
        }

        static void InitiateTimeSpan()
        {
            var initHelper = new InitializationHelper();

            Console.WriteLine(string.Concat("Diffrent Ways to Initiate a Timespan Value", newLine, seprator));

            var dayTimespan = initHelper.InitializeTimespan(2, TimePart.Day);
            Console.WriteLine($"Duration in Days: {dayTimespan:%d} day(s)");

            var hourTimespan = initHelper.InitializeTimespan(3, TimePart.Hour);
            Console.WriteLine($"Duration in Hours: {hourTimespan:%h} hour(s)");

            var minuteTimespan = initHelper.InitializeTimespan(45, TimePart.Minute);
            Console.WriteLine($"Duration in Minutes: {minuteTimespan:%m} minute(s)");

            var secondTimespan = initHelper.InitializeTimespan(34, TimePart.Second);
            Console.WriteLine($"Duration in Seconds: {secondTimespan:%s} second(s)");

            var millisecondTimespan = initHelper.InitializeTimespan(1120, TimePart.MilliSecond);
            Console.WriteLine($"Duration in Milliseconds: {millisecondTimespan:%ffff} millisecond(s)");

            var ticksTimespan = initHelper.InitializeTimespan(50000, TimePart.Ticks);
            Console.WriteLine($"Duration in Milliseconds: {ticksTimespan:%ffffffff} millisecond(s)");

            var hms = initHelper.InitializeTimespan(5, 23, 31);
            Console.WriteLine($"Duration in Hour,Minute,Second: {hms:g}");

            var dhms = initHelper.InitializeTimespan(2, 5, 23, 31);
            Console.WriteLine($"Duration in Day,Hour,Minute,Second,Millisecond: {dhms:G}");

            var dhmsm = initHelper.InitializeTimespan(2, 5, 23, 31, 532);
            Console.WriteLine($"Duration in Day,Hour,Minute,Second,Millisecond: {dhmsm:G}");

            var ticks2 = initHelper.InitializeTimespan(100);
            Console.WriteLine($"Duration in Day,Hour,Minute,Second,Millisecond: {ticks2:G}");

            var year = 2021;
            var month = 12;
            var day = 31;
            var hour = 10;
            var minute = 15;
            var second = 30;
            var millisecond = 731;

            var currentDateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
            var diffrence = initHelper.InitializeTimespan(new DateTime(2021, 1, 1), currentDateTime);

            Console.WriteLine($"The number of total days since 01 Jan 2021: {diffrence.TotalDays:N2}");
        }

        private static void PropertiesOfTimespan()
        {
            var day = 31;
            var hour = 10;
            var minute = 15;
            var second = 30;
            var millisecond = 731;

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

            var oprationExampleParse = operationHelper.Operate("01:45:00", Operation.Parse);
            Console.WriteLine($"Timespan.Parse result: {oprationExampleParse.TotalHours:N2}");

            var oprationExampleTryParse = operationHelper.Operate("01:30:00", Operation.TryParse);
            Console.WriteLine($"Timespan.TryParse result: {oprationExampleTryParse.TotalHours:N2}");

            var oprationExampleParseEx = operationHelper.Operate("01:30", Operation.ParseExact);
            Console.WriteLine($"Timespan.ParseExact result: {oprationExampleParseEx.TotalHours:N2}");

            var oprationExampleTryParseEx = operationHelper.Operate("00:45", Operation.TryParseExact);
            Console.WriteLine($"Timespan.TryParseExact result: {oprationExampleTryParseEx.TotalHours:N2}");

            var oprationExampleAdd = operationHelper.Operate(oprationExampleParse, oprationExampleTryParse, Operation.Add);
            Console.WriteLine($"Timespan.Add result: {oprationExampleAdd.ToString(@"hh\:mm\:ss")}");

            var oprationExampleSub = operationHelper.Operate(oprationExampleParse, oprationExampleTryParse, Operation.Substract);
            Console.WriteLine($"Timespan.Substract result: {oprationExampleSub.ToString(@"hh\:mm\:ss")}");
        }
    }
}
