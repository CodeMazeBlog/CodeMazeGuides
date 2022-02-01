using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class CallingAMethodWithAction
    {
        void sayHi()
        {
            Console.WriteLine("Hi");
        }
        public void RunExample()
        {
            Action sayHiAction = sayHi;
            sayHi();
        }
    }
}
