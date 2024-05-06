using OrchardCore.Environment.Shell;
using OrchardCore.Environment.Shell.Models;
using OrchardCore.Setup.Services;

namespace DynamicTenantModule;

public class DynamicTenantSetup(IShellHost shellHost)
{
    public async Task CreateTenant()
    {
        var shellSettings = new ShellSettings();
        
        shellSettings.Name = "CustomerC";
        shellSettings.RequestUrlPrefix = "customer-c";
        shellSettings["customProperty"] = "Custom settings for Customer C";
        
        var context = new SetupContext
        {
            ShellSettings = shellSettings,
        };
        
        context.ShellSettings.State = TenantState.Initializing;
        shellSettings.State = TenantState.Running;
        
        await shellHost.UpdateShellSettingsAsync(new ShellSettings(context.ShellSettings));
    }
}