using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActions
{
    public class CalculateNumbers
    {

        public delegate double Secondcalculation(List<double> numbers);


        public List<string> CalculateStats(List<double> numbers, Secondcalculation avgcal)
        {

            var stats = new List<string>();
            stats.Add(" Infomation about the numbers passed");
            stats.Add(" Count of how man are numbers are in the list: " + numbers.Count());
            stats.Add("Calculation: " + avgcal.Invoke(numbers).ToString());
            return stats;
        }


        public double Mean(List<double> nums)
        {
            return nums.Average();
        }

        public double Sum(List<double> nums)
        {
            return nums.Sum();
        }

        public double First(List<double> nums)
        {
            return nums.First();
        }
    }
}
