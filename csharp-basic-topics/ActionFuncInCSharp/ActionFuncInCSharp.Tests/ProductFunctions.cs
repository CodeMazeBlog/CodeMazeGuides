using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncInCSharp.Tests
{
    public static class ProductFunctions
    {
        public static Func<Product, bool> PriceIsLessThan(double price)
        {
            return p => p.Price < price;
        }

        public static Func<Product, bool> PriceIsLessThan(double price, bool logOnPredicated = false)
        {
            return p =>
            {
                var predicated = p.Price < price;

                if (logOnPredicated && predicated)
                {
                    LoggingActions.LogObjectsToConsole(p);
                }

                return predicated;
            };
        }
    }
}
