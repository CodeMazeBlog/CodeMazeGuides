using ChainOfResponsibilityPattern.Solution.Handlers;

namespace ChainOfResponsibilityPattern.Solution;

public class RentalAssistService
{
    public RentalResponse ProcessRentRequest(RentalRequest request)
    {
        var handler = new BookAvailabilityCheckHandler();

        handler.SetNext(new MemberAccessibilityCheckHandler())
            .SetNext(new UserBalanceCheckHandler())
            .SetNext(new RentalIssuanceHandler());

        return handler.Handle(request);
    }

    public RentalResponse AssessRentRequest(RentalRequest request)
    {
        var handler = new BookAvailabilityCheckHandler();

        handler.SetNext(new MemberAccessibilityCheckHandler())
            .SetNext(new UserBalanceCheckHandler());

        return handler.Handle(request);
    }
}