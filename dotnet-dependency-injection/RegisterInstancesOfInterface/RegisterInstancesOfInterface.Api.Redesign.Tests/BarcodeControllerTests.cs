namespace RegisterInstancesOfInterface.Api.Redesign.Tests;

public class BarcodeControllerTests
{
    private BarcodeController _sut;
    private IFulfillBarcodeTickets _fulfillBarcodeTicketsMock = Substitute.For<IFulfillBarcodeTickets>();

    private const string RequestId = "123456";
    private const string Message = "Fulfillment using barcode delivery method";

    [SetUp]
    public void Setup()
    {
        _fulfillBarcodeTicketsMock.Fulfill(RequestId).Returns(Message);
        _sut = new BarcodeController(_fulfillBarcodeTicketsMock);
    }
    
    [Test]
    public void WhenCalledController_ThenOkResponseIsReceived()
    {
        var response = _sut.Post(RequestId);
        
        Assert.That(response, Is.EqualTo(Message));
    }
}