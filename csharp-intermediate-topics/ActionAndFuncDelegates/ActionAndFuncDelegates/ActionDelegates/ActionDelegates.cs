using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegates
{
    public class ActionDelegates
    {

        public delegate string RemoteControl(string button);
        public static void TurnOff(string b)
        {
            Console.WriteLine("TV is Turned On");
        }
        public static void TurnOn(string b)
        {
            Console.WriteLine("TV is Turned Off");
        }

        static void Main(string[] args)
        {
            Action<string> rcDelegate2 = TurnOff;
            Action<string> rcDelegate1 = TurnOn; 

            rcDelegate1("Power On Button"); 
            rcDelegate2("Shut down Button");
        }
    }
}