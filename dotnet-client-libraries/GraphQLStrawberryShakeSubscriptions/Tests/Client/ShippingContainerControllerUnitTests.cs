using FluentAssertions;
using GraphQLStrawberryShakeSubs;
using GraphQLStrawberryShakeSubs.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using StrawberryShake;

namespace Tests.Client;
public class ShippingContainerControllerUnitTests
{
    private readonly IShippingContainerSubClient _client;
    private readonly ShippingContainerController _controller;

    public ShippingContainerControllerUnitTests()
    {
        _client = Substitute.For<IShippingContainerSubClient>();
        _controller = new ShippingContainerController(_client);
    }

    [Fact]
    public async Task GivenShippingContainerSubsClient_WhenGetShippingContainersCalled_ThenReturnsOkResultTest()
    {
        var mockResult = Substitute.For<IOperationResult<IGetShippingContainersNameResult>>();
        mockResult.Data.Returns(Substitute.For<IGetShippingContainersNameResult>());
        _client.GetShippingContainersName.ExecuteAsync()
            .Returns(mockResult);

        var result = await _controller.GetShippingContainers();

        result.Should().BeOfType<OkObjectResult>();
    }
}
