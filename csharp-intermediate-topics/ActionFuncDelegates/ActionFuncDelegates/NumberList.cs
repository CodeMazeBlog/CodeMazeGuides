using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegates
{
    public class NumberList
    {
        Action<int> firstNumber;
        Func<int, int, int> secondNumber;
        public List<int> NumberLists { get; set; }

        public NumberList()
        {
            NumberLists = new List<int>();
            firstNumber = AddNumberToListForAction;
            secondNumber = AddNumbersToListForFunc;
        }

        public void AddNumberUsingAction(int number)
        {
            firstNumber(number);
        }

        public void AddNumbersUsingFunc(int number1, int number2)
        {
            secondNumber(number1, number2);
        }
        public void AddNumberToListForAction(int number)
        {
            NumberLists.Add(number);
        }
        public int AddNumbersToListForFunc(int number1, int number2)
        {
            NumberLists.Add(number1);
            NumberLists.Add(number2);
            return NumberLists[1];
        }
    }
}
