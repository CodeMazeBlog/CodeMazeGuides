namespace ValueVsReferenceTypes
{
    public class WorkingDaysCalculator
    {
        private int weekendDaysCount = 2;

        public int WeeklyWorkDays()
        {
            return DaysOfTheWeek - weekendDaysCount;
        }

        public int DaysOfTheWeek
        {
            get { return 7; }
        }
    }
}