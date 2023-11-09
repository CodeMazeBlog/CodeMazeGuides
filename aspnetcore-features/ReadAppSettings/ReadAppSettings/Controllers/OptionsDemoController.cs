using Microsoft.Extensions.Options;

namespace ReadAppSettings.Controllers;

[Route("options")]
[ApiController]
public class OptionsDemoController : ControllerBase
{
    private readonly FormatSettings _formatSettings;

    public OptionsDemoController(IOptions<FormatSettings> options)
    {
        _formatSettings = options.Value;
    }

    [HttpGet("formatting")]
    public FormatSettings Get() => _formatSettings;
}