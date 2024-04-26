using Confluent.Kafka;
using Kafka.Controllers;
using Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KafkaUnitTests;

[TestClass]
public class OrderControllerUnitTests
{
    [TestMethod]
    public async Task GivenValidOrderDetails_WhenPlacingOrder_ThenReturnOk()
    {
        var mockProducer = new Mock<IProducer<string, string>>();
        var orderController = new OrderController(mockProducer.Object);
        var orderDetails = new OrderDetails();

        var result = await orderController.PlaceOrder(orderDetails) as OkObjectResult;

        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        Assert.AreEqual("Order placed successfully", result.Value);
    }

    [TestMethod]
    public async Task GivenInvalidOrderDetails_WhenPlacingOrder_ThenReturnBadRequest()
    {
        // Arrange
        var mockProducer = new Mock<IProducer<string, string>>();
        mockProducer.Setup(p => p.ProduceAsync(It.IsAny<string>(), It.IsAny<Message<string, string>>(), It.IsAny<CancellationToken>()))
            .Throws(new ProduceException<string, string>(new Error(ErrorCode.UnknownProducerId, "Invalid message"), new DeliveryResult<string, string>()));

        var orderController = new OrderController(mockProducer.Object);
        var invalidOrderDetails = new OrderDetails();

        // Act
        var result = await orderController.PlaceOrder(invalidOrderDetails) as BadRequestObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        Assert.IsTrue(result?.Value?.ToString()?.Contains("Error publishing message"));
    }
}