using System.Text;

namespace InMemoryZipFilesInNet.Services;

public interface IService
{
    public string Name { get; }

    public string GetData();

    public async Task<string> GetDataAsync()
    {
        await Task.Delay(1000);

        var repeatCount = 10_000;
        var source = GetData();
        StringBuilder sb = new StringBuilder(repeatCount * source.Length);
        for (int count = 0; count < repeatCount; count++)
        {
            sb.Append(source);
        }

        return sb.ToString();
    }
}
