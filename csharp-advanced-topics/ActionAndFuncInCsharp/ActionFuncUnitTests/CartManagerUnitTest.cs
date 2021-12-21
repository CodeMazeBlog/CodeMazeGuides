using ActionFunc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionFuncUnitTests
{
    [TestClass]
    public class CartManagerUnitTest
    {
        [TestMethod]
        public void WhenCallingGetCart_ReturnsCartWithActionAndFunc()
        {
            //arrange
            var cartManager = new CartManager();
            
            //act
            var cart = cartManager.GetCart();

            //assert
            Assert.IsNotNull(cart);
            Assert.IsNotNull(cart.AddProduct);
            Assert.IsNotNull(cart.GetReceipt);
        }

        [TestMethod]
        public void WhenCallingAddItem_AddsTheItemToList()
        {
            //arrange
            var cartManager = new CartManager();
            var itemName = "test item";
            
            //act
            cartManager.AddItem(itemName);

            //assert
            Assert.AreEqual(itemName, cartManager.Products[0]);
        }

        [TestMethod]
        public void WhenCallingGetReceipt_ReturnsTheReceiptText()
        {
            //arrange
            var cartManager = new CartManager();
            var itemName = "test item";
            var customerName = "test customer";
            cartManager.AddItem(itemName);
            var expected = $"The total amount of {cartManager.Products[0]} is 10$ for {customerName}";
           
            //act
            var actual = cartManager.GetReceipt(customerName);

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
