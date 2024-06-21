using OrchardCore.Environment.Shell;
using OrchardCore.Environment.Shell.Models;

namespace DynamicTenantModule;

public class DynamicTenantSetup(IShellHost shellHost, IShellSettingsManager shellSettingsManager)
{
    public async Task CreateTenant(string tenantName, string urlPrefix)
    {
        var shellSettings = new ShellSettings
        {
            Name = tenantName,
            RequestUrlHost = null,
            RequestUrlPrefix = urlPrefix,
            State = TenantState.Uninitialized,
        };
        
        shellSettings["customProperty"] = $"Custom settings for '{tenantName}'";
        
        await shellSettingsManager.SaveSettingsAsync(shellSettings);

        shellSettings.State = TenantState.Running;

        await shellHost.UpdateShellSettingsAsync(shellSettings);
    }
}