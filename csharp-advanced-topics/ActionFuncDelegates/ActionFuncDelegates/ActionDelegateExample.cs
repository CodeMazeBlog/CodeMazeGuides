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
            Action<int> method = PrintCube;

            Process(numbers, method);
        }

        static void PrintCube(int i)
        {
            Console.WriteLine(i * i * i);
        }

        static void Process(List<int> list, Action<int> action)
        {
            foreach (int x in list)
            {
                action(x);
            }
        }
    }
}
