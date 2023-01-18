using ExecuteCliExample;

var version = await new DotnetNativeWrapper().GetVersionFromScript();
System.Console.WriteLine(version);
static async Task RunNativeExample()
{
    DotnetNativeWrapper native = new();

    native.OnStdOutput += (ArraySegment<char> chunk) =>
    {
        Console.WriteLine($"CHUNK OUTPUT:");
        Console.WriteLine(new String(chunk));
    };

    native.OnStdErr += (ArraySegment<char> chunk) =>
    {
        Console.WriteLine($"CHUNK ERROR:");
        Console.WriteLine(new String(chunk));
    };

    await native.ListProjects();
}