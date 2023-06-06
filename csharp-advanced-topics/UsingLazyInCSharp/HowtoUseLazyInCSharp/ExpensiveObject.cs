using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowtoUseLazyInCSharp
{
    public class ExpensiveObject
    {
        public ExpensiveObject()
        {
            //Simulate a time-consuming initialization process
            Console.WriteLine("Initializing the expensive object...");
            Thread.Sleep(3000); // Delay of 3 seconds to simulate initialization
            Console.WriteLine("Expensive object initialization complete.");
        }
        public void PerformAction()
        {
            Console.WriteLine("Performing action with the expensive object.");
        }
    }
}
