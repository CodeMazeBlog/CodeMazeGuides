
using System;
namespace DelegatesDemo.DelegateAppl
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("****** Delegates Demo  ******");
            DelegateDemo.RunDelegate();
            Console.WriteLine("****** Funcs Demo  ******");
            FuncDemo.RunFunc();
            Console.WriteLine("****** Actions Demo  ******");
            ActionDemo.RunAction();
            Console.WriteLine("****** Predicates Demo  ******");
            PredicateDemo.RunPredicate();
        }
    }
}
