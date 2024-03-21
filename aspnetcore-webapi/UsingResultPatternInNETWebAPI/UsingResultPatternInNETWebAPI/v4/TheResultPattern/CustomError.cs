namespace UsingResultPatternInNETWebAPI.v4.TheResultPattern;

public sealed record CustomError(string Code, string Message)
{
    private static readonly string NotFoundCode = "NotFound";
    private static readonly string ValidationErrorCode = "ValidationError";

    public static readonly CustomError None = new(string.Empty, string.Empty);

    public static CustomError NotFound(Guid id)
    {
        return new CustomError(NotFoundCode, $"contact with id {id} was not found");
    }

    public static CustomError ValidationError(string email)
    {
        return new CustomError(ValidationErrorCode, $"contact with email {email} already exists");
    }
}