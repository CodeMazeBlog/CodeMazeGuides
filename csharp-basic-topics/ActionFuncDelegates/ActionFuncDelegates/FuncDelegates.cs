using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class FuncDelegates
    {
        public static int Add(int x, int y) 
        {
            return (x + y);
        } 

        public static int FuncDelegate() 
        { 
            int result = 0;
            Func<int, int, int> numbers = Add; 
            result = numbers(20, 10); //Result: 30
            Console.WriteLine($"Result:{result}");
            return result;
        }


        public static int FuncDelegateWithAnonymous()
        {
            int result = 0;

            Func<int, int, int> numbers = delegate (int a, int b)
            {
                return a + b;   
            };
            result = numbers(30, 10); //Result: 40
            Console.WriteLine($"Result:{result}");
            return result;
        }

        public static int FuncDelegateWithLambda()
        {
            int result = 0;

            Func<int, int, int> numbers = (x, y) => x + y;
            {
                result = numbers(50, 50); // Result: 100
                Console.WriteLine("Result: {0}", result); 
            };
            return result;
        }
    }
}
