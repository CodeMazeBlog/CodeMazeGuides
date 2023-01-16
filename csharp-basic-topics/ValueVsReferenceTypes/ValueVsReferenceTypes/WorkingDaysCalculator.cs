namespace ValueVsReferenceTypes
{
    public class WorkingDaysCalculator
    {
        public int WeeklyWorkDays(int daysInAWeek)
        {
            daysInAWeek = DaysOfTheWeek - WeekendDaysCount;

            return daysInAWeek;
        }

        public int DaysOfTheWeek { get; set; } = 7;

        public static int WeekendDaysCount => 2;
    }
}