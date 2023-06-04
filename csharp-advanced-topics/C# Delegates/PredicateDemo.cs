
using System;
namespace DelegatesDemo.DelegateAppl
{
    public class PredicateDemo
    {
        static bool IsLowerCase(string str)
        {
            return str.Equals(str.ToLower());
        }
        public static void RunPredicate()
        {
            Predicate<string> isUpper = IsLowerCase;

            bool result = isUpper("hello world!!");
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
