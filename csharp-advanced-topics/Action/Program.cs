namespace Action
{
    internal class Program
    {
        public static void birthYear(int currentYear, int currentAge) 
        {
            var result = currentYear - currentAge;
            Console.WriteLine("You were born: " + result); 
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, Let us find out your birth year. From today's date, what year are we in?");
            var currentYear = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How old are you?");
            var currentAge = Convert.ToInt32(Console.ReadLine());

            Action<int, int> calculateBirthYear = birthYear;                       
            calculateBirthYear(currentYear, currentAge);

            Console.ReadLine();
        }

    }
}
