using ActionFuncDelegatesInCsharp.Logger;

namespace ActionFuncDelegatesInCsharp
{
    public class FuncDelegates
    {
        private readonly ILogger _logger;

        public FuncDelegates(ILogger logger)
        {
            _logger = logger;
        }

        public double FuncDelegateUsage(double salary, double rate)
        {
            Func<double, double, double> functionDelegate = new Func<double, double, double>(GetTax);
            Func<double> maxSalaryFind = () => { return Constants.MAX_SALARY; };

            var calculatedTax = functionDelegate(salary, rate);
            var maxSalary = maxSalaryFind();

            _logger.Log("CalculatedTax is :{0}", calculatedTax);
            _logger.Log("Max salary is :{0}", maxSalary);

            return calculatedTax;
        }

        public double GetTax(double netSalary, double taxRate)
        {
            double result;
            if (netSalary < 0)
            {
                _logger.Log("InvalidNetSalary");
                result = -1;
            }
            else if (taxRate <= 0)
            {
                _logger.Log("InvalidTaxRate");
                result = -2;
            }
            else
                result = (double)(netSalary * taxRate);

            return result;
        }
    }
}
