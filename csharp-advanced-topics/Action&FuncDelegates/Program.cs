using System;

namespace Delegates
{
    class Program
    {

        //Declaring method
        public static void CheckIfAdult(int age)
        {
            if (age >= 18)
            {
                Console.WriteLine("User is an Adult");
            }
            else
            {
                Console.WriteLine("User is still a minor");
            }
        }
        public static int AreaSquare(int lenght, int width)
        {
            return lenght * width;
        }
        static public void Main()
        {
            //Declare action delegate
            //instantiate & assign delegate to method
            Action<int> action = CheckIfAdult;
            action(3);
            //Declare func delegate
            //instantiate & assign delegate to method
            Func<int, int, int> func = AreaSquare;

            Console.WriteLine(func(23, 32));
        }
    }
}
