namespace MutexClassInCSharp.Tests;

public sealed class ProgramTests
{
    private const string fileName = "numbers.txt";

    private Action<string[]> _mainMethod
        = typeof(AssemblyAccessor).Assembly.EntryPoint!.CreateDelegate<Action<string[]>>();

    public ProgramTests()
    {
        File.Delete(fileName);
    }

    [Fact]
    public async Task WhenProgramRunOnce_ThenNumbersWrittenConsistently()
    {
        await RunProgram();

        await EnsureFileConsistency();
    }

    [Fact]
    public async Task WhenProgramRunTwiceSimultaneously_ThenNumbersWrittenConsistently()
    {
        Task main1 = RunProgram();
        Task main2 = RunProgram();

        await main1;
        await main2;

        await EnsureFileConsistency();
    }

    private async Task RunProgram()
        => await Task.Run(() => _mainMethod(new string[] { }));

    private async Task EnsureFileConsistency()
    {
        string fileContents = await File.ReadAllTextAsync(fileName);
        File.Delete(fileName);

        List<int> numbers = fileContents
            .TrimEnd()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        int nextExpectedNumber = 1;

        foreach (int number in numbers)
        {
            Assert.Equal(nextExpectedNumber, number);

            nextExpectedNumber = nextExpectedNumber + 1;

            if (nextExpectedNumber > 50)
                nextExpectedNumber = 1;
        }

        Assert.Equal(1, nextExpectedNumber);
    }
}