using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionInCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DelegateExample delegateExample = new DelegateExample();
            delegateExample.CheckDelegate();

            FuncActionExample funcActionExample = new FuncActionExample();
            funcActionExample.CheckDelegate();


        }
    }
}
