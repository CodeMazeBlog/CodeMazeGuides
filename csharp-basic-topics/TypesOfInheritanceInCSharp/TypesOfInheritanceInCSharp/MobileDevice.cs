namespace TypesOfInheritanceInCSharp;

public class MobileDevice
{
    public string OperatingSystem { get; set; } = null!;

    public double Inches { get; set; }

    public bool IsConnected { get; set; }

    public virtual bool DeviceCanMakePhoneCall()
    {
        return false;
    }
}
