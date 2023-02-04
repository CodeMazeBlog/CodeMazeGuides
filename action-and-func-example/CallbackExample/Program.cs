class Program
{
    static void Main(string[] args)
    {
        ReadFileAsync("file.txt", (text) => { Console.WriteLine("File contents: " + text); });
    }
    static async void ReadFileAsync(string fileName, Action<string> callback)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string text = await reader.ReadToEndAsync(); callback(text);
        }
    }
}
