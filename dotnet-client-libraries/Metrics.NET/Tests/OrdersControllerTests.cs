using Metrics.NET.Controllers;
using Metrics.NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Tests;

public class OrdersControllerTests
{
    private readonly OrdersController _controller;

    public OrdersControllerTests()
    {
        _controller = new OrdersController();
    }

    [Fact]
    public void GivenOrdersController_WhenAddingNewComputerComponent_ReturnsOK()
    {
        // Act
        var result = _controller.CreateComputerComponent("keyboard", 99.99m);
        var okResult = result as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.True(okResult is OkObjectResult);
        Assert.IsType<ComputerComponent>(okResult.Value);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact]
    public void GivenExistingComponents_WhenCreatingNewOrder_ReturnsOK()
    {
        // Act
        var result = _controller.CreateOrder(new List<int> { 1 });
        var okResult = result as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.True(okResult is OkObjectResult);
        Assert.IsType<Order>(okResult.Value);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact]
    public void GivenExistingOrder_WhenCancellingOrder_ReturnsOK()
    {
        // Arrange
        var createOrderResult = _controller.CreateOrder(new List<int> { 1 });
        var createOrderOkResult = createOrderResult as OkObjectResult;

        // Act
        var result = _controller.CancelOrder(((Order)createOrderOkResult.Value).Id);
        var okResult = result as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.True(okResult is OkObjectResult);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }

    [Fact]
    public void GivenNoExistingOrder_WhenCancellingOrder_ReturnsNotFound()
    {
        // Act
        var result = _controller.CancelOrder(10);
        var notFoundResult = result as NotFoundObjectResult;

        // Assert
        Assert.NotNull(notFoundResult);
        Assert.True(notFoundResult is NotFoundObjectResult);
        Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
    }

    [Fact]
    public void GivenExistingOrder_WhenCheckingOut_ReturnsOk()
    {
        // Arrange
        var createOrderResult = _controller.CreateOrder(new List<int> { 1 });
        var createOrderOkResult = createOrderResult as OkObjectResult;

        // Act
        var result = _controller.Checkout(1);
        var okResult = result as OkObjectResult;

        // Assert
        Assert.NotNull(okResult);
        Assert.True(okResult is OkObjectResult);
        Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
    }
}