namespace BlazorbUnit;

public class MyDataService : IMyDataService
{
    public List<string> GetData() => new List<string> { "Data 1", "Data 2" };
}
