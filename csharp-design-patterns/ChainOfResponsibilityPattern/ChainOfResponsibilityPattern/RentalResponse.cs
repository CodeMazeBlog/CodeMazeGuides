namespace ChainOfResponsibilityPattern;

public record RentalResponse(string Message)
{
    public static readonly RentalResponse BookUnavailable = new("Book unavailable");
    public static readonly RentalResponse BookAvailable = new("Book available");

    public static readonly RentalResponse MembershipRequired = new("Membership required");
    public static readonly RentalResponse FacultyOnlyAccess = new("Accessible to faculty member only");
    public static readonly RentalResponse AccessibleToUser = new("Accessible to user");

    public static readonly RentalResponse InsufficientBalance = new("Insufficient Balance");
    public static readonly RentalResponse RentalApproved = new("Rental Approved");

    public static readonly RentalResponse RentalIssued = new("Rental Issued");
}