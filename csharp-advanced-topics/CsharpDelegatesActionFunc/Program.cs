using System;
using System.Text;

namespace CsharpDelegatesActionFunc
{
    class Program
    {
        delegate string getInterestRate(double time, double rate);
        static void Main(string[] args)
        {
            //Single delegate
            getInterestRate delegateTotalInterest = new getInterestRate(InterestService.getTotalInterestByHours);
            string result = delegateTotalInterest.Invoke(8, 10);
            Console.WriteLine("Single delegate result: " + result);

            //Multicast delegate
            delegateTotalInterest += InterestService.getTotalInterestByMinutes;
            StringBuilder sb = new StringBuilder();
            foreach (var del in delegateTotalInterest.GetInvocationList())
            {
                string res = (string)del.DynamicInvoke(8, 10);
                sb.Append(res + " - ");
            }
            Console.WriteLine("Multicast delegate result: " + sb.ToString());

            //Action<T> Single delegate
            Action<double, double> actionGetTotalInterestSingle = InterestService.printTotalInterestByHours;
            Console.WriteLine("Action<T> single delegate result: ");
            actionGetTotalInterestSingle(8, 10);

            //Action<T> Multicast delegate
            Action<double, double> actionGetTotalInterestMultiple = InterestService.printTotalInterestByHours;
            actionGetTotalInterestMultiple += InterestService.printTotalInterestByMinutes;
            Console.WriteLine("Action<T> multicast delegate result: ");
            actionGetTotalInterestMultiple(8, 10);

            //Func<T> Single delegate
            Func<double, double, string> funcGetTotalInterestSingle = InterestService.getTotalInterestByHours;
            string funcSingleResult = funcGetTotalInterestSingle(8, 10);
            Console.WriteLine("Func<T> single delegate result: " + funcSingleResult);

            //Func<T> multicast delegate
            Func<double, double, string> executeGetTotalInterest = InterestService.getTotalInterestByHours;
            executeGetTotalInterest += InterestService.getTotalInterestByMinutes;
            StringBuilder funcSb = new StringBuilder();
            foreach (var del in executeGetTotalInterest.GetInvocationList())
            {
                string funcMultiResult = (string)del.DynamicInvoke(8, 10);
                funcSb.Append(funcMultiResult + " - ");
            }
            Console.WriteLine("Func<T> multicast delegate result: " + funcSb.ToString());
        }
    }
}
