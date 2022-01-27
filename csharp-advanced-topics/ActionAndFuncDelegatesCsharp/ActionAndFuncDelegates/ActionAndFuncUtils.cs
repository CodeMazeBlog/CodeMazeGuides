using System;
using System.Collections.Generic;
namespace ActionAndFuncDelegates
{
    public class ActionAndFuncUtils
    {
        public delegate void SetMessageDelegate(string message);
        public delegate int SumNumbersDelegate(int param1, int param2);
        public static string message = "";

        public static void SetMessage(string messageToAssign)
        {
            message = messageToAssign;
        }

        public static int SumNumbers(int param1, int param2)
        {
            return param1 + param2;
        }

        public static int SumNumbersWithCallback(int param1, int param2, Action<string> callback)
        {
            int sum = param1 + param2;
            callback($"the sum is: {sum}");

            return sum;
        }
    }
}
