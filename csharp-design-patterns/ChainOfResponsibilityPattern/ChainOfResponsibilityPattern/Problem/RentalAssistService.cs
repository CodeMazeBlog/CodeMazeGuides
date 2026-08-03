namespace ChainOfResponsibilityPattern.Problem;

public class RentalAssistService
{
    public RentalResponse ProcessRentRequest(RentalRequest request)
    {
        var result = CheckForBookAvailability(request.BookName);

        if (result != RentalResponse.BookAvailable)
            return result;

        result = CheckForMemberAccessibility(request.BookName, request.UserName);

        if (result != RentalResponse.AccessibleToUser)
            return result;

        result = CheckForAvailableBalance(request.UserName);

        if (result != RentalResponse.RentalApproved)
            return result;

        return IssueBook(request.BookName, request.UserName);
    }

    private RentalResponse CheckForBookAvailability(string bookName)
    {
        if (DataStore.FindBook(bookName) is not { } book || book.IssuedTo is not null)
            return RentalResponse.BookUnavailable;

        return RentalResponse.BookAvailable;
    }

    private RentalResponse CheckForMemberAccessibility(string bookName, string userName)
    {
        if (DataStore.FindUser(userName) is not { } user)
            return RentalResponse.MembershipRequired;

        if (!user.IsFaculty && IsReserved(bookName))
            return RentalResponse.FacultyOnlyAccess;

        return RentalResponse.AccessibleToUser;
    }

    private RentalResponse CheckForAvailableBalance(string userName)
    {
        if (!HasBalance(userName))
            return RentalResponse.InsufficientBalance;

        return RentalResponse.RentalApproved;
    }

    private RentalResponse IssueBook(string bookName, string userName)
    {
        var book = DataStore.FindBook(bookName)!;
        book.IssuedTo = userName;

        // Send email to user
        Console.WriteLine($"Your request for {bookName} has been processed");

        return RentalResponse.RentalIssued;
    }

    private static bool IsReserved(string bookName) => DataStore.FindBook(bookName) is { IsReserved: true };

    private static bool HasBalance(string userName) => DataStore.FindUser(userName) is { Balance: >= Book.RentalFee };
}