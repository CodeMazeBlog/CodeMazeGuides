using IntroductionToWolverineLibrary.Handlers;
using IntroductionToWolverineLibrary.Models;

namespace IntroductionToWolverineLibrary.Tests.Handlers;

public class UnitTests
{
    private readonly Order _newBookOrder;
    private readonly Order? _nullBookOrder;
    private readonly BookReview _bookReview;
    private readonly BookReview? _nullBookReview;
    private readonly string _expectedMessage;
    private readonly string _expectedNullMessage;
    private readonly string _expectedReviewMessage;
    private readonly string _expectedNullReviewMessage;


    public UnitTests()
    {
        _newBookOrder = new Order(Guid.NewGuid(),"Test Book", 1 );
        _nullBookOrder = null;
        _bookReview = new BookReview(1, "Mary Graham", 5);
        _nullBookReview = null;
        _expectedMessage = $"New order received: {_newBookOrder}";
        _expectedNullMessage = $"New order received:";
        _expectedReviewMessage = $"New book review received: {_bookReview}";
        _expectedNullReviewMessage = $"New book review received:";
    }

    [Fact]
    public void GivenNewBookOrder_WhenMethodOrderHandler_ThenExpectedMessageConsole()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        OrderHandler.Handle(_newBookOrder);

        var result = sw.ToString().Trim();
        Assert.Equal(_expectedMessage, result);
    }

    [Fact]
    public void GivenNewBookOrder_WhenMethodOrderReplyHandler_ThenExpectedMessageReply()
    {
        var result = OrderReplyHandler.Handle(_newBookOrder);

        Assert.Equal(_expectedMessage, result);
    }

    [Fact]
    public void GivenBookReview_WhenMethodBookReviewHandler_ThenExpectedMessageReply()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        BookReviewHandler.Handle(_bookReview);

        var result = sw.ToString().Trim();
        Assert.Equal(_expectedReviewMessage, result);
    }

    [Fact]
    public void GivenNullOrder_WhenHandlingOrder_ThenThrowsArgumentNullException()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        OrderHandler.Handle(_nullBookOrder);

        var result = sw.ToString().Trim();

        Assert.Equal(_expectedNullMessage, result);
    }

    [Fact]
    public void GivenNullOrder_WhenHandlingOrderReply_ThenThrowsArgumentNullException()
    {
        var result = OrderReplyHandler.Handle(_nullBookOrder).Trim();

        Assert.Equal(_expectedNullMessage, result);
    }

    [Fact]
    public void GivenNullReview_WhenHandlingBookReview_ThenThrowsArgumentNullException()
    {
        using var sw = new StringWriter();
        Console.SetOut(sw);

        BookReviewHandler.Handle(_nullBookReview);

        var result = sw.ToString().Trim();

        Assert.Equal(_expectedNullReviewMessage, result);
    }
}
