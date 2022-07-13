using System;
using System.Text;

namespace CsharpDelegatesActionFunc
{
    public class InterestService
    {
        public static string GetTotalInterestByHours(double time, double rate)
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Total Interest of ${0} rate in {1} hours is {2}", rate, time, (time * rate) / 100);

            return sb.ToString();
        }
        public static string GetTotalInterestByMinutes(double time, double rate)
        {
            var sb = new StringBuilder();
            var timeInHours = Math.Round(time / 60, 3);
            sb.AppendFormat("Total Interest of ${0} rate in {1} hours is {2}", rate, timeInHours, Math.Round((timeInHours * rate) / 100, 3));

            return sb.ToString();
        }

        public static void PrintTotalInterestByHours(double time, double rate)
        {
            Console.WriteLine("Total Interest of ${0} rate in {1} hours is {2}", rate, time, (time * rate) / 100);
        }
        public static void PrintTotalInterestByMinutes(double time, double rate)
        {
            var timeInHours = Math.Round(time / 60, 3);

            Console.WriteLine("Total Interest of ${0} rate in {1} hours is {2}", rate, time, Math.Round((timeInHours * rate) / 100, 3));
        }
    }
}
