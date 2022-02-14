using System;

namespace ActionAndFuncDelegates.Actions
{
    class OneParameterAction
    {
        public static void Test()
        {
            Action<string> saySomethingAction = SaySomething;
            saySomethingAction("Hello World! It's a log from an Action!'");
        }

        static void SaySomething(string message)
        {
            Console.WriteLine(message);
        }
    }
}
