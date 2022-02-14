using System;

namespace ActionAndFuncDelegates.Actions
{
    class AnonymousMethodAction
    {
        public static void Test()
        {
            Action<int, int> multiplyWithAnonymous = delegate (int param1, int param2)
            {
                Console.WriteLine(param1 * param2);
            };

            multiplyWithAnonymous(10, 20);
        }
    }
}
