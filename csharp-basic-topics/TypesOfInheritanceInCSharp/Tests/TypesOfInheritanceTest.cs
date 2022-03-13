using System;
using System.IO;
using TypesOfInheritanceInCSharp;
using Xunit;

namespace TypesOfInheritanceInCSharpTests;

public class TypesOfInheritanceTest
{
    [Fact]
    public void WhenHaveSmartphone_ThenItIsMobileDevice()
    {
        var smartphone = new Smartphone();

        Assert.True(smartphone is MobileDevice);
    }

    [Fact]
    public void WhenHaveAndroidsmartphone_ThenItIsSmartphone()
    {
        var smartphone = new AndroidSmartphone();

        Assert.True(smartphone is Smartphone);
    }

    [Fact]
    public void WhenHaveAndroidsmartphone_ThenItIsMobileDevice()
    {
        var smartphone = new AndroidSmartphone();

        Assert.True(smartphone is MobileDevice);
    }

    [Fact]
    public void WhenHaveConvertibleNotebook_ThenItIsMobileDevice()
    {
        var smartphone = new ConvertibleNotebook();

        Assert.True(smartphone is MobileDevice);
    }

    [Fact]
    public void WhenHaveConvertibleNotebook_ThenItIsLaptop()
    {
        var smartphone = new ConvertibleNotebook();

        Assert.True(smartphone is ILaptop);
    }

    [Fact]
    public void WhenHaveSmartphone_ThenItOverridesDeviceCanMakePhoneCall()
    {
        var smartphone = new Smartphone();
        smartphone.OperatingSystem = "iOS";
        smartphone.Inches = 10;

        Assert.True(smartphone.DeviceCanMakePhoneCall());
    }

    [Fact]
    public void WhenHaveAndroidSmarthone_ThenItOverrideGetDescription()
    {
        var androidSmartphone = new AndroidSmartphone();
        using var sw = new StringWriter();

        Console.SetOut(sw);
        androidSmartphone.GetDescription();
        var expected = string.Format($"This Android smarphone is {androidSmartphone.Inches} inches big, and {androidSmartphone.InstalledApps.Count} apps downloaded from Google Store{Environment.NewLine}");

        Assert.Equal(expected, sw.ToString());
    }

    [Fact]
    public void WhenHaveAndroidSmartphone_ThenWeCanCallShowInstalledApps()
    {
        var androidSmartphone = new AndroidSmartphone();
        using var sw = new StringWriter();

        Console.SetOut(sw);
        androidSmartphone.ShowInstalledApps();
        var expected = $"There are {androidSmartphone.InstalledApps.Count} app installed{Environment.NewLine}";

        Assert.Equal(expected, sw.ToString());
    }

    [Fact]
    public void WhenHaveAndroidSmartphone_ThenWeDownloadAppFromGoogleStore()
    {
        var androidSmartphone = new AndroidSmartphone();
        var appToDownload = "antivirus";
        using var sw = new StringWriter();

        Console.SetOut(sw);
        androidSmartphone.DownloadAppFromStore(appToDownload);
        var expected = $"I downloaded {appToDownload} from Google Store{Environment.NewLine}";

        Assert.Equal(expected, sw.ToString());
    }

    [Fact]
    public void WhenHaveConvertibleNotebook_ThenItOverridesDeviceCanMakePhoneCall()
    {
        var convertibleNotebook = new ConvertibleNotebook();
        convertibleNotebook.OperatingSystem = "Linux";
        convertibleNotebook.Inches = 10;
        convertibleNotebook.IsConnected = false;

        Assert.False(convertibleNotebook.DeviceCanMakePhoneCall());
    }

    [Fact]
    public void WhenHaveConvertibleNotebook_ThenItImplementsWriteWithKeyboard()
    {
        var convertibleNotebook = new ConvertibleNotebook();
        using var sw = new StringWriter();

        Console.SetOut(sw);
        convertibleNotebook.WriteWithKeyboard("This is a message");
        var expected = $"This is a message{Environment.NewLine}";

        Assert.Equal(expected, sw.ToString());
    }
}