using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class CustomDelegates
    {
        public delegate void VoidDelegate(string input);
        public delegate int ReturnDelegate(int input);

        public VoidDelegate DisplayMessage = (input) => Console.WriteLine(input);
        public ReturnDelegate ReturnValue = (input) => input * input;
    }
}
