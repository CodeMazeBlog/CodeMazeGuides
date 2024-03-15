namespace RegisterInstancesOfInterface.Api.Redesign.Tests;

public class SmartcardControllerTests
{
    private SmartcardController _sut;
    private IFulfillSmartcardTickets _fulfillSmartcardTicketsMock = Substitute.For<IFulfillSmartcardTickets>();

    private const string RequestId = "123456";
    private const string Message = "Fulfillment using smartcard delivery method";

    [SetUp]
    public void Setup()
    {
        _fulfillSmartcardTicketsMock.Fulfill(RequestId).Returns(Message);
        _sut = new SmartcardController(_fulfillSmartcardTicketsMock);
    }
    
    [Test]
    public void WhenCalledController_ThenOkResponseIsReceived()
    {
        var response = _sut.Post(RequestId);
        
        Assert.That(response, Is.EqualTo(Message));
    }
}