using System.Diagnostics.CodeAnalysis;

namespace JsonSerializeExceptions;

public class CustomException : Exception
{
    public CustomException(string message, string mitigation) 
        : this(message, mitigation, null)
    { }

    public CustomException(string message, string mitigation, Exception? innerException) 
        : base(message, innerException)
    {
        Mitigation = mitigation;
    }

    public string Mitigation { get; }
}