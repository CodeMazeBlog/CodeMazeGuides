namespace ActionAndFuncDelegatesInCsharp
{
    public class AgeCalculatorClass
    {
        static void Main(string[] args)
        {

            //ACTION DELEGETES

            Action<int> printAge = (age) => Console.WriteLine($"Age is: {age}");
            printAge(20);  // Output -  Age is: 20

            Action<int, string> ageAndName = PrintNameAndAge;
            ageAndName(20, "John Doe"); //Output - Hello John Doe, your age is 20


            //FUNC DELEGATES

            Func<int, int> calculateAge = AgeCalculator;
            int age = calculateAge(2000);
            Console.WriteLine($"Age is: {age}"); // Output - Age is: 23

            Func<int, int, int> calculateAverageAge = (int birthYear, int birthYear2) =>
            {
                int currentYear = DateTime.Now.Year;
                int ageOne = currentYear - birthYear;
                int ageTwo = currentYear - birthYear2;
                return (ageOne + ageTwo) / 2;

            };
            int averageAge = calculateAverageAge(2000, 2010);
            Console.WriteLine("Average age: " + averageAge); // Output - Average age: 18



        }

        public static void PrintNameAndAge(int age, string name)
        {
            Console.WriteLine($"Hello {name}, your age is {age}");
        }

        public static int AgeCalculator(int birthYear)
        {
            int currentYear = DateTime.Now.Year;
            return currentYear - birthYear;
        }
    }
}