namespace EnumerateAnEnumInCSharp;

public static class Program
{
    public static void Main(string[] args)
    {
        var daysOfWeek = Enum.GetValues(typeof(DayOfWeek));

        foreach (var dayOfWeek in daysOfWeek)
        {
            Console.WriteLine(dayOfWeek);
        }

        foreach (int dayOfWeek in daysOfWeek)
        {
            Console.WriteLine(dayOfWeek);
        }

        foreach (var dayOfWeek in Enum.GetValues<DayOfWeek>())
        {
            Console.WriteLine($"{dayOfWeek} = {(int)dayOfWeek}");
        }

        foreach (var value in Enum.GetValuesAsUnderlyingType<DayOfWeek>())
        {
            Console.WriteLine(value);
        }

        var daysOfWeekReflection = EnumHelper.GetValuesWithReflection<DayOfWeek>();

        foreach (var dayOfWeek in daysOfWeekReflection)
        {
            Console.WriteLine(dayOfWeek);
        }

        Type dayOfWeekEnum = typeof(DayOfWeek);
        var values = dayOfWeekEnum.GetEnumValues();
        foreach (var value in values)
        {
            Console.WriteLine(value);
        }

        var names = dayOfWeekEnum.GetEnumNames();
        foreach (var name in names)
        {
            Console.WriteLine(name);
        }

        foreach (var status in Enum.GetValues<OrderStatus>())
        {
            Console.WriteLine($"{status} = {(int)status}");
        }

        foreach (var name in Enum.GetNames<OrderStatus>())
        {
            Console.WriteLine(name);
        }
    }
}
