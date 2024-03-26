namespace UsingResultPatternInNETWebAPI.v5.Errors;

public class RecordNotFoundError : Error
{
    public RecordNotFoundError(string message)
        : base(message)
    {
    }
}