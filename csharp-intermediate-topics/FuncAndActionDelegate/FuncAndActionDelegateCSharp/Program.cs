using System;
namespace FuncAndActionDelegateCSharp
{
    

    public class Program
    {
        static void Main(string[] args)
        {
            DelegateClass delegateClass = new DelegateClass();
            Func<string, string> printFuncDel = delegateClass.WelcomeMessageFuncDelegate;
            Console.WriteLine(printFuncDel("Func Delegate"));

            Action<string> printActDel = delegateClass.WelcomeMessageActionDelegate;
            printActDel("Action Delegate");

            Console.ReadLine();
        }
             

    }
    
    public class DelegateClass
    {
        public string Message { get; set; }

        public string WelcomeMessageFuncDelegate(string name)
        {
            return string.Format("Hello {0}", name);
        }

        public void WelcomeMessageActionDelegate(string name)
        {
            Message = string.Format("Hello {0}", name);
            Console.WriteLine(Message);
        }
    }
}