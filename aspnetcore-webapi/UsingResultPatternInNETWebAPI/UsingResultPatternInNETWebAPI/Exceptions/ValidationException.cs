namespace UsingResultPatternInNETWebAPI.v3.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message)
        : base(message)
    {
    }
}