namespace ScenarioWithDelegates
{
    public interface IHttpClient
    {
        TResponseBody SendGetRequest<TResponseBody>(string uri);
    }
}
