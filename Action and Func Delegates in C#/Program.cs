using System;

namespace Action_and_Func_Delegates_in_C_
{




    public class Program
    {
        public static void Main(string[] args)
        {
           
            ActionDelegateHandler.ActionDelegateExecution();

           
            int result = FuncDelegateHandler.FuncDelegateExecution(5);

            
            Console.WriteLine($"The result of FuncDelegate is: {result}");
        }
    }
}