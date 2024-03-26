namespace UsingResultPatternInNETWebAPI.v5.Errors;

public class ValidationError : Error
{
    public ValidationError(string message)
        : base(message)
    {
    }
}