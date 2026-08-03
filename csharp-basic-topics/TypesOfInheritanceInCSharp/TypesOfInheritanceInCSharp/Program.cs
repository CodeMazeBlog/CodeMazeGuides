using TypesOfInheritanceInCSharp;

var mobileDevice = new MobileDevice()
{
    Inches = 4.5,
    OperatingSystem = "Android",
    IsConnected = true
};


var smartphone = new Smartphone()
{
    Inches = 5.5,
    OperatingSystem = "iOS"
};

smartphone.GetDescription();
smartphone.ShowInstalledApps();

Console.WriteLine(smartphone is MobileDevice);


var androidSmartphone = new AndroidSmartphone()
{
    Inches = 4,
};

androidSmartphone.GetDescription();
androidSmartphone.DownloadAppFromStore("WhatsApp");
androidSmartphone.ShowInstalledApps();

Console.WriteLine(androidSmartphone.OperatingSystem);
Console.WriteLine(androidSmartphone is MobileDevice);


var convertibleNotebook = new ConvertibleNotebook()
{
    Inches = 11.6,
    OperatingSystem = "Windows 11",
    UsbPortNumbers = 3
};

convertibleNotebook.DeviceCanMakePhoneCall();
convertibleNotebook.WriteWithKeyboard("I can write with keyboard");

Console.WriteLine(convertibleNotebook is MobileDevice);
Console.WriteLine(convertibleNotebook is ILaptop);
