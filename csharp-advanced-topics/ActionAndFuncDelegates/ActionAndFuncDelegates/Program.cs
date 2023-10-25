namespace ActionAndFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            var taxType = TaxType.Income;
            decimal taxableAmount = 130000.00M;
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

            decimal taxLiability = calculateTax(taxableAmount);

            Console.WriteLine(String.Format("Your {0} tax liability is {1:C2}.", taxType.ToString(), taxLiability));
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
            decimal salesTaxRate = 0.0925M;
            return totalSales * salesTaxRate;
        }

        public static decimal CalculatePropertyTax(decimal propertyValue)
        {
            // homeowners get a $7,000 reduction in their base amount
            int exemptionAmount = 7000;

            // divide by 2 because property tax is paid in 2 installments
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