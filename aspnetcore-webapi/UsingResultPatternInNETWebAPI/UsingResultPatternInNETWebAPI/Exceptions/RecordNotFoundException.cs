namespace UsingResultPatternInNETWebAPI.v3.Exceptions;

public class RecordNotFoundException : Exception
{
    public RecordNotFoundException(string message)
        : base(message)
    {
    }
}