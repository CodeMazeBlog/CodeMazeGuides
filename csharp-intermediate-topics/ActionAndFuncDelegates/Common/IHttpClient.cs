namespace Common
{
    public interface IHttpClient
    {
        TResponseBody SendGetRequest<TResponseBody>(string uri);
    }
}
