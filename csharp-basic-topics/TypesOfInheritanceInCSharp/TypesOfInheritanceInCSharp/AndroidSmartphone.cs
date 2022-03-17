namespace TypesOfInheritanceInCSharp;

public class AndroidSmartphone : Smartphone
{
    public AndroidSmartphone() : base(operatingSystem: "Android")
    {
    }

    public override sealed void GetDescription()
    {
        Console.WriteLine($"This Android smarphone is {Inches} inches big, and {InstalledApps.Count} apps downloaded from Google Store");
    }

    public void DownloadAppFromStore(string app)
    {
        InstalledApps.Add(app);
        Console.WriteLine($"I downloaded {app} from Google Store");
    }
}
