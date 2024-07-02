using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class HeaderTests
{
    private static readonly string[] expected = ["value1", "value2"];

    [TestMethod]
    public void GivenExistingHeader_WhenNewValueAdded_ShouldStoreMultipleValues()
    {
        StringValuesImplementation.AddHeader("MyHeader", "value1");
        StringValuesImplementation.AddHeader("MyHeader", "value2");
        var values = StringValuesImplementation.GetHeaderValues("MyHeader");
        Assert.AreEqual(2, values.Count);
        CollectionAssert.AreEqual(expected, values.ToArray());
    }

    [TestMethod]
    public void GivenExistingHeaderInLegacyImplementation_WhenNewValueAdded_ShouldStoreMultipleValues()
    {
        LegacyImplementation.AddHeader("MyHeader", "value1");
        LegacyImplementation.AddHeader("MyHeader", "value2");
        var values = LegacyImplementation.GetHeaderValues("MyHeader");
        Assert.AreEqual(2, values.Length);
        CollectionAssert.AreEqual(expected, values);
    }

    [TestMethod]
    public void GivenExistingHeaderInNaiveImplementation_WhenNewValueAdded_ShouldStoreMultipleValues()
    {
        NaiveImplementation.AddHeader("MyHeader", "value1");
        NaiveImplementation.AddHeader("MyHeader", "value2");
        var values = NaiveImplementation.GetHeaderValues("MyHeader");
        Assert.AreEqual(2, values.Length);
        CollectionAssert.AreEqual(expected, values);
    }
}