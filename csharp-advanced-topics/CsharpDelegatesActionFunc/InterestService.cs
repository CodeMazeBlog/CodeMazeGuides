using System;
using System.Text;

namespace CsharpDelegatesActionFunc
{
    public class InterestService
    {
        public static string getTotalInterestByHours(double time, double rate)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Total Interest of ${0} rate in {1} hours is {2}", rate, time, (time * rate) / 100);
            return sb.ToString();
        }
        public static string getTotalInterestByMinutes(double time, double rate)
        {
            StringBuilder sb = new StringBuilder();
            double timeInHours = Math.Round(time / 60, 3);
            sb.AppendFormat("Total Interest of ${0} rate in {1} hours is {2}", rate, timeInHours, Math.Round((timeInHours * rate) / 100, 3));
            return sb.ToString();
        }

        public static void printTotalInterestByHours(double time, double rate)
        {
            Console.WriteLine("Total Interest of ${0} rate in {1} hours is {2}", rate, time, (time * rate) / 100);
        }
        public static void printTotalInterestByMinutes(double time, double rate)
        {
            double timeInHours = Math.Round(time / 60, 3);
            Console.WriteLine("Total Interest of ${0} rate in {1} hours is {2}", rate, time, Math.Round((timeInHours * rate) / 100, 3));
        }
    }
}
