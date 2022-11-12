using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncInCSharp
{
    public class GenericClass
    {
        public void PrintTypeName<T>(T arg)
        {
            Console.WriteLine(arg.GetType().Name);
        }
    }
}
