using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    public static class LinqController
    {
        public static Action<string> hello = (name) => Console.WriteLine("Hello " + name);

        public static void SayHello()
        {
            List<string> list = new List<string>() { "Marc", "Jennifer", "Alex" };

            list.ForEach(x => hello(x));
        }
    }
}
