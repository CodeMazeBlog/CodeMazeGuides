using static ActionFuncDelegate.NumberAddition;

namespace ActionFuncDelegate
{

    public class NumberAddition
    {
        /// <summary>
        /// A Delegate that takes 2 input parameters
        /// </summary>
        /// <param name="number1">Parameter1 is an integere and name of parameter is number1</param>
        /// <param name="number2">Parameter1 is an integere and name of parameter is number2</param>
        /// <returns>It return and integer value</returns>
        public delegate int AddNumDelegate(int number1, int number2);
        public int AddWithDelegate(int num1, int num2)
        {
            return num1 + num2;
        }

        /// <summary>
        /// An Action Delegate that takes 2 input parameters
        /// </summary>
        /// <param name="number1">Parameter1 is an integere and name of parameter is number1</param>
        /// <param name="number2">Parameter1 is an integere and name of parameter is number2</param>
        public static void AddWithActionDelegate(int number1, int number2)
        {
            Console.WriteLine("Using Action Delegate | Result is {0}", number1 + number2);
        }

        /// <summary>
        /// Func Delegate that takes 2 input parameters
        /// </summary>
        /// <param name="number1">Parameter1 is an integere and name of parameter is number1</param>
        /// <param name="number2">Parameter1 is an integere and name of parameter is number2</param>
        /// <returns>It return and integer value</returns>
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
            var numberAddition = new NumberAddition();
            var addNumDelegate = new AddNumDelegate(numberAddition.AddWithDelegate);
            var resultWithDelegate = addNumDelegate(10, 20);
            Console.WriteLine("Using Delegate | Result is {0}", resultWithDelegate);

            //Invoke Action Delegate
            Action<int, int> addNumberActionDelegate = new Action<int, int>(NumberAddition.AddWithActionDelegate);
            addNumberActionDelegate(10, 20);

            //Invoke Func Delegate
            Func<int, int, int> addNumberFuncDelegate = NumberAddition.AddWithFuncDelegate;
            var resultWithFuncDelegate = addNumberFuncDelegate(30, 50);
            Console.WriteLine("Using Func Delegate | Result is {0}", resultWithFuncDelegate);
            Console.ReadLine();
        }
    }
}





