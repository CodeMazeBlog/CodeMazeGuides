using System;

namespace ActionVsFuncDelegates
{
    internal class Program
    {
        public static void GetCompanyName() {   Console.WriteLine("Code-Maze"); }
        public static void DisplayMessage(string message) { Console.WriteLine(message); }

        static void Main(string[] args)
        {
            #region Action

            // Non-Generic Action delegate
            var doAction = new Action(GetCompanyName);
            doAction();

            // Generic Action delegate
            var display = new Action<string>(DisplayMessage);
            display.Invoke("Code Maze is one of the best Website to read relevant articles.");

            //Action with Anonymous method
            var increaseCount = delegate (int count)
            {
                count++;
                Console.WriteLine("Count = " + count);
            };
            increaseCount.Invoke(5);

            // Action with Lambda Expression
            Action<int> increment = (incrementedN) => incrementedN++;
            increment.Invoke(10);

            #endregion

            #region Func

            //Func with Anonymous method
            Func<byte> getMaxNumber = delegate ()
            {
                byte val1 = 100, val2 = 50;
                return Math.Max(val1, val2);
            };
            Console.WriteLine("Max number: " + getMaxNumber());

            // Func with Lambda Expression
            Func<int, int, int> sum = (x, y) => x + y;
            Console.WriteLine("Sum: " + sum.Invoke(10, 5));
            
            #endregion
        }
    }
}
