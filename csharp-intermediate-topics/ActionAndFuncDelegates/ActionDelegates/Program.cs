using System;

namespace ActionDelegates
{
    public class Program
    {
        private delegate void SaySomethingDelegate(string message);

        private static void SaySomething(string messageToSay)
        {
            Console.WriteLine(messageToSay);
        }

        static void Main(string[] args)
        {
            Action<string> saySomethingAction = SaySomething;
            saySomethingAction.Invoke("Hi!");
        }
    }
}
