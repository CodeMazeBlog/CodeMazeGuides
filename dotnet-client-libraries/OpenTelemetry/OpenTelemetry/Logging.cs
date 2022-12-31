using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTelemetry;
public class Logging : IPillar
{
    private readonly ILogger _logger;

    public Logging(ILogger logger)
	{
        _logger = logger;
    }

    public async Task Start()
    {
        var url = "https://code-mae.com";
        _logger.Information("Starting request to {Url}", url);
    }
}
