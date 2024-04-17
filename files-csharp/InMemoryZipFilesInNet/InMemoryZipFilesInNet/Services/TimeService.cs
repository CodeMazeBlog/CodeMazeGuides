namespace InMemoryZipFilesInNet.Services;

public class TimeService : IService
{
    public string Name => "TimeService";
    public string GetData() => "Current UTC time is " +
      DateTime.UtcNow.ToString();
}
