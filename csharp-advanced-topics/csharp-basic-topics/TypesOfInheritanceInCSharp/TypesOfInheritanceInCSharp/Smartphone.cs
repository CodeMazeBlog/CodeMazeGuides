namespace TypesOfInheritanceInCSharp;

public class Smartphone : MobileDevice
{
    public Smartphone() 
    {
        InstalledApps = new List<string>();
    }

    protected Smartphone(string operatingSystem)
    {
        OperatingSystem = operatingSystem;
        InstalledApps = new List<string>();
    }

    public List<string> InstalledApps { get; private set; }

    public override bool DeviceCanMakePhoneCall()
    {
        return true;
    }

    public virtual void GetDescription()
    {
        Console.WriteLine($"This smartphone is {Inches} inches big and its operating system is {OperatingSystem}");
    }

    public void ShowInstalledApps()
    {
        Console.WriteLine($"There are {InstalledApps.Count} app installed");
    }
}
