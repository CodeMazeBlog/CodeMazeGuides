namespace DifferenceBetweenFieldsAndProperty;

public class Configuration
{
    private string _secretKey = string.Empty;

    public string SecretKey
    {
        set
        {
            _secretKey = $"**{value}**";
        }
    }

    public string MaskedSecretKey
    {
        get { return _secretKey; }
    }
}
