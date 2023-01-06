namespace ValueVsReferenceTypes
{
    public class WorkingDaysCalculator
    {
        public WorkingDaysCalculator() => DaysOfTheWeek = 7;
        public int WeeklyWorkDays(int daysInAWeek)
        {
            daysInAWeek = DaysOfTheWeek - WeekendDaysCount;
            return daysInAWeek;
        }

        public int DaysOfTheWeek { get; set; }

        public int WeekendDaysCount
        {
            get { return 2; }
        }
    }
}