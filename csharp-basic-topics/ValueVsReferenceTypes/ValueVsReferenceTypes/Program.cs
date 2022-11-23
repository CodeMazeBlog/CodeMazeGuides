using ValueVsReferenceTypes;
class Program
{

    public static void Main()
    {
        WorkingDaysCalculator workingDaysCalculator = new();
        Car car = new();

        CarModel carModel1 = new()
        {
            Model = "Toyota"
        };
        Console.WriteLine(carModel1.Model);
        Console.WriteLine(car.ChangeCarModel(carModel1));
        Console.WriteLine(carModel1.Model);

        int daysInAweek = workingDaysCalculator.DaysOfTheWeek();
        Console.WriteLine(daysInAweek);
        Console.WriteLine(workingDaysCalculator.WeeklyWorkDays());
        Console.WriteLine(daysInAweek);

    }
}
