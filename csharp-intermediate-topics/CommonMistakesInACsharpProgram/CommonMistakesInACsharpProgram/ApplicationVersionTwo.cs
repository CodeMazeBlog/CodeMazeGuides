namespace CommonMistakesInACsharpProgram
{
    partial class Application
    {
        public class Complex
        {
            private static int _id;
            Random random = new Random();

            public Complex() => _id = random.Next(200);

            public static bool operator ==(Complex c1, Complex c2) => _id % 2 == 0;

            public static bool operator !=(Complex c1, Complex c2) => _id % 2 == 1;

            public int getId => _id;
        }

        public static void EqualityOperator()
        {
            int value = 0;
            if (value == 1) Console.WriteLine("Hello World");

            Complex complexOne = new();
            Console.WriteLine(complexOne.getId);

            Complex complexTwo = new();
            Console.WriteLine(complexTwo.getId);

            if (complexOne == complexTwo)
            {
                Console.WriteLine("Equal");
            }
        }

        public class DiscardStackTrace
        {
            public static void Main()
            {
                try
                {
                    Run();
                   // ThrowError();
                   // Sum(6, 8);
                }
                catch (Exception ex)
                {
                    throw ex;
                    //throw;
                }

            }

            public static int Sum(int numberOne, int numberTwo) => numberOne + numberTwo;
            public static void ThrowError() => throw new Exception("Custom Error");

            public static void Run()
            {
                Console.WriteLine();
                Sum(6, 8);
                Console.WriteLine($"{Environment.StackTrace}");


                /*
                 Result: 
                 at System.Environment.get_StackTrace()
                 at CommonMistakesInACsharpProgram.Application.DiscardStackTrace.Main() 
                 at Program.<Main>$(String[] args) 
                 */
            }
        }

        public class EmptyCollections
        {
            public static List<int> Main()
            {
                List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                return numbers.Where(x => x % 2 == 0).ToList();

            }

            public static IEnumerable<Person> GetUserByName(string name = null)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return Enumerable.Empty<Person>();
                }
                List<Person> users = new() { new Person { age = 12, name = "John" }, new Person { age = 3, name = "doe" }, };

                return users.Where(x => x.name == name);
            }
        }
    }
}
