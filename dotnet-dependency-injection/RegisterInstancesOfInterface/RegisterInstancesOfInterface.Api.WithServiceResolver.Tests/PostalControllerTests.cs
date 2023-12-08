namespace RegisterInstancesOfInterface.Api.WithServiceResolver.Tests;

public class PostalControllerTests
{
    private PostalController _sut;
    private FulfillmentProcessorResolver _fulfillmentProcessorResolverMock;
    private IFulfillTickets _fulfillTicketsMock;

    private const string RequestId = "123456";
    private const string DeliveryMethodName = "postal";
    private const string Message = "Fulfillment using postal delivery method";

    [SetUp]
    public void Setup()
    {
        _fulfillTicketsMock = Substitute.For<IFulfillTickets>();
        _fulfillTicketsMock.Fulfill(RequestId).Returns(Message);

        _fulfillmentProcessorResolverMock = Substitute.For<FulfillmentProcessorResolver>();
        _fulfillmentProcessorResolverMock(DeliveryMethodName).ReturnsForAnyArgs(_fulfillTicketsMock);

        _sut = new PostalController(_fulfillmentProcessorResolverMock);
    }

    [Test]
    public void WhenCalledController_ThenOkResponseIsReceived()
    {
        var response = _sut.Post(RequestId);

        Assert.That(response, Is.EqualTo(Message));
    }
}