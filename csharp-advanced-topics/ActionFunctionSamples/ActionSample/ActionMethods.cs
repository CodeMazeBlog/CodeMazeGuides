using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionSample
{
    public class ActionMethods
    {
        static string defaultName = "World";

        public static void PrintHello()
        {
            Console.WriteLine(string.Format("Hello {0}!", defaultName));
        }

        public void PrintHello(string name)
        {
            Console.WriteLine(string.Format("Hello {0}!", name));
        }

        public static void ShowActionExamples()
        {
            static void PrintHello()
            {
                Console.WriteLine("Hello World!");
            }

            //
            //Defines a few actions
            //

            Action localAction = PrintHello;
            Action<string> anonymousAction = delegate (string name) { Console.WriteLine(string.Format("Hello {0}!", name)); };
            Action staticAction = ActionMethods.PrintHello;

            ActionMethods actionMethods = new ActionMethods();
            Action<string> lambadaAction = (x) => actionMethods.PrintHello(x);

            //
            //Calls defined actions
            //

            localAction();
            anonymousAction("World");
            staticAction();
            lambadaAction("World");
        }
    }
}
