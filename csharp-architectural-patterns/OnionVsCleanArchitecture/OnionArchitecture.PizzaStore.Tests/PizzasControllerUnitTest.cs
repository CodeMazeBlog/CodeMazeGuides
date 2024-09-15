using Microsoft.AspNetCore.Mvc;
using Moq;
using OnionArchitecture.PizzaStore.Contracts;
using OnionArchitecture.PizzaStore.Presentation.Controllers;
using OnionArchitecture.PizzaStore.Services.Abstractions;

namespace PizzaStore.Tests;

public class PizzasControllerUnitTest
{
    [Fact]
    public async Task WhenCallingGetAll_ThenTheControllerReturnsPizzasAndASuccessfull200OkResponse()
    {
        // Arrange.
        var cancellationToken = CancellationToken.None;
        var pizzaService = new Mock<IPizzaService>();
        pizzaService
            .Setup(x => x.GetAllAsync(cancellationToken))
            .ReturnsAsync(new List<PizzaDto>
            {
                new()
            }.AsEnumerable());
        var controller = new PizzasController(pizzaService.Object);

        // Act.
        var okObjectResult = await controller.GetAll(cancellationToken) as OkObjectResult;

        // Assert.
        pizzaService.VerifyAll();
        Assert.NotNull(okObjectResult);
        Assert.Equal(200, okObjectResult.StatusCode);
        var pizzas = okObjectResult.Value as IEnumerable<PizzaDto>;
        Assert.NotNull(pizzas);
        Assert.NotEmpty(pizzas);
    }

    [Fact]
    public async Task GivenAnOrder_WhenCallingPlaceOrder_ThenTheControllerPlacesAnOrderAndReturnsASuccessfull200OkResponse()
    {
        // Arrange.
        var cancellationToken = CancellationToken.None;
        var order = new OrderDto();
        var pizzaService = new Mock<IPizzaService>();
        pizzaService
            .Setup(x => x.PlaceOrderAsync(order, cancellationToken))
            .Returns(Task.CompletedTask);
        var controller = new PizzasController(pizzaService.Object);

        // Act.
        var okResult = await controller.PlaceOrder(order, cancellationToken) as OkResult;

        // Assert.
        pizzaService.VerifyAll();
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);            
    }
}