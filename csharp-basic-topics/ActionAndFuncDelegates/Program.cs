using System;
using System.Security.Cryptography.X509Certificates;

namespace CodeMazeGuides.Delegates
{
    class Program
    {
        // class used for Func delegate example
        public class Cake
        {
            public static double CalculateShare(int slices, int share)
            {
                double myCake = slices * (share * 0.01);
                return Math.Round(myCake, 2);
            }

            public static double CalculateRemainingShare (double slices, int guests)
            {
                double remCake = slices / guests;
                return Math.Round(remCake, 2);
            }

        }

        public static void Main()
        {
            // Action delegate - Manipulate string provided
            Action<string, string> ActionStringManipulator = (start, suffix) =>
            {
                Console.WriteLine($"The string reads: {start} {suffix}");
                Console.WriteLine($"The string order inverted reads: {suffix} {start}");
            };

            ActionStringManipulator("I like to eat", "Cake");


            // Func delegate - share cake between guests
            Func<int, int, double> MyShare = Cake.CalculateShare;
            Func<double, int, double> GuestShare = Cake.CalculateRemainingShare;

            Console.WriteLine("My share of cake is 40% of 12 slices.");
            Console.WriteLine($"I get { MyShare(12, 40) } slices...");
            Console.WriteLine($"Everyone else gets {GuestShare(MyShare(12, 40), 4)} slices each...");
           

        }
        
    }
    
}
