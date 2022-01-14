

using static FuncActions.CalculateNumbers;

namespace FuncActions
// Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = new List<double>();
            Random r = new Random();
            nums.Add(r.NextDouble());
            nums.Add(r.NextDouble());
            nums.Add(r.NextDouble());
            nums.Add(r.NextDouble());
            nums.Add(r.NextDouble());

            NewCalculation n = new NewCalculation();


            CalculateNumbers calculate = new CalculateNumbers();

            Secondcalculation avg = new Secondcalculation(n.Range);
            foreach (var item in calculate.CalculateStats(nums, avg))
            {
                Console.WriteLine(item);
            }
        }
    }
}




