
namespace ActionAndFunc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Action<double> actionDelegate1 = new Action<double>(PrintTaxEntrepreneur);
            CalculateTaxes(actionDelegate1, 1000);

            Action<double> actionDelegate2 = new Action<double>(PrintTaxCorporation);
            CalculateTaxes(actionDelegate2, 1000);

            Func<double, double> funcDelegate1 = new Func<double, double>(TaxEntrepreneur);
            CalculateTaxes(funcDelegate1, 1000);

            Func<double, double> funcDelegate2 = new Func<double, double>(TaxCorporation);
            CalculateTaxes(funcDelegate2, 1000);
        }

        public static void CalculateTaxes(Action<double> function, double revenueAmmount)
        {
            Console.WriteLine("Starting tax calculation");
            function(revenueAmmount);
        }
        public static void PrintTaxEntrepreneur(double revenue)
        {
            //here would go the calculation algorithm for entrepreneurs
            Console.WriteLine(revenue * 1.1);
        }
        public static void PrintTaxCorporation(double revenue)
        {
            //here would go the calculation algorithm for corporations
            Console.WriteLine(revenue * 1.25);
        }


        public static void CalculateTaxes(Func<double, double> function, double revenueAmmount)
        {
            Console.WriteLine("Starting tax calculation");
            Console.WriteLine(function(revenueAmmount));
        }
        public static double TaxEntrepreneur(double revenue)
        {
            //here would go the calculation algorithm for entrepreneurs
            return revenue * 1.1;
        }
        public static double TaxCorporation(double revenue)
        {
            //here would go the calculation algorithm for corporations
            return revenue * 1.25;
        }
    }
}