namespace RegisterInstancesOfInterface.Api.WithServiceResolver.Tests;

public class BarcodeControllerTests
{
    private BarcodeController _sut;
    private FulfillmentProcessorResolver _fulfillmentProcessorResolverMock;
    private IFulfillTickets _fulfillTicketsMock;

    private const string RequestId = "123456";
    private const string DeliveryMethodName = "barcode";
    private const string Message = "Fulfillment using barcode delivery method";

    [SetUp]
    public void Setup()
    {
        _fulfillTicketsMock = Substitute.For<IFulfillTickets>();
        _fulfillTicketsMock.Fulfill(RequestId).Returns(Message);

        _fulfillmentProcessorResolverMock = Substitute.For<FulfillmentProcessorResolver>();
        _fulfillmentProcessorResolverMock(DeliveryMethodName).ReturnsForAnyArgs(_fulfillTicketsMock);

        _sut = new BarcodeController(_fulfillmentProcessorResolverMock);
    }

    [Test]
    public void WhenCalledController_ThenOkResponseIsReceived()
    {
        var response = _sut.Post(RequestId);

        Assert.That(response, Is.EqualTo(Message));
    }
}