using ForVsForeachInCSharp;

namespace ForVsForeachInCSharpTests;

[TestClass]
public class ForVsForeachUnitTests
{
    private const int size = 10;

    [TestMethod]
    public void GivenAnArray_WhenInitializedWithASpecificSize_VerifyAccurateResults()
    {
        var array = GenerateData.GenerateArray(size);

        Assert.IsInstanceOfType(array, typeof(int[]));
        Assert.IsNotNull(array);
        Assert.AreEqual(size, array.Length);
    }

    [TestMethod]
    public void GivenAList_WhenInitializedWithASpecificSize_VerifyAccurateResults()
    {
        var list = GenerateData.GenerateList(size);

        Assert.IsInstanceOfType(list, typeof(List<int>));
        Assert.IsNotNull(list);
        Assert.AreEqual(size, list.Count);
    }

    [TestMethod]
    public void GivenADictionary_WhenInitializedWithASpecificSize_VerifyAccurateResults()
    {
        var dictionary = GenerateData.GenerateDictionary(size);

        Assert.IsInstanceOfType(dictionary, typeof(Dictionary<int, int>));
        Assert.IsNotNull(dictionary);
        Assert.AreEqual(size, dictionary.Count);
    }
}