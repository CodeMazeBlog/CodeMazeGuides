namespace ActionAndFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            var taxType = TaxType.Income;
            var taxableAmount = 130000.00M;
            Func<decimal, decimal> calculateTax;

            switch (taxType)
            {
                case TaxType.Income:
                    calculateTax = CalculateIncomeTax;
                    break;

                case TaxType.Sales:
                    calculateTax = CalculateSalesTax;
                    break;

                case TaxType.Property:
                    calculateTax = CalculatePropertyTax;
                    break;

                default:
                    calculateTax = CalculateIncomeTax;
                    break;
            }

            var taxLiability = calculateTax(taxableAmount);

            Console.WriteLine(String.Format("Your {0} tax liability is {1:C2}.", 
                taxType.ToString(), 
                taxLiability));
        }

        public static decimal CalculateIncomeTax(decimal taxableIncome)
        {
            if (taxableIncome > 200000)
            {
                return taxableIncome * 0.40M;
            }
            else if (taxableIncome > 100000)
            {
                return taxableIncome * 0.30M;
            }
            else if (taxableIncome > 50000)
            {
                return taxableIncome * 0.2M;
            }
            else
            {
                return 0.00M;
            }
        }

        public static decimal CalculateSalesTax(decimal totalSales)
        {
            var salesTaxRate = 0.0925M;
            return totalSales * salesTaxRate;
        }

        public static decimal CalculatePropertyTax(decimal propertyValue)
        {
            var exemptionAmount = 7000;
            return (propertyValue - exemptionAmount) * 0.0125M / 2;
        }

        private enum TaxType
        {
            Income,
            Sales,
            Property
        }
    }
}