namespace ResolveIoptionsInsideProgramCs.Services;

using Microsoft.Extensions.Options;
using ResolveIoptionsInsideProgramCs.DTOs;

public class BusinessService(IOptions<MySettings> options, string tenant) : IBusinessService
{
    private readonly IOptions<MySettings> _options = options;
    private readonly string _tenant = tenant;

    public SettingsDto GetMySettings()
    {
        return new(_tenant, _options.Value.ImportantSetting);
    }
}