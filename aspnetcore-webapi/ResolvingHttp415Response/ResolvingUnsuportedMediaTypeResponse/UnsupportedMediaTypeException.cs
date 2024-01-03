namespace ResolvingUnsuportedMediaTypeResponse;

public class UnsupportedMediaTypeException : Exception
{
    public string RequestContnetType {get;}
    public string ExpectedContentType {get;}

    public UnsupportedMediaTypeException(string requestContnetType, string expectedContentType)
    {
        RequestContnetType = requestContnetType;
        ExpectedContentType = expectedContentType;
    }
}
