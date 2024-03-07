using App;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var memoryUseCases = new MemoryUseCases();

        // Call WorksWithBothStackAndHeap method
        memoryUseCases.WorksWithBothStackAndHeap();

        // Call StringAsMemoryExtensionMethod method
        memoryUseCases.StringAsMemoryExtensionMethod();

        // Call UseMemoryOwner method
        memoryUseCases.UseMemoryOwner();

        // Call ProcessFileAsync method
        // Replace "your_file_path" with the path to the file you want to process
        await memoryUseCases.ProcessFileAsync("./File.txt");
    }
}