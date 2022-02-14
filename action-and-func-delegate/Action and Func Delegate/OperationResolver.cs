using System;
using System.Collections.Generic;
using System.Text;

namespace Action_and_Func_Delegate
{
    public class OperationResolver
    {
        public Func<int> FuncExecute { get; set; }
        public Action ActionExecute { get; set; }

        public OperationResolver()
        {       
        }

        public void IntegrateFuncOperation(Func<int> TotalCount)
        {
            FuncExecute = new Func<int>(TotalCount);
           
        }

        public void IntegrateActionOperation(Action TotalCount)
        {
            ActionExecute = new Action(TotalCount);
        }
    }
}
