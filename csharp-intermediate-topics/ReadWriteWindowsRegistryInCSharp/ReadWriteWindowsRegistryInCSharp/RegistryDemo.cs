using Microsoft.Win32;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ReadWriteWindowsRegistryInCSharp;

public class RegistryDemo
{
    private static readonly string CodeMazeRegistryDemoSubKey = "CodeMazeRegistryDemoSubKey";
    private static readonly string CodeMazeRegistryDemoName = "CodeMazeRegistryDemoName";
    public static readonly string CodeMazeRegistryDemoValue = "CodeMazeRegistryDemoValue";

    public static string GetCurrentUserRootKeyName()
    {
        return Registry.CurrentUser.Name;
    }

    public static string GetCurrentUserRootKeyNameWithPlatformCheck()
    {
        if (!OperatingSystem.IsWindows())
        {
            return "Not supported platform";
        }

        return Registry.CurrentUser.Name;
    }

    public static int GetCurrentUserRootKeySubkeyCount()
    {
        if (!OperatingSystem.IsWindows())
        {
            return -1;
        }

        return Registry.CurrentUser.SubKeyCount;
    }

    public static string ReadAndWriteRegistryValueUsingRegistryClass()
    {
        if (!OperatingSystem.IsWindows())
        {
            return string.Empty;
        }

        var subKeyToWrite = Registry.CurrentUser + "\\" + CodeMazeRegistryDemoSubKey;

        Registry.SetValue(subKeyToWrite, CodeMazeRegistryDemoName, CodeMazeRegistryDemoValue);
        var writtenValue = Registry.GetValue(subKeyToWrite, CodeMazeRegistryDemoName, string.Empty);

        Registry.CurrentUser.DeleteSubKey(CodeMazeRegistryDemoSubKey);

        return writtenValue?.ToString() ?? string.Empty;
    }

    public static string ReadAndWriteRegistryValueUsingRegistryKeyClass()
    {
        if (!OperatingSystem.IsWindows())
        {
            return string.Empty;
        }

        var baseKey = Registry.CurrentUser;

        var subKey = baseKey.OpenSubKey(CodeMazeRegistryDemoSubKey, true);
        subKey ??= baseKey.CreateSubKey(CodeMazeRegistryDemoSubKey);

        subKey.SetValue(CodeMazeRegistryDemoName, CodeMazeRegistryDemoValue);
        var writtenValue = subKey.GetValue(CodeMazeRegistryDemoName);
        subKey.DeleteValue(CodeMazeRegistryDemoName);
        subKey.Close();

        baseKey.DeleteSubKey(CodeMazeRegistryDemoSubKey);

        return writtenValue?.ToString() ?? string.Empty;
    }

    public static string[] GetSubKeyNames()
    {
        if (!OperatingSystem.IsWindows())
        {
            return Array.Empty<string>();
        }

        var subKey = Registry.CurrentUser.CreateSubKey(CodeMazeRegistryDemoSubKey);
        subKey.CreateSubKey("SubKey1");
        subKey.CreateSubKey("SubKey2");

        var subKeyNames = subKey.GetSubKeyNames();

        Registry.CurrentUser.DeleteSubKeyTree(CodeMazeRegistryDemoSubKey);

        return subKeyNames;
    }

    public static string[] GetValueNames()
    {
        if (!OperatingSystem.IsWindows())
        {
            return Array.Empty<string>();
        }

        var subKey = Registry.CurrentUser.CreateSubKey(CodeMazeRegistryDemoSubKey);
        var subKey1 = subKey.CreateSubKey("SubKey1");
        subKey1.SetValue("Name1", "Value1");
        subKey1.SetValue("Name2", "Value2");

        var subKeyNames = subKey1.GetValueNames();

        Registry.CurrentUser.DeleteSubKeyTree(CodeMazeRegistryDemoSubKey);

        return subKeyNames;
    }

    public static string GetValueKind()
    {
        if (!OperatingSystem.IsWindows())
        {
            return string.Empty;
        }

        var subKey = Registry.CurrentUser.CreateSubKey(CodeMazeRegistryDemoSubKey);
        var subKey1 = subKey.CreateSubKey("SubKey1");
        subKey1.SetValue("Name1", "Value1");

        var valueKind = subKey1.GetValueKind("Name1");

        Registry.CurrentUser.DeleteSubKeyTree(CodeMazeRegistryDemoSubKey);

        return valueKind.ToString();
    }

    public static bool SetRegistryKeyAccessPermissions()
    {
        if (!OperatingSystem.IsWindows())
        {
            return false;
        }

        var user = Environment.UserDomainName + "\\" + Environment.UserName;
        var registrySecurity = new RegistrySecurity();

        var accessRule = new RegistryAccessRule(user,
            RegistryRights.ReadKey | RegistryRights.WriteKey,
            InheritanceFlags.None,
            PropagationFlags.None,
            AccessControlType.Allow);

        registrySecurity.AddAccessRule(accessRule);

        var subKey = Registry.CurrentUser.CreateSubKey(CodeMazeRegistryDemoSubKey, RegistryKeyPermissionCheck.Default, registrySecurity);

        var isAdded = false;
        var accessControl = subKey.GetAccessControl();
        var accessRules = accessControl.GetAccessRules(true, true, typeof(NTAccount));
        foreach (RegistryAccessRule rule in accessRules)
        {
            if (rule.IdentityReference.Value == user)
            {
                isAdded = true;
                break;
            }
        }

        Registry.CurrentUser.DeleteSubKeyTree(CodeMazeRegistryDemoSubKey);

        return isAdded;
    }

    public static bool OpenRemoteBaseKey(string machineName)
    {
        if (!OperatingSystem.IsWindows())
        {
            return false;
        }

        try
        {
            var remoteBaseKey = RegistryKey.OpenRemoteBaseKey(RegistryHive.CurrentUser, machineName);
            return true;
        }
        catch
        {
            return false;
        }
    }
}