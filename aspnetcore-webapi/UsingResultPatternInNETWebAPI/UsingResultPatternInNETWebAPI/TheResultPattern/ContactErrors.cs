namespace UsingResultPatternInNETWebAPI.TheResultPattern;

public static class ContactErrors
{
    public static Error NotFound(Guid id) =>
        new("Contact.NotFound", $"contact with id {id} not found", ErrorType.NotFound);

    public static Error EmailTaken(string email) =>
        new("Contact.EmailTaken", $"contact with email {email} already exists", ErrorType.Conflict);
}
