using ActionAndFuncDelegates.Actions;
using ActionAndFuncDelegates.Funcs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ActionAndFuncDelegates
{
    class Program
    { 
        static void Main(string[] args)
        {
            ZeroParameterAction.Test();
            OneParameterAction.Test();
            MultipleParametersAction.Test();
            LambdaExpressionsAction.Test();
            AnonymousMethodAction.Test();

            ZeroParameterFunc.Test();
            OneParameterFunc.Test();
            MultipleParametersFunc.Test();
            LambdaExpressionsFunc.Test();
            AnonymousMethodFunc.Test();
        }
    }
}
