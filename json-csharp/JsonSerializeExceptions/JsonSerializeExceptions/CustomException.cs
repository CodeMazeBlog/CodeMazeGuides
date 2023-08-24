namespace JsonSerializeExceptions;

public class CustomException : Exception
{
    public string Mitigation { get; }

    public CustomException(string message, string mitigation) 
        : this(message, mitigation, null)
    { }

    public CustomException(string message, string mitigation, Exception? innerException) 
        : base(message, innerException)
    {
        Mitigation = mitigation;
    }    
}