using ActionAndFuncDelegates;
using ActionAndFuncDelegates.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject
{
    [TestClass]
    public class ActionAndFuncDelegatesUnitTest
    {
        OrderController controller = new OrderController();

        [TestMethod]
        public void WhenCreatingAnOrder_ThenCorrectStatusCode()
        {
            // Arrange
            var product = new Product { Id = 6, Price = 20.4M, ProductName = "Monitor" };
            var order = new Order { Id = 4, CustomerName = "James", Products = new List<Product> { product} };

            // Act
            var response = controller.CreateOrder(order);

            // Assert
            Assert.IsInstanceOfType(response, typeof(OkResult));

        }

        [TestMethod]
        public void WhenGettingAnOrder_ThenCorrectStatusCode()
        {
            // Act
            var response = controller.GetOrder(1);
            var okResult = response as ObjectResult;
            var orderDetails = okResult.Value as OrderDetails;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.IsInstanceOfType(okResult.Value, typeof(OrderDetails));
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.AreEqual("James", orderDetails?.Order.CustomerName);
            Assert.AreEqual(112.78833333333333333333333333M, orderDetails?.Sum);
            Assert.AreEqual(1.9116666666666666666666666666M, orderDetails?.Discount);
        }
       
    }
}