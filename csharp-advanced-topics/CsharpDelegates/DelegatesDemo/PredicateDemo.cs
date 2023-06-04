using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo
{
    public class PredicateDemo
    {
        public string stringToCheck = "Hello World";
        static bool IsLowerCase(string str)
        {
            return str.Equals(str.ToLower());
        }
        public void RunPredicate()
        {
            Predicate<string> isUpper = IsLowerCase;

            bool result = isUpper(stringToCheck);
            Console.WriteLine(result);
        }
    }
}
