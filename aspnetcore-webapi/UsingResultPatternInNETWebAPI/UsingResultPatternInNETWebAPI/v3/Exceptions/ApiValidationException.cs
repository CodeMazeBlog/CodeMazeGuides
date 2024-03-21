namespace UsingResultPatternInNETWebAPI.v3.Exceptions;

public class ApiValidationException : Exception
{
    public ApiValidationException(string message)
        : base(message)
    {
    }
}