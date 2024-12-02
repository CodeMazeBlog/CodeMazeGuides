namespace ChainOfResponsibilityPattern.Solution.Handlers;

public class MemberAccessibilityCheckHandler : HandlerBase
{
    public override RentalResponse Handle(RentalRequest request)
    {
        if (DataStore.FindUser(request.UserName) is not { } user)
            return RentalResponse.MembershipRequired;

        if (!user.IsFaculty && IsReserved(request.BookName))
            return RentalResponse.FacultyOnlyAccess;

        if (_nextHandler is null)
            return RentalResponse.AccessibleToUser;

        return _nextHandler.Handle(request);
    }

    private static bool IsReserved(string bookName) => DataStore.FindBook(bookName) is { IsReserved: true };
}