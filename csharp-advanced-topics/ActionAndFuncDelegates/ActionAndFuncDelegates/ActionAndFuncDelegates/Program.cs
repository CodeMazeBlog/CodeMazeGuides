using System;
using System.Collections.Generic;
using static ActionAndFuncDelegates.ActionDelegateExample;
using static ActionAndFuncDelegates.FuncDelegateExample;

namespace ActionAndFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Action Delegate
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            ActionProgram(numbers);
                      
            //Func Delegate
            string sentence = "Sentence example";

            FuncProgram(sentence);
        }
    }
}
