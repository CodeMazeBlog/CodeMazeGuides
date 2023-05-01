namespace EnumerateAnEnumInCSharp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var daysOfWeekArray = EnumHelper.GetValues(typeof(DayOfWeek));

            foreach (int dayOfWeek in daysOfWeekArray)
            {
                Console.WriteLine(dayOfWeek);
            }

            var daysOfWeekEnumerable = EnumHelper.GetValues<DayOfWeek>();

            foreach (var dayOfWeek in daysOfWeekEnumerable)
            {
                Console.WriteLine($"{dayOfWeek} = {(int)dayOfWeek}");
            }

            var daysOfWeekReflection = EnumHelper.GetValuesWithReflection<DayOfWeek>();

            foreach (var dayOfWeek in daysOfWeekReflection)
            {
                Console.WriteLine(dayOfWeek);
            }
        }
    }
}