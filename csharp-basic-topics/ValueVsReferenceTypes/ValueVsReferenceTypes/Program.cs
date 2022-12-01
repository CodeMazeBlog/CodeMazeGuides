using ValueVsReferenceTypes;
class Program
{
    public static void Main()
    {
        WorkingDaysCalculator workingDaysCalculator = new();
        Car car = new();

        Console.WriteLine(car.CarModelName);
        Console.WriteLine(car.CarModelName="Nissan");
        Console.WriteLine(car.CarModelName);

        var daysInAWeek = workingDaysCalculator.DaysOfTheWeek;
        Console.WriteLine(daysInAWeek);
        Console.WriteLine(workingDaysCalculator.WeeklyWorkDays());
        Console.WriteLine(daysInAWeek);
    }
}