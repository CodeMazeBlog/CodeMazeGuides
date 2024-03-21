namespace UsingResultPatternInNETWebAPI.v5.Errors;

public class ApiValidationError : Error
{
    public ApiValidationError(string message)
        : base(message)
    {
    }
}