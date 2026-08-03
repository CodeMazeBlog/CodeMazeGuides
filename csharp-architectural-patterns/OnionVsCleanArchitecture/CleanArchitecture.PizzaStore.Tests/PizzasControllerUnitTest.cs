using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CleanArchitecture.PizzaStore.API.Controllers;
using CleanArchitecture.PizzaStore.Application.UseCases;
using CleanArchitecture.PizzaStore.Domain.Entities;

namespace CleanArchitecture.PizzaStore.Tests;

public class PizzasControllerUnitTest
{
    [Fact]
    public async Task WhenCallingGetAll_ThenTheControllerReturnsPizzasAndASuccessfull200OkResponse()
    {
        // Arrange.
        var cancellationToken = CancellationToken.None;
        var mediator = new Mock<IMediator>();
        mediator
            .Setup(x => x.Send(It.IsAny<GetPizzasQuery>(), cancellationToken))
            .ReturnsAsync(new List<Pizza>
            {
                new()
            }.AsEnumerable());
        var controller = new PizzasController(mediator.Object);

        // Act.
        var okObjectResult = await controller.GetAll(cancellationToken) as OkObjectResult;

        // Assert.
        mediator.VerifyAll();
        Assert.NotNull(okObjectResult);
        Assert.Equal(200, okObjectResult.StatusCode);
        var pizzas = okObjectResult.Value as IEnumerable<Pizza>;
        Assert.NotNull(pizzas);
        Assert.NotEmpty(pizzas);
    }

    [Fact]
    public async Task GivenAnOrder_WhenCallingPlaceOrder_ThenTheControllerPlacesAnOrderAndReturnsASuccessfull200OkResponse()
    {
        // Arrange.
        var cancellationToken = CancellationToken.None;
        var command = new PlaceOrderCommand();
        var mediator = new Mock<IMediator>();
        mediator
            .Setup(x => x.Send(command, cancellationToken))
            .Returns(Task.CompletedTask);
        var controller = new PizzasController(mediator.Object);

        // Act.
        var okResult = await controller.PlaceOrder(command, cancellationToken) as OkResult;

        // Assert.
        mediator.VerifyAll();
        Assert.NotNull(okResult);
        Assert.Equal(200, okResult.StatusCode);
    }
}