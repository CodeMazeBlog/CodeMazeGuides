using ValueVsReferenceTypes;
class Program
{
    public static void Main()
    {
        WorkingDaysCalculator workingDaysCalculator = new();

        var daysInAWeek = workingDaysCalculator.DaysOfTheWeek;
        Console.WriteLine($"Days in a week before change is:{daysInAWeek}");
        Console.WriteLine($"Days in a week changed to: {workingDaysCalculator.WeeklyWorkDays(daysInAWeek)}");
        Console.WriteLine($"Days in a week after Change is: {daysInAWeek}");

        var defaultModelName = "Toyota";
        Car car = new(defaultModelName);

        Console.WriteLine($"Model name before changing is: {car.ModelName}");
        var newModelName = "Nissan";
        Console.WriteLine($"Model changed to: {car.ChangeCarModel(newModelName)}");
        Console.WriteLine($"Model name after changing is: {car.ModelName}");
    }
}