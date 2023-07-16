public class Program
{

    public static void WriteMessageUsingAction()
    {
        Action<string> writeAction = Console.WriteLine;
        writeAction("first message");
    }

    public static void WriteGreetingUsingActionLambda()
    {
        Action<string, string> writeAction = (string firstName, string lastName) => Console.WriteLine($"Hello, {firstName} {lastName}!");
        writeAction("John", "Doe");
    }

    public static void WriteHelloWorldUsingAction()
    {
        Action writeHelloWorldAction = () => Console.WriteLine("Hello, World!");

        writeHelloWorldAction();
    }

    public static void WriteGreetingUsingActionDelegate()
    {
        Action<string, string> writeAction = delegate (string firstName, string lastName) { Console.WriteLine($"Hello, {firstName} {lastName}!"); };
        writeAction("John", "Doe");
    }

    public static void CountAndPrintDevelopmentToolsUsingFunc()
    {
        var softwareList = new List<SoftwareInfo>
        {
            new SoftwareInfo("Microsoft Office 2019", isDevelopmentSoftware: false),
            new SoftwareInfo("Visual Studio 2022", isDevelopmentSoftware: true),
            new SoftwareInfo("Microsoft SQL Server Management Studio 18", isDevelopmentSoftware: true)
        };

        Func<SoftwareInfo, bool> isDevelopmentSoftwareFunc = s => s.IsDevelopmentSoftware;

        int developmentToolsCount = softwareList.Count(isDevelopmentSoftwareFunc);

        Console.WriteLine($"Found {developmentToolsCount} results:");

        if (developmentToolsCount > 0)
        {
            Func<SoftwareInfo, object> sortFunc = s => s.Name;

            IEnumerable<SoftwareInfo> resultList = softwareList
                .Where(isDevelopmentSoftwareFunc)
                .OrderBy(sortFunc);

            foreach(var softwareItem in resultList)
            {
                Console.WriteLine(softwareItem);
            }
        }
    }

    public static void Main()
    {
        WriteMessageUsingAction();
        WriteGreetingUsingActionLambda();
        WriteHelloWorldUsingAction();
        WriteGreetingUsingActionDelegate();
        CountAndPrintDevelopmentToolsUsingFunc();
    }
}
