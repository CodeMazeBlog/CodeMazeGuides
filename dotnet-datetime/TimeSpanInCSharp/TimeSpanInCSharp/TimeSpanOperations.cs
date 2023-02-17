namespace TimeSpanInCSharp
{
    public class TimeSpanOperations
    {
        public TimeSpan AddTimeSpans(TimeSpan firstTimeSpan, TimeSpan secondTimeSpan) 
        {
            return firstTimeSpan.Add(secondTimeSpan);
        }

        public int CompareTimeSpans(TimeSpan firstTimeSpan, TimeSpan secondTimeSpan)
        {
            return TimeSpan.Compare(firstTimeSpan, secondTimeSpan);
        }

        public int CompareToTimeSpans(TimeSpan firstTimeSpan, TimeSpan secondTimeSpan)
        {
            return firstTimeSpan.CompareTo(secondTimeSpan);
        }

        public double DivideTwoTimeSpans(TimeSpan firstTimeSpan, TimeSpan secondTimeSpan) 
        {
            return firstTimeSpan.Divide(secondTimeSpan);
        }

        public TimeSpan DivideTimeSpanWithDivisor(TimeSpan firstTimeSpan, int divisor) 
        {
            return firstTimeSpan.Divide(divisor);
        }

        public TimeSpan MultiplyTimeSpan(TimeSpan firstTimeSpan, double factor) 
        {
            return firstTimeSpan.Multiply(factor);
        }

        public TimeSpan SubtractTimeSpan(TimeSpan firstTimeSpan, TimeSpan secondTimeSpan)
        {
            return firstTimeSpan.Subtract(secondTimeSpan);
        }

        public string TimeSpanToString(TimeSpan firstTimeSpan)
        {
            return firstTimeSpan.ToString();
        }

        public TimeSpan TimeSpanToDuration(TimeSpan firstTimeSpan)
        {
            return firstTimeSpan.Duration();
        }

        public TimeSpan NegateTimeSpan(TimeSpan firstTimeSpan)
        {
            return firstTimeSpan.Negate();
        }
    }
}
