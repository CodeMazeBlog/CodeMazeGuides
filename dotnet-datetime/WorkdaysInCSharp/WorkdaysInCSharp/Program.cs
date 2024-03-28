using WorkdaysInCSharp;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("""
            Select the example to run
                    1. Calculate business days including public holidays
                    2. Calculate business days excluding business days
                    3. Add business days including public holidays
                    4. Add business days excluding public holidays
                    
            """);
        var selection = Convert.ToInt32(Console.ReadLine());

        switch (selection)
        {
            case 1:
                RunCalculateBusinessDays();
                break;
            case 2:
                await RunCalculateBusinessDaysExcludingHolidaysAsync();
                break;
            case 3:
                RunAddWorkDays();
                break;
            case 4:
                await RunAddWorkDaysExcludingHolidaysAsync();
                break;
            default:
                Console.WriteLine("Invalid input");
                break;
        }

        static void RunCalculateBusinessDays()
        {
            Console.WriteLine("Enter the start date (YYYY-MM-DD): ");
            var firstInput = Console.ReadLine();

            Console.WriteLine("Enter the end date (YYYY-MM-DD): ");
            var secondInput = Console.ReadLine();

            if (DateTime.TryParse(firstInput, out DateTime startDate) && DateTime.TryParse(secondInput, out DateTime endDate))
            {
                var weekDays = WorkdaysInCSharpMethods.CalculateBusinessDays(startDate, endDate);
                Console.WriteLine($"Number of weekdays between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}: {weekDays}");
            }
            else
            {
                Console.WriteLine("Please enter the correct date format.");
            }
        }

        static async Task RunCalculateBusinessDaysExcludingHolidaysAsync()
        {
            Console.WriteLine("Enter the start date (YYYY-MM-DD): ");
            var firstInput = Console.ReadLine();

            Console.WriteLine("Enter the end date (YYYY-MM-DD): ");
            var secondInput = Console.ReadLine();

            Console.WriteLine("Enter the country code e.g. US: ");
            var countryCode = Console.ReadLine();

            if (DateTime.TryParse(firstInput, out DateTime startDate) && DateTime.TryParse(secondInput, out DateTime endDate))
            {
                var weekDays = await WorkdaysInCSharpMethods.CalculateBusinessDaysExcludingHolidaysAsync(startDate, endDate, countryCode);
                Console.WriteLine($"Number of weekdays between {startDate.ToShortDateString()} and {endDate.ToShortDateString()}: {weekDays}");
            }
            else
            {
                Console.WriteLine("Please enter the correct date format.");
            }
        }

        static void RunAddWorkDays()
        {
            Console.WriteLine("Enter the start date (YYYY-MM-DD): ");
            var firstInput = Console.ReadLine();

            Console.WriteLine("Enter the number of days to add: ");
            var workDays = Convert.ToInt32(Console.ReadLine());

            if (DateTime.TryParse(firstInput, out DateTime startDate))
            {
                var endDate = WorkdaysInCSharpMethods.AddWorkDays(startDate, workDays);
                Console.WriteLine($"Adding {workDays} to {startDate.ToShortDateString()} equals {endDate.ToShortDateString()}: ");
            }
            else
            {
                Console.WriteLine("Please enter the correct date format.");
            }
        }

        static async Task RunAddWorkDaysExcludingHolidaysAsync()
        {
            Console.WriteLine("Enter the start date (YYYY-MM-DD): ");
            var firstInput = Console.ReadLine();

            Console.WriteLine("Enter the number of days to add: ");
            var workDays = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the country code e.g. US: ");
            var countryCode = Console.ReadLine();

            if (DateTime.TryParse(firstInput, out DateTime startDate))
            {
                var endDate = await WorkdaysInCSharpMethods.AddWorkDaysExcludingHolidaysAsync(startDate, workDays, countryCode);
                Console.WriteLine($"Adding {workDays} to {startDate.ToShortDateString()} equals {endDate.ToShortDateString()}: ");
            }
            else
            {
                Console.WriteLine("Please enter the correct date format.");
            }
        }
    }
}