namespace Tests.Services;

[TestClass]
public class IServiceTest
{
    [TestMethod]
    [DynamicData(nameof(GetServices), DynamicDataSourceType.Method)]
    public void GivenService_WhenGettingAsyncContent_ThenSameContentIsExpectedMultipleTime(IService service)
    {
        var expectedContent = service.GetData() + service.GetData();

        var content = service.GetDataAsync().Result;

        StringAssert.Contains(content, expectedContent);
    }

    public static IEnumerable<IService[]> GetServices()
    {
        yield return new IService[] { new FileService() };
        yield return new IService[] { new DbService() };
    }
}
