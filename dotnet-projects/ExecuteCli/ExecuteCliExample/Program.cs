using ExecuteCliExample;

await RunNativeExample();

static async Task RunInvalidCommandExample()
{
    DotnetNativeWrapper native = new();
    var (exitCode, errorOutput) = await native.RunInvalidCommand();

    Console.WriteLine($"ExitCode: {exitCode}");
    Console.WriteLine($"ErrorLogs: \n{errorOutput}");
}

static async Task RunNativeExample()
{
    DotnetNativeWrapper native = new();

    native.OnStdOutput += (string chunk) =>
    {
        Console.WriteLine($"CHUNK OUTPUT : \n{chunk}");
    };

    native.OnStdErr += (string chunk) =>
    {
        Console.WriteLine($"CHUNK ERROR : \n{chunk}");
    };

    await native.ListProjects();
}