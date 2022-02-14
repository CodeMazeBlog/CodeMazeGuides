using System;

namespace ActionAndFuncDelegates.Actions
{
    class ZeroParameterAction
    {
        public static void Test()
        {
            Action helloAction;

            helloAction = SayHello;
            helloAction();
            //helloAction represents any void function without parameter so both SayHello and SayBonjour is acceptable for it
            helloAction = SayBonjour;
            helloAction();
        }

        static void SayHello()
        {
            Console.WriteLine("Hello!");
        }

        static void SayBonjour()
        {
            Console.WriteLine("Bonjour!");
        }
    }
}
