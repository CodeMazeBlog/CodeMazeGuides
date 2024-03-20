namespace FuncDelegate
{
    public class Program
    {
        public static int BirthYear(int currentYear, int currentAge)
        {
            return currentYear - currentAge;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Let us find out your birth year. From today's date, what year are we in?");
            var currentYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How old are you?");
            var currentAge = Convert.ToInt32(Console.ReadLine());

            Func<int, int, int> calculateBirthYear = BirthYear;
            
            var result = calculateBirthYear(currentYear, currentAge);
            
            Console.WriteLine("You were born in: " + result);

            Console.ReadLine();
        }
    }
}
