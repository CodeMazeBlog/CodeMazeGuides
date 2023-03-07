using System;

namespace ActionFuncDelegates
{
    public class Solution
    {
        public bool isActionCalled = false;
        public void ActionHandler(int param)
        {
            // Action delegate with named method PrintSomething
            Action<int> myActionDelegate = new Action<int>(PrintSomething);
            myActionDelegate(param);
            // myActionDelegate.Invoke(567);
        }
         void PrintSomething(int i)
        {
            isActionCalled = true; ;
        }

        public int FuncHandler(int param1, int param2)
        {

            Func<int, int, int> myFuncDelegate = new Func<int, int, int>(AddNumbers);
            // Invoking Func delegate
            return myFuncDelegate(param1, param2);


        }
        static int AddNumbers(int i, int j)
        {
            return i + j;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Solution objSol = new Solution();
            objSol.ActionHandler(345);
            Console.WriteLine("Action Called: "+objSol.isActionCalled);
            Console.WriteLine("Addition Works: " + objSol.FuncHandler(456,890));
            Console.WriteLine();
        }       

    
    }

}
