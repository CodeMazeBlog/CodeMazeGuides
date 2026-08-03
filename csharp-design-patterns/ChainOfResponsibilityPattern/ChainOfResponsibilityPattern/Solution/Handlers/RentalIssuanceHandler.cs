namespace ChainOfResponsibilityPattern.Solution.Handlers;

public class RentalIssuanceHandler : HandlerBase
{
    public override RentalResponse Handle(RentalRequest request)
    {
        var book = DataStore.FindBook(request.BookName)!;
        book.IssuedTo = request.UserName;

        // Send email to user
        Console.WriteLine($"Your request for {request.BookName} has been processed");

        return RentalResponse.RentalIssued;
    }
}