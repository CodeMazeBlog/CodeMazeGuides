using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class HeaderTests
{
    private static readonly string[] expected = ["value1", "value2"];

    [TestMethod]
    public void GivenExistingHeader_WhenNewValueAdded_ShouldStoreMultipleValues()
    {
        StringValuesImplementation stringValuesImplementation = new(); 
        stringValuesImplementation.AddHeader("MyHeader", "value1", "value2");
        var values = stringValuesImplementation.GetHeaderValues("MyHeader");
        Assert.AreEqual(2, values.Count);
        CollectionAssert.AreEqual(expected, values.ToArray());
    }

    [TestMethod]
    public void GivenExistingHeaderInLegacyImplementation_WhenNewValueAdded_ShouldStoreMultipleValues()
    {
        LegacyImplementation legacyImplementation = new();
        legacyImplementation.AddHeader("MyHeader", "value1", "value2");
        var values = legacyImplementation.GetHeaderValues("MyHeader");
        Assert.AreEqual(2, values.Length);
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void GivenExistingHeaderInNaiveImplementation_WhenNewValueAdded_ShouldStoreMultipleValues()
    {
        NaiveImplementation naiveImplementation = new();
        naiveImplementation.AddHeader("MyHeader", "value1", "value2");
        var values = naiveImplementation.GetHeaderValues("MyHeader");
        Assert.AreEqual(2, values.Length);
        CollectionAssert.AreEqual(expected, values);
    }
}