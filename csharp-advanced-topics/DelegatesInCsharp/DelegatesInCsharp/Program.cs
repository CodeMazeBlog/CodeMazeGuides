using System;

namespace DelegatesInCsharp
{
    public class Program
    {
        public static double CalculateSimpleInterest(double principalAmount, float rate, int time)
        {
            return (principalAmount * rate * time) / 100;
        }

        public static void Print(double simpleInterest)
        {
            Console.WriteLine(simpleInterest);
        }

        static void Main(string[] args)
        {
            Func<double, float, int, double> funcDelegate = CalculateSimpleInterest;
            double simpleInterest = funcDelegate.Invoke(50000, 3.5f, 3);

            Action<double> actionDelegate = Print;
            actionDelegate.Invoke(simpleInterest);

            Console.ReadLine();
        }
    }
}
