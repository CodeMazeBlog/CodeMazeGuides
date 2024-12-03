namespace ChainOfResponsibilityPattern.Solution.Handlers;

public class BookAvailabilityCheckHandler : HandlerBase
{
    public override RentalResponse Handle(RentalRequest request)
    {
        if (DataStore.FindBook(request.BookName) is not { } book || book.IssuedTo is not null)
            return RentalResponse.BookUnavailable;

        if (_nextHandler is null)
            return RentalResponse.BookAvailable;

        return _nextHandler.Handle(request);
    }
}