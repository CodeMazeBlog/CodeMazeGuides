namespace ChainOfResponsibilityPattern.Solution.Handlers;

public class UserBalanceCheckHandler : HandlerBase
{
    public override RentalResponse Handle(RentalRequest request)
    {
        if (!HasBalance(request.UserName))
            return RentalResponse.InsufficientBalance;

        if (_nextHandler is null)
            return RentalResponse.RentalApproved;

        return _nextHandler.Handle(request);
    }

    private static bool HasBalance(string userName) => DataStore.FindUser(userName) is { Balance: >= Book.RentalFee };
}