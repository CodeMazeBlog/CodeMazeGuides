namespace Tests.Services;

[TestClass]
public class FileServiceTest
{
    [TestMethod]
    public void GivenService_WhenGettingName_ThenCorrectNameIsExpected()
    {
        var sut = new FileService();
        var expectedName = "FileService";

        var name = sut.Name;

        Assert.AreEqual(expectedName, name);
    }

    [TestMethod]
    public void GivenService_WhenGettingData_ThenCorrectDataIsExpected()
    {
        var sut = new FileService();
        var expectedData = "This is a file service";

        var data = sut.GetData();

        Assert.AreEqual(expectedData, data);
    }
}
