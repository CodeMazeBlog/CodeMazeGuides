using System;

namespace DelegateDemo_DemoGate
{
    class Program
    {

        static void Main(string[] args)
        {
            FuncDelegate funcDelegateClass = new FuncDelegate();
            funcDelegateClass.FuncDelegates();

            ActionDelegate actionDelegateClass = new ActionDelegate();
            actionDelegateClass.ActionDelegates();
        }

    }
}
