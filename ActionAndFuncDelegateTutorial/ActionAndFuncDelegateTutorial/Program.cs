using System;

namespace ActionAndFuncDelegateTutorial
{
    public delegate void MyFirstDelegate(int number, string message);

    public delegate T Func<in U, out T>(U arg);

    public delegate void Action<in U>(U arg);
    class Program
    {
        static void Main(string[] args)
        {
            // We are using the Func delegate here
            // It contains the two input parameters of length and breath and the third is the result.
            Func<int, int, int> areaOfRectangle = AreaOfRectangle;
            Console.WriteLine("The area of the rectangle is: " + areaOfRectangle(10, 15));

            // We are using an Action delegate here
            // It takes a single input parameter and returns void.
            Action<string> welcomeUser = WelcomeUser;
            welcomeUser("Chizoba");
        }

        public static int AreaOfRectangle(int length, int breath)
        {
            return length * breath;
        }

        public static void WelcomeUser(string name)
        {
            Console.WriteLine("Hello " + name + " how are you doing today?");
        }
    }
}
