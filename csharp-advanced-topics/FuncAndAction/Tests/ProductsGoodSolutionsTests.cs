using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductsGoodSolution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class ProductsGoodSolutionsTests
    {
        static List<Product> Products = new List<Product>()
        {
            new Product(100, ProductType.Clothes),
            new Product(100, ProductType.Electronics),
            new Product(100, ProductType.Household),
        };
        [TestMethod]
        public void WhenPassingListOfProductsThenTotalPriceIsCalculated()
        {
            var result = Products.Select(p => p.Price + TaxManager.TaxCalculatorDict[p.ProductType](p.Price)).Sum();
            Assert.AreEqual(result, 306);
        }
    }
}
