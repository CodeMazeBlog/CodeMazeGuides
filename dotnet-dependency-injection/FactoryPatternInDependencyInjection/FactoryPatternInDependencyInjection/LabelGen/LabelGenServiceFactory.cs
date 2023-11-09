namespace FactoryPatternInDependencyInjection.LabelGen;

public class LabelGenServiceFactory
{
    private readonly LabelGenService _labelGenService;

    public LabelGenServiceFactory(IOptions<LabelGenOptions> options)
    {
        var value = options.Value;

        _labelGenService = new(value.Prefix, value.Suffix);
    }

    public LabelGenService GetLabelGenService() => _labelGenService;
}