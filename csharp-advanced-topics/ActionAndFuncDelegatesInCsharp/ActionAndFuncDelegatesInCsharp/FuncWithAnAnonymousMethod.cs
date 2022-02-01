using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class FuncWithAnAnonymousMethod
    {
        Func<int> generateRandomNumber = delegate ()
        {
            var rnd = new Random();
            return rnd.Next(1, 100);
        };
        public int RunExample()
        {
            return generateRandomNumber();
        }
    }
}
