namespace Tests.Services;

[TestClass]
public class DbServiceTest
{
    [TestMethod]
    public void GivenService_WhenGettingName_ThenCorrectNameIsExpected()
    {
        var sut = new DbService();
        var expectedName = "DbService";

        var name = sut.Name;

        Assert.AreEqual(expectedName, name);
    }

    [TestMethod]
    public void GivenService_WhenGettingData_ThenCorrectDataIsExpected()
    {
        var sut = new DbService();
        var expectedData = "This is a Database service";

        var data = sut.GetData();

        Assert.AreEqual(expectedData, data);
    }
}
