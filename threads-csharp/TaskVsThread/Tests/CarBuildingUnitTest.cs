using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaskVsThread;

[TestClass]
public class CarBuildingUnitTest
{
    [TestMethod]
    public void GivenBuildingWithThread_WhenSpecificsAreCorrect_ThenProcessSucceeds()
    {
        CarBuildingWithThread.Build(300, 4);
    }

    [TestMethod]
    public void GivenBuildingWithTask_WhenSpecificsAreCorrect_ThenProcessSucceeds()
    {
        CarBuildingWithTask.Build(300, 4);
    }

    [TestMethod]
    public void GivenBuildingWithTask_WhenCarWeighsTooMuch_ThenProcessFails()
    {
        Assert.ThrowsException<ArgumentException>(() => CarBuildingWithTask.Build(100, 2));
    }

    [TestMethod]
    public void GivenBuildingWithThread_WhenCarWeighsTooMuch_ThenProcessFails()
    {
        Assert.ThrowsException<ArgumentException>(() => CarBuildingWithThread.Build(100, 2));
    }
}
