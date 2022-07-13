using System;
using System.Text;

namespace CsharpDelegatesActionFunc
{
    class Program
    {
        delegate string GetInterestRate(double time, double rate);
        static void Main(string[] args)
        {
            //Single delegate
            var delegateTotalInterest = new GetInterestRate(InterestService.GetTotalInterestByHours);
            var result = delegateTotalInterest.Invoke(8, 10);
            Console.WriteLine("Single delegate result: " + result);

            //Multicast delegate
            delegateTotalInterest += InterestService.GetTotalInterestByMinutes;
            var sb = new StringBuilder();
            foreach (var del in delegateTotalInterest.GetInvocationList())
            {
                var res = (string)del.DynamicInvoke(8, 10);
                sb.Append(res + " - ");
            }
            Console.WriteLine("Multicast delegate result: " + sb.ToString());

            //Action<T> Single delegate
            Action<double, double> actionGetTotalInterestSingle = InterestService.PrintTotalInterestByHours;
            Console.WriteLine("Action<T> single delegate result: ");
            actionGetTotalInterestSingle(8, 10);

            //Action<T> Multicast delegate
            Action<double, double> actionGetTotalInterestMultiple = InterestService.PrintTotalInterestByHours;
            actionGetTotalInterestMultiple += InterestService.PrintTotalInterestByMinutes;
            Console.WriteLine("Action<T> multicast delegate result: ");
            actionGetTotalInterestMultiple(8, 10);

            //Func<T> Single delegate
            Func<double, double, string> funcGetTotalInterestSingle = InterestService.GetTotalInterestByHours;
            var funcSingleResult = funcGetTotalInterestSingle(8, 10);
            Console.WriteLine("Func<T> single delegate result: " + funcSingleResult);

            //Func<T> multicast delegate
            Func<double, double, string> executeGetTotalInterest = InterestService.GetTotalInterestByHours;
            executeGetTotalInterest += InterestService.GetTotalInterestByMinutes;
            var funcSb = new StringBuilder();
            foreach (var del in executeGetTotalInterest.GetInvocationList())
            {
                var funcMultiResult = (string)del.DynamicInvoke(8, 10);
                funcSb.Append(funcMultiResult + " - ");
            }
            Console.WriteLine("Func<T> multicast delegate result: " + funcSb.ToString());
        }
    }
}
