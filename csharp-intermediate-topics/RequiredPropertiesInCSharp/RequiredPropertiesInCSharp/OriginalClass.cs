namespace RequiredPropertiesInCSharp;

public class OriginalClass
{
    public string RequiredString { get; set; }

    public OriginalClass(string requiredString)
    {
        RequiredString = requiredString;
    }
}
