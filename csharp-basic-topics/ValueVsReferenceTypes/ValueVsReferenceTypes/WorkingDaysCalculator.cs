namespace ValueVsReferenceTypes
{
    public class WorkingDaysCalculator
    {
        protected int weekendDaysCount = 2;

        public int WeeklyWorkDays()
        {
            return (DaysOfTheWeek() - weekendDaysCount);
        }

        public int DaysOfTheWeek()
        {
            return 7;
        }
    }
}
