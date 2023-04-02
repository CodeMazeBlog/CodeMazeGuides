namespace JsonSerializeExceptions;

public class ExceptionObject
{
    public ExceptionObject(Exception exception)
    {
        Message = exception.Message;
        StackTrace = exception.StackTrace;

        if (exception.InnerException is { } innerException)
            InnerException = new ExceptionObject(innerException);
    }

    public string Message { get; set; }

    public string? StackTrace { get; set; }

    public ExceptionObject? InnerException { get; set; }
}