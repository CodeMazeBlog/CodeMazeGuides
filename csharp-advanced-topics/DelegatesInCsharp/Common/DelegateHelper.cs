namespace Common
{
    public class DelegateHelper
    {
        Func<double, double> functionDelegate = new Func<double, double>(GetTax);
        public static double GetTax(double netSalary)
        {
            return (double)(netSalary * .3);
        }
    }
}