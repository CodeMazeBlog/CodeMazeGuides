using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableTypesInCSharp
{ 
    internal class UsingComparisonOperators
    {
        public static void Run()
        {
            int? countOne = null;
            int? countTwo = null;

            bool areEqual = countOne > countTwo; //false
            bool areEqualTwo = countOne < countTwo; //false

            int? countThree = 12;
            int? countFour = 14;

            bool areEqualThree = countFour > countThree; //true
            Console.WriteLine(areEqualThree);
        }
    }

    internal class UsingNullCoalescingOperator
    {
        public static void Run()
        {
            int? count = null;
            long? id = count ?? 1;

            count ??= 13;
        }
    }
}
