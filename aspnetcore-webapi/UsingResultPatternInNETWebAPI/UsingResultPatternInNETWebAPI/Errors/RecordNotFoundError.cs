namespace UsingResultPatternInNETWebAPI.Errors;

public class RecordNotFoundError : Error
{
    public RecordNotFoundError(string message)
        : base(message)
    {
    }
}