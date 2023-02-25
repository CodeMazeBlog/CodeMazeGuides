using ActionAndFuncDelegatesInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ActionAndFuncDelegatesInCsharpUnitTests
    {
        public ActionAndFuncDelegatesInCsharpUnitTests()
        {
            ProductManager.Seed();
        }

        [TestMethod]
        public void WhenActionDelegate_ThenDelegateExecutesTheReferencedMethod()
        {
            var addProduct = ProductManager.Add;
            addProduct(5, "Tablet", true);
            addProduct(6, "Laptop", false);

            var remove = ProductManager.Remove;
            remove(5);

            var productsList = ProductManager.Products;

            Assert.AreEqual(productsList.Count(), 5);
            Assert.IsTrue(!productsList.Any(c => c.Id == 5));
            Assert.IsTrue(productsList.Any(c => c.Id == 6));
        }

        [TestMethod]
        public void GivenProductId_WhenFuncDelegate_ThenDelegateReturnsTheResult()
        {
            var getProduct = ProductManager.GetById;

            var result = getProduct(1);

            Assert.AreEqual(result.Name, "Mouse");
        }
    }
}