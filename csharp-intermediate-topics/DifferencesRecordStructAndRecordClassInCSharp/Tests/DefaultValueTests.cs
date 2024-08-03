using DifferencesRecordStructAndRecordClassInCSharp;

namespace Tests;

[TestClass]
public class DefaultValueTests
{
    [TestMethod]
    public void GivenRecordStruct_WhenGetDefaultValue_ThenReturnsDefaultInitializedValues()
    {
        var recordStructDefaultValue = DefaultValues.GetRecordStructDefaultValue();

        Assert.IsTrue(recordStructDefaultValue is not null);
    }

    [TestMethod]
    public void GivenRecordClass_WhenGetDefaultValue_ThenReturnsNull()
    {
        var recordClassDefaultValue = DefaultValues.GetRecordClassDefaultValue();

        Assert.IsTrue(recordClassDefaultValue is null);
    }
}