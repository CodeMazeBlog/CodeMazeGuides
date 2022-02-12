using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates  
{ 
    public class Delegates 
    { 
        public delegate string RemoteControl(string button); 
        public static string TurnOff(string b) 
        { 
            // In the example we are going to print a specific 
            // string assuming that it represents the action will be performed
            return "TV is Turned Off"; 
        }
        public static string TurnOn(string b)
        {
            return "TV is Turned On";
        }
   
        static void Main(string[] args) 
        { 
            RemoteControl rcDelegate1 = new RemoteControl(Delegates.TurnOff); 
            Console.WriteLine(rcDelegate1("Shut down Button")); 

            RemoteControl rcDelegate2 = new RemoteControl(Delegates.TurnOn); 
            Console.WriteLine(rcDelegate2("Power On Button")); 

            Console.ReadKey();
        }
    } 
}