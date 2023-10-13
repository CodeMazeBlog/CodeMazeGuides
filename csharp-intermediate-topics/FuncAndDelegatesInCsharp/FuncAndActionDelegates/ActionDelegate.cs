using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCSharp
{
    public class ActionDelegate
    {
        // Define a method to greet a person
        public static Action<string> greet = (name) => Console.WriteLine($"Hello, {name}!");
 
    }
}
