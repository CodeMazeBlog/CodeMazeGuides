
using System;
namespace DelegatesDemo.DelegateAppl
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("****** Delegates Demo  ******");
            DelegateDemo delegateDemo = new();
            delegateDemo.RunDelegate();

            Console.WriteLine("****** Funcs Demo  ******");
            FuncDemo funcDemo = new();
            funcDemo.RunFunc();

            Console.WriteLine("****** Actions Demo  ******");
            ActionDemo actionDemo = new();
            actionDemo.RunAction();

            Console.WriteLine("****** Predicates Demo  ******");
            PredicateDemo predicateDemo = new();
            predicateDemo.RunPredicate();
        }
    }
}
