using DifferencesRecordStructAndRecordClassInCSharp;

namespace Tests;

[TestClass]
public class DefaultValueTests
{
    [TestMethod]
    public void RecordStructDefaultValue_ReturnsDefaultInitializedValue()
    {
        var recordStructDefaultValue = DefaultValues.GetRecordStructDefaultValue();

        Assert.IsTrue(recordStructDefaultValue is not null);
    }

    [TestMethod]
    public void RecordClassDefaultValue_ReturnsNull()
    {
        var recordClassDefaultValue = DefaultValues.GetRecordClassDefaultValue();

        Assert.IsTrue(recordClassDefaultValue is null);
    }
}