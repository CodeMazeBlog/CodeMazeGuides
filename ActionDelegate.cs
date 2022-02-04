using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    class ActionDelegate
    {
        static void Main(string[] args)
        {
            Action<string> writeDelegate = Write;
            writeDelegate("Hello World from Delegate..");
            Console.ReadLine();
        }
        public static void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
