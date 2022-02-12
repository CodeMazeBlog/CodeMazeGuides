using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegates
{
    public class FuncDelegates
    {

        public delegate string RemoteControl(string button);
        public static string TurnOff(string b)
        {
            return "TV is Turned Off";
        }
        public static string TurnOn(string b)
        {
            return "TV is Turned On";
        }

        static void Main(string[] args)
        {
            Func<string, string> rcDelegate2 = TurnOff; 
            Func<string, string> rcDelegate1 = TurnOn; 
            
            string result1 = rcDelegate1("Power On Button"); 
            string result2 = rcDelegate2("Shut down Button"); 
            
            Console.WriteLine(result1); 
            Console.WriteLine(result2);
        }
    }
}