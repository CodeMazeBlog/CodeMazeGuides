namespace Tests;

[TestClass]
public class AutoPropertyAssignTest
{
    [TestMethod]
    public void GivenInitialValueWithInlineInitialization_WhenPropertyAccessed_ThenExpectAssignedValue()
    {
        var hondaCars = new HondaCars();

        Assert.AreEqual("White", hondaCars.Color);
        Assert.AreEqual(500000.00m, hondaCars.Cost);
    }

    [TestMethod]
    public void GivenInitialValueWithConstructorInitialization_WhenPropertyAccessed_ThenExpectAssignedValue()
    {
        var toyotaCars = new ToyotaCars();

        Assert.AreEqual("Black", toyotaCars.Color);
        Assert.AreEqual(400000.00m, toyotaCars.Cost);
    }

    [TestMethod]
    public void GivenInitialValueWithFieldInitialization_WhenPropertyAccessed_ThenExpectAssignedValue()
    {
        var kiaCars = new KiaCars();

        Assert.AreEqual("Silver", kiaCars.Color);
        Assert.AreEqual(600000.00m, kiaCars.Cost);
    }
}
