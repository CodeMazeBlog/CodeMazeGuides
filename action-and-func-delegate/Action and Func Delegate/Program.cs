using System;
using System.Collections.Generic;

namespace Action_and_Func_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = new OperationResolver();
            List<int> input = new List<int> { 1, 5, 8, 13 };
            var executioner = new OperationExecutioner(input, resolver);

            //Func Delegate
            int result = executioner.Execute(OperationType.Maximum, DelegateType.Func);            
            Console.WriteLine($"{result} is the {OperationType.Maximum.ToString()} number");          
            //end

            //Action Delegate
            executioner.Execute(OperationType.Maximum, DelegateType.Action);
            //end
        }

    }
}
