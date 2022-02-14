using System;

namespace ActionAndFuncDelegates.Funcs
{
    class MultipleParametersFunc
    {
        public static void Test()
        {
            Func<float, float, float> divideFunc = Divide;
            float divideResult = divideFunc(3.0f, 2.0f);
            Console.WriteLine(divideResult);
        }

        static float Divide(float param1, float param2)
        {
            return param1 / param2;
        }
    }
}
