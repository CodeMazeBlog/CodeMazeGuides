using System;

namespace ActionAndFuncDelegates.Funcs
{
    class LambdaExpressionsFunc
    {
        public static void Test()
        {
            Func<string, string> firstThreeCharacterFunc = (string input) =>
            {
                return input.Substring(0, 4);
            };

            string firstThreeCharacter = firstThreeCharacterFunc("Funcs can be used with lambda!");
            Console.WriteLine(firstThreeCharacter);
        }
    }
}
