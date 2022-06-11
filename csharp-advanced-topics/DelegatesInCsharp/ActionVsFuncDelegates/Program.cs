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
            Action DoAction = new Action(GetCompanyName);
            DoAction();

            // Generic Action delegate
            Action<string> Display = new Action<string>(DisplayMessage);
            Display.Invoke("Code Maze is one of the best Website to read relevant articles.");

            //Action with Anonymous method
            Action<int> IncreaseCount = delegate (int count)
            {
                count++;
                Console.WriteLine("Count = " + count);
            };
            IncreaseCount.Invoke(5);

            // Action with Lambda Expression
            Action<int> Increment = (incrementedN) => incrementedN++;
            Increment.Invoke(10);

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
            Func<int, int, int> Sum = (x, y) => x + y;
            Console.WriteLine("Sum: " + Sum.Invoke(10, 5));
            
            #endregion
        }
    }
}
