using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp
{
    public class FuncWithLambdaExpression
    {
        Func<int> generateRandomNumber = () => new Random().Next(1, 100);
        public int RunExample()
        {
            return generateRandomNumber();
        }
    }
}
