using ReadWriteWindowsRegistryInCSharp;

Console.WriteLine($"CurrentUser root key name: {RegistryDemo.GetCurrentUserRootKeyName()}.");
Console.WriteLine($"CurrentUser root key name with platform check: {RegistryDemo.GetCurrentUserRootKeyNameWithPlatformCheck()}.");
Console.WriteLine($"CurrentUser root key subkeys count: {RegistryDemo.GetCurrentUserRootKeySubkeyCount()}.");

Console.WriteLine($"Read and Write value {RegistryDemo.ReadAndWriteRegistryValueUsingRegistryClass()} using Registry class.");
Console.WriteLine($"Read and Write value {RegistryDemo.ReadAndWriteRegistryValueUsingRegistryKeyClass()} using RegistryKey class.");

var subKeyNames = RegistryDemo.GetSubKeyNames();
Console.WriteLine("Subkeys names: ");
foreach (var subKeyName in subKeyNames)
{
    Console.WriteLine(subKeyName);
}

var valueNames = RegistryDemo.GetValueNames();
Console.WriteLine("Value names base key: ");
foreach (var valueName in valueNames)
{
    Console.WriteLine(valueName);
}

Console.WriteLine($"Get ValueKind: {RegistryDemo.GetValueKind()}.");

Console.WriteLine($"Set registry key access permissions done: {RegistryDemo.SetRegistryKeyAccessPermissions()}.");
Console.WriteLine($"Accesing the remote registry: {RegistryDemo.OpenRemoteBaseKey("machineName")}.");