using API;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests;

public class OrdersControllerUnitTests
{
    [Fact]
    public void GivenAValidOrder_WhenCallingPost_ThenAnOkResultIsReturned()
    {
        var ordersService = new Mock<IOrdersService>();
        var controller = new OrdersController(ordersService.Object);
        var order = new Order(1, 100);
        ordersService
            .Setup(x => x.PlaceOrder(order))
            .Returns(new Receipt(1, order.Payment));

        var okResult = controller.Post(order) as OkObjectResult;

        Assert.NotNull(okResult);
    }

    [Fact]
    public void GivenAnInvalidOrder_WhenCallingPost_ThenAn500StatusCodeResultIsReturned()
    {
        var ordersService = new Mock<IOrdersService>();
        var controller = new OrdersController(ordersService.Object);
        var order = new Order(1, 100);
        ordersService
            .Setup(x => x.PlaceOrder(order))
            .Returns(PlaceOrderError.InsufficientFunds);

        var objectResult = controller.Post(order) as ObjectResult;

        Assert.NotNull(objectResult);
        Assert.Equal(500, objectResult.StatusCode);
    }
}
