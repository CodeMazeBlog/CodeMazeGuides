using System;
using System.Collections.Generic;
using System.Text;

namespace Action_and_Func_Delegate
{
    public class OperationExecutioner
    {
        private List<int> inputParam;
        private readonly OperationResolver resolver;

        public OperationExecutioner(List<int> input, OperationResolver operationResolver)
        {
            inputParam = input;
            resolver = operationResolver;

        }

        private void Initiate(OperationType operation)
        {
            if (operation == OperationType.TotalCount)
            {
                resolver.IntegrateFuncOperation(TotalCount);
                resolver.IntegrateActionOperation(TotalCount_ForAction);
            }

            if(operation == OperationType.Maximum)
            {
                resolver.IntegrateFuncOperation(Maximum);
                resolver.IntegrateActionOperation(Maximum_ForAction);
            }

            if (operation == OperationType.Minimum)
            {
                resolver.IntegrateFuncOperation(Minimum);
                resolver.IntegrateActionOperation(Minimum_forAction);
            }
        }

        private int TotalCount()
        {
            return inputParam.Count;
        }

        private int Maximum()
        {
            int maximum = inputParam[0];

            for(int i=1; i<inputParam.Count; i++)
            {
                maximum = Math.Max(maximum, inputParam[i]);
            }

            return maximum;
        }

        private int Minimum()
        {
            int minimum = inputParam[0];

            for (int i = 1; i < inputParam.Count; i++)
            {
                minimum = Math.Min(minimum, inputParam[i]);
            }

            return minimum;
        }

        private void Maximum_ForAction()
        {
            int maximum = inputParam[0];

            for (int i = 1; i < inputParam.Count; i++)
            {
                maximum = Math.Max(maximum, inputParam[i]);
            }             

            Console.WriteLine("Maximum number is " + maximum);
        }

        private void Minimum_forAction()
        {
            int minimum = inputParam[0];

            for (int i = 1; i < inputParam.Count; i++)
            {
                minimum = Math.Min(minimum, inputParam[i]);
            }

            Console.WriteLine("Minimum mumber is " + minimum);
        }

        private void TotalCount_ForAction()
        {
            Console.WriteLine("Total Count is"+ inputParam.Count);
        }

        public int Execute(OperationType operation, DelegateType delegateType)
        {
            if (delegateType == DelegateType.Func)
            {
                this.Initiate(operation);
                return resolver.FuncExecute();
            }
            else
            {
                resolver.ActionExecute();
                return 0;
            }
        }
    }

}
