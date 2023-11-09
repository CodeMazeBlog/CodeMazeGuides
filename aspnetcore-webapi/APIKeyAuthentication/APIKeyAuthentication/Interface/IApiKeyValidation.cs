namespace APIKeyAuthentication.Interface
{
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string userApiKey);
    }
}