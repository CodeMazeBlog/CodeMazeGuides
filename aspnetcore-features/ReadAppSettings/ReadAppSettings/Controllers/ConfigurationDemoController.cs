namespace ReadAppSettings.Controllers;

[Route("config")]
[ApiController]
public class ConfigurationDemoController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public ConfigurationDemoController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("formatting/islocalized")]
    public bool GetIsLocalized()
    {
        var localize = _configuration.GetValue<bool>("Formatting:Localize");

        return localize;
    }

    [HttpGet("formatting/number/precision")]
    public int GetNumberPrecision()
    {
        var precision = _configuration.GetValue<int>("Formatting:Number:Precision");

        return precision;
    }

    [HttpGet("formatting")]
    public FormatSettings GetFormatting()
    {
        var formatSettings = _configuration.GetSection("Formatting").Get<FormatSettings>();

        return formatSettings;
    }
}
