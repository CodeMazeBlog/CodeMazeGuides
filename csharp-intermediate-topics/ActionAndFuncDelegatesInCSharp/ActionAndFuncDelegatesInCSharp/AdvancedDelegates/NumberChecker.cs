using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ActionAndFuncDelegatesInCSharp.AdvancedDelegates
{
    public class NumberChecker
    {
        public List<int> EvenNumbers { get; }

        public NumberChecker()
        {
            EvenNumbers = new List<int>();
        }

        public void Add(int number)
        {
            if (isEvenNumber(number))
                EvenNumbers.Add(number);
        }

        public void Add(List<int> numbers, Predicate<int> evenNumberPredicate)
        {
            if (EvenNumbers.Any())
                EvenNumbers.Clear();

            foreach (var num in numbers)
            {
                if (evenNumberPredicate(num))
                    EvenNumbers.Add(num);
            }
        }

        public bool isEvenNumber(int num) => (num % 2 == 0);

    }
}
