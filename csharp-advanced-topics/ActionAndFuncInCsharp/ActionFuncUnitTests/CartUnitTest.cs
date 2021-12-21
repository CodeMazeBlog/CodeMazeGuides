using ActionFunc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ActionFuncUnitTests
{
    [TestClass]
    public class CartUnitTest
    {
        private List<string> Products = new();

        [TestMethod]
        public void WhenCallingAdd_TriggersAddProductAction()
        {
            //arrange
            var cart = new Cart();
            cart.AddProduct = AddProductAction;
            var itemName = "test item";

            //act
            cart.Add(itemName);

            //assert
            Assert.AreEqual(Products[0], itemName);
        }

        [TestMethod]
        public void WhenCallingGetReceiptDetails_TriggersGetReceiptFunc()
        {
            //arrange
            var cart = new Cart();
            cart.GetReceipt = GetReceiptFunc;
            var customerName = "test customer";

            //act
            var actual = cart.GetReceiptDetails(customerName); ;

            //assert
            Assert.AreEqual(customerName, actual);
        }


        private void AddProductAction(string name)
        {
            Products.Add(name);
        }

        private string GetReceiptFunc(string customer)
        {
            return customer;
        }
    }
}
