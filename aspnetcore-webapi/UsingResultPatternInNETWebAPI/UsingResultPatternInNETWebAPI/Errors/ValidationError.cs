namespace UsingResultPatternInNETWebAPI.Errors;

public class ValidationError : Error
{
    public ValidationError(string message)
        : base(message)
    {
    }
}