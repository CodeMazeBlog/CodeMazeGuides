namespace RegisterInstancesOfInterface.Api.Redesign.Tests;

public class PostalControllerTests
{
    private PostalController _sut;
    private IFulfillPostalTickets _fulfillPostalTicketsMock = Substitute.For<IFulfillPostalTickets>();

    private const string RequestId = "123456";
    private const string Message = "Fulfillment using postal delivery method";

    [SetUp]
    public void Setup()
    {
        _fulfillPostalTicketsMock.Fulfill(RequestId).Returns(Message);
        _sut = new PostalController(_fulfillPostalTicketsMock);
    }
    
    [Test]
    public void WhenCalledController_ThenOkResponseIsReceived()
    {
        var response = _sut.Post(RequestId);
        
        Assert.That(response, Is.EqualTo(Message));
    }
}