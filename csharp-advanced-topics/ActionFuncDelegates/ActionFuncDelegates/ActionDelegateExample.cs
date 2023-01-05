using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class ActionDelegateExample
    {
        public static void ActionProgram(List<int> numbers)
        {
            // Define an action delegate that prints the cube number of each given integer.
            Action<int> method = PrintCube;

            // Call the method and pass the list and the action delegate as arguments
            Process(numbers, method);
        }

        static void PrintCube(int i)
        {
            Console.WriteLine(i * i * i);

        }
        static void Process(List<int> list, Action<int> action)
        {
            // Apply the action to each element in the list
            foreach (int x in list)
            {
                action(x);
            }
        }
    }
}
