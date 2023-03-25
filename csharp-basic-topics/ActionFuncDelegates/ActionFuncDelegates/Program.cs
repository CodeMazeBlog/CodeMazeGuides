
namespace ActionFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Initialise the delegate
            var myDelegate = new FirstDelegate(CountOne);
            
            Action<string, int> ActionDelegate = TestMethod;
            Func<int, string, string> FuncDelegate = TestFunc;
            
            ActionDelegate("James", 20);
            FuncDelegate(40, "Tomie");

            //It can also be initialised this way
            //FirstDelegate myDelegate = CountOne;

            myDelegate += AddTwo;
            myDelegate += Product;
            myDelegate += (x) => Console.WriteLine(x / 2);

            myDelegate(2);
            myDelegate.Invoke(4);

        }
        public delegate void FirstDelegate(int n);

        public static void CountOne(int number)
        {
            number += 1;
            Console.WriteLine(number);
        }
        public static void AddTwo(int number)
        {
            number = number + 2;
            Console.WriteLine(number);
        }
        public static void Product(int number)
        {
            number = number * 3;
            Console.WriteLine(number);
        }
        public static void TestMethod(string name, int age)
        {
            Console.WriteLine($"{name} is {age} years old");
        }
        public static string TestFunc(int age, string name)
        {
            Console.WriteLine($"{name} is {age} years old");
            return name;
        }
    }
}