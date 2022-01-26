using System;

namespace ActionAndFuncDelegateTutorial
{
    public delegate void MyFirstDelegate(int number, string message);

    public static class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> areaOfRectangle = AreaOfRectangle;
            Console.WriteLine("The area of the rectangle is: " + areaOfRectangle(10, 15));

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


