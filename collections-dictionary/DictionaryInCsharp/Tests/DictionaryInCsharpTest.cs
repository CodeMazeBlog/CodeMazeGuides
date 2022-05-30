using DictionaryInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DictionaryInCsharpTest
{
    [TestClass]
    public class DictionaryInCsharpTest
    {
        Dictionary<int, Product> productsDict = new Dictionary<int, Product>()
        {
            { 0, new Product() { ProductId = 111, ProductName = "Table" }},
            { 1, new Product() { ProductId = 112, ProductName = "Chair" }},
            { 2, new Product() { ProductId = 113, ProductName = "TV" }},
        };

        [TestMethod]
        public void WhenCreatingEmptyDictionary_ThenReturnsEmptyDictionary()
        {
            var result = Program.CreateDictionary();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Dictionary<int, Product>));
        }

        [TestMethod]
        public void GivenEmptyDictionary_WhenAddingToDictionary_ThenReturnsPopulatedDictionary()
        {
            var productsDict = new Dictionary<int, Product>();

            var result = Program.AddToDictionary(productsDict);

            Assert.IsTrue(result.Count > 0);
            Assert.IsInstanceOfType(result, typeof(Dictionary<int, Product>));
        }

        [TestMethod]
        public void GivenNewKey_WhenAddingToDictionary_ThenAddsElementToDictionary()
        {
            var productsDict = new Dictionary<int, Product>();

            var result = Program.AddToDictionary(productsDict);

            Assert.IsTrue(result.Count == 4);
            Assert.AreEqual(result[3].ProductId, 114);
            Assert.AreEqual(result[3].ProductName, "Lamp");
        }

        [TestMethod]
        public void GivenDictionaryWithData_WhenRetrievingAnExistingKey_ThenGetsTheValue()
        {
            var result = Program.RetrieveDictionaryElements(productsDict);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.ProductId, 112);
            Assert.AreEqual(result.ProductName, "Chair");
        }

        [TestMethod]
        public void GivenDictionaryWithData_WhenUpdatingDictionary_ThenReturnsUpdatedDictionary()
        {
            var result = Program.UpdateDictionary(productsDict);

            Assert.AreEqual(result[0].ProductId, 110);
            Assert.AreEqual(result[0].ProductName, "Desk");
        }

        [TestMethod]
        public void GivenDictionaryWithData_WhenDeletingElement_ThenRemovesElement()
        {
            var result = Program.DeleteDictionaryElements(productsDict);

            Assert.IsTrue(result.Count == 2);
            Assert.IsInstanceOfType(result, typeof(Dictionary<int, Product>));
        }

        [TestMethod]
        public void GivenDictionaryWithData_WhenClearingDictionary_ThenReturnsZeroNumberOfElements()
        {
            var result = Program.ClearDictionary(productsDict);

            Assert.IsTrue(result == 0);
        }
    }
}
