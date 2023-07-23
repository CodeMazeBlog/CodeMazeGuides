namespace JsonSerializeExceptions;

[Serializable]
public class CustomVerboseException : CustomException
{
    public CustomVerboseException(string message, string mitigation) 
        : base(message, mitigation) { }
}