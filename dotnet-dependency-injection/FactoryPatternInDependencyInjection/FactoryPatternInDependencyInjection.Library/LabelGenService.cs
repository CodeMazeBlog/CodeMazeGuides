namespace FactoryPatternInDependencyInjection.Library;

public class LabelGenService
{
    public string Prefix { get; }

    public string Suffix { get; }

    public LabelGenService(string prefix, string suffix)
    {
        Prefix = prefix;
        Suffix = suffix;
    }

    public string Generate()
    {
        return $"{Prefix}{DateTime.Now:yyyyMMddHHmmssfff}{Suffix}";
    }
}