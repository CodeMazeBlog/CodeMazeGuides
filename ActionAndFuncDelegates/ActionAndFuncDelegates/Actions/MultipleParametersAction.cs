using System;

namespace ActionAndFuncDelegates.Actions
{
    class MultipleParametersAction
    {
        public static void Test()
        {
            Action<int, int> addAction = Add;
            addAction(1, 2);
        }

        static void Add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }
}
