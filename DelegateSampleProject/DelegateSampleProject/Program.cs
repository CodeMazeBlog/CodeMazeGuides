using static ActionFuncDelegate.NumberAddition;

namespace ActionFuncDelegate
{

    public class NumberAddition
    {
        public delegate int AddNumDelegate(int number1, int number2);
        public int AddWithDelegate(int num1, int num2)
        {
            return num1 + num2;
        }

        public static void AddWithActionDelegate(int number1, int number2)
        {
            Console.WriteLine("Using Action Delegate | Result is {0}", number1 + number2);
        }

        public static int AddWithFuncDelegate(int number1, int number2)
        {
            return number1 + number2;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            //Invoke Delegate
            NumberAddition numberAddition = new NumberAddition();
            AddNumDelegate addNumDelegate = new AddNumDelegate(numberAddition.AddWithDelegate);
            int resultWithDelegate = addNumDelegate(10, 20);
            Console.WriteLine("Using Delegate | Result is {0}", resultWithDelegate);

            //Invoke Action Delegate
            Action<int, int> addNumberActionDelegate = new Action<int, int>(NumberAddition.AddWithActionDelegate);
            addNumberActionDelegate(10, 20);

            //Invoke Func Delegate
            Func<int, int, int> addNumberFuncDelegate = NumberAddition.AddWithFuncDelegate;
            int resultWithFuncDelegate = addNumberFuncDelegate(30, 50);
            Console.WriteLine("Using Func Delegate | Result is {0}", resultWithFuncDelegate);
            Console.ReadLine();
        }
    }
}





