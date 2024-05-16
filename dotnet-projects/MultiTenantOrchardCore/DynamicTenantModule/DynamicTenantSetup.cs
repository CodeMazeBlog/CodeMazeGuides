using OrchardCore.Environment.Shell;
using OrchardCore.Environment.Shell.Models;
using OrchardCore.Setup.Services;

namespace DynamicTenantModule;

public class DynamicTenantSetup(IShellHost shellHost)
{
    public async Task CreateTenant(string tenantName, string urlPrefix)
    {
        var shellSettings = new ShellSettings();
        
        shellSettings.Name = tenantName;
        shellSettings.RequestUrlPrefix = urlPrefix;
        shellSettings["customProperty"] = $"Custom settings for '{tenantName}'";
        
        var context = new SetupContext
        {
            ShellSettings = shellSettings,
        };
        
        context.ShellSettings.State = TenantState.Initializing;
        shellSettings.State = TenantState.Running;
        
        await shellHost.UpdateShellSettingsAsync(new ShellSettings(context.ShellSettings));
    }
}