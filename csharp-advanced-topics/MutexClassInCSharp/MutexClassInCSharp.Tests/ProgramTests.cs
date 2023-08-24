namespace MutexClassInCSharp.Tests;

public sealed class ProgramTests
{
    private readonly string _fileName = Path.GetTempFileName();

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
        => await Task.Run(() => Program.WriteNumbers(_fileName));

    private async Task EnsureFileConsistency()
    {
        var fileContents = await File.ReadAllTextAsync(_fileName);
        File.Delete(_fileName);

        var numbers = fileContents
            .TrimEnd()
            .Split(' ')
            .Select(int.Parse);

        var nextExpectedNumber = 1;

        foreach (var number in numbers)
        {
            Assert.Equal(nextExpectedNumber++, number);

            if (nextExpectedNumber > 50)
                nextExpectedNumber = 1;
        }

        Assert.Equal(1, nextExpectedNumber);
    }
}