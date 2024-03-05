using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using GraphQLStrawberryShake.Controllers;
using GraphQLStrawberryShake.GraphQL;
using StrawberryShake;
using FluentAssertions;

namespace Tests.Client;
public class ShippingContainerControllerUnitTests
{
    private readonly IShippingContainerClient _client;
    private readonly ShippingContainerController _controller;

    public ShippingContainerControllerUnitTests()
    {
        _client = Substitute.For<IShippingContainerClient>();
        _controller = new ShippingContainerController(_client);
    }

    [Fact]
    public async Task GivenShippingContainerClient_WhenGetShippingContainersCalled_ThenReturnsOkResultTest()
    {
        var mockResult = Substitute.For<IOperationResult<IGetShippingContainersNameResult>>();
        mockResult.Data.Returns(Substitute.For<IGetShippingContainersNameResult>());
        _client.GetShippingContainersName.ExecuteAsync()
            .Returns(mockResult);

        var result = await _controller.GetShippingContainers();

        result.Should().BeOfType<OkObjectResult>();
    }
}
