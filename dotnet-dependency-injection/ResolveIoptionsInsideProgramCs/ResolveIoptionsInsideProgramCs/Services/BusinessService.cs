namespace ResolveIoptionsInsideProgramCs.Services;

using Microsoft.Extensions.Options;
using ResolveIoptionsInsideProgramCs.DTOs;

public class BusinessService : IBusinessService
{
    private readonly IOptions<MySettings> _options;
    private readonly string _tenant;

    public BusinessService(IOptions<MySettings> options, string tenant)
    {
        _options = options;
        _tenant = tenant;
    }

    public SettingsDto GetMySettings()
    {
        return new(_tenant, _options.Value.ImportantSetting);
    }
}