using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class ActionDelegates
    {
  
        public static void Add(int a, int b) 
        { 
            Console.WriteLine("Add Inputs: {0}", a + b); 
        }

        public static void Subtract(int a, int b) 
        { 
            Console.WriteLine("Subtract Inputs: {0}", a - b); 
        }

        public static void ActionDelegate()
        {
            Action<int, int> numbers = Add; 
            numbers(20, 10); // Result: 30 
            numbers = Subtract;
            numbers(20, 10); // Result: 10 
        }

        public static void ActionDelegateWithAnonymous()
        {
            Action<int, int> subtract = delegate (int a, int b) 
            { 
                Console.WriteLine("Subtract = {0}", a - b); 
            }; 
            subtract(30, 10); //Result: 20
        }

        public static void ActionDelegateWithLambda()
        {
            Action<int, int> result = (x, y) => 
            { 
                Console.WriteLine("Result: {0}", x - y); 
            
            }; 
            result(50, 40); // Result: 10
        }
    }
} 
