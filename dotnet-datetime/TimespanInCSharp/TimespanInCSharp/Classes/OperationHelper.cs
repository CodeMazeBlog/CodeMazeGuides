using System.Globalization;
using static TimespanInCSharp.Classes.Variables;

namespace TimespanInCSharp.Classes
{
    public class OperationHelper
    {
        public TimeSpan Operate(TimeSpan Timespan1, TimeSpan Timespan2, Operation OperationType)
        {
            TimeSpan duration;
            switch (OperationType)
            {
                case Operation.Add:
                    duration = Timespan1.Add(Timespan2);
                    break;
                case Operation.Substract:
                    duration = Timespan1.Subtract(Timespan2);
                    break;
                default:
                    duration = TimeSpan.FromTicks(0);
                    break;
            }
            return duration;
        }

        public TimeSpan Operate(string Timespan1, Operation OperationType)
        {
            var duration = TimeSpan.FromTicks(0);
            TimeSpan outDuration;
            switch (OperationType)
            {
                case Operation.Parse:
                    duration = TimeSpan.Parse(Timespan1);
                    break;
                case Operation.ParseExact:
                    duration = TimeSpan.ParseExact(Timespan1, "h\\:mm", CultureInfo.CurrentCulture);
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
    }
}
