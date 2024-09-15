namespace Tests.Services;

[TestClass]
public class TimeServiceTest
{
    [TestMethod]
    public void GivenService_WhenGettingName_ThenCorrectNameIsExpected()
    {
        var sut = new TimeService();
        var expectedName = "TimeService";

        var name = sut.Name;

        Assert.AreEqual(expectedName, name);
    }

    [TestMethod]
    public void GivenService_WhenGettingData_ThenCorrectDataIsExpected()
    {
        var sut = new TimeService();

        var data = sut.GetData();

        Assert.IsTrue(data.StartsWith("Current UTC time is "));
        Assert.IsTrue(DateTime.TryParse(data.Replace("Current UTC time is ", ""), out _));
    }
}
