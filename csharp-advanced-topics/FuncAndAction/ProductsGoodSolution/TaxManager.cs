using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsGoodSolution
{
    public static class TaxManager
    {
        public static Dictionary<ProductType, Func<double, double>> TaxCalculatorDict =>
            new()
            {
                { ProductType.Clothes, ClothesFunc },
                { ProductType.Household, HouseholdFunc },
                { ProductType.Electronics, ElectronicsFunc },
            };

        public static double ClothesFunc(double price) => price * 0.03;
        public static double ElectronicsFunc(double price) => price * 0.01;
        public static double HouseholdFunc(double price) => price * 0.02;
    }
   
}
