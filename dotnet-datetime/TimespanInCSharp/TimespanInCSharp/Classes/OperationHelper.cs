using System.Globalization;
using static TimespanInCSharp.Classes.Variables;

namespace TimespanInCSharp.Classes
{
    public class OperationHelper
    {
        public TimeSpan Operate(TimeSpan timespan1, TimeSpan timespan2, Operation operationType)
        {
            TimeSpan duration;
            switch (operationType)
            {
                case Operation.Add:
                    duration = timespan1.Add(timespan2);
                    break;
                case Operation.Substract:
                    duration = timespan1.Subtract(timespan2);
                    break;
                default:
                    duration = TimeSpan.FromTicks(0);
                    break;
            }
            return duration;
        }

        public TimeSpan Operate(string timespan1, Operation operationType)
        {
            var duration = TimeSpan.FromTicks(0);
            TimeSpan outDuration;
            switch (operationType)
            {
                case Operation.Parse:
                    duration = TimeSpan.Parse(timespan1);
                    break;
                case Operation.ParseExact:
                    duration = TimeSpan.ParseExact(timespan1, "h\\:mm", CultureInfo.CurrentCulture);
                    break;
                case Operation.TryParse:
                    if (TimeSpan.TryParse(timespan1, out outDuration))
                    {
                        duration = outDuration;
                    }
                    break;
                case Operation.TryParseExact:
                    if (TimeSpan.TryParseExact(timespan1, "h\\:mm", CultureInfo.CurrentCulture, out outDuration))
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
