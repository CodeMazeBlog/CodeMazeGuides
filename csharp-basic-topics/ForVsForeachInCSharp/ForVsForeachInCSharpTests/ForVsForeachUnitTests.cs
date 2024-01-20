using ForVsForeachInCSharp;

namespace ForVsForeachInCSharpTests;

[TestClass]
public class ForVsForeachUnitTests
{
    private readonly int _size;
    private readonly GenerateData _generateData = new();

    public ForVsForeachUnitTests() 
    {
        _size = 10;
    }

    [TestMethod]
    public void GivenAnArray_WhenInitializedWithASpecificSize_VerifyAccurateResults()
    {
        var array = _generateData.GenerateRandomArray(_size);

        Assert.IsInstanceOfType(array, typeof(int[]));
        Assert.IsNotNull(array);
        Assert.AreEqual(_size, array.Length);
    }

    [TestMethod]
    public void GivenAList_WhenInitializedWithASpecificSize_VerifyAccurateResults()
    {
        var list = _generateData.GenerateRandomList(_size);

        Assert.IsInstanceOfType(list, typeof(List<int>));
        Assert.IsNotNull(list);
        Assert.AreEqual(_size, list.Count);
    }

    [TestMethod]
    public void GivenAStack_WhenInitializedWithASpecificSize_VerifyAccurateResults()
    {
        var stack = _generateData.GenerateRandomStack(_size);

        Assert.IsInstanceOfType(stack, typeof(Stack<int>));
        Assert.IsNotNull(stack);
        Assert.AreEqual(_size, stack.Count);
    }

    [TestMethod]
    public void GivenAQueue_WhenInitializedWithASpecificSize_VerifyAccurateResults()
    {
        var queue = _generateData.GenerateRandomQueue(_size);

        Assert.IsInstanceOfType(queue, typeof(Queue<int>));
        Assert.IsNotNull(queue);
        Assert.AreEqual(_size, queue.Count);
    }

    [TestMethod]
    public void GivenADictionary_WhenInitializedWithASpecificSize_VerifyAccurateResults()
    {
        var dictionary = _generateData.GenerateRandomDictionary(_size);

        Assert.IsInstanceOfType(dictionary, typeof(Dictionary<int, int>));
        Assert.IsNotNull(dictionary);
        Assert.AreEqual(_size, dictionary.Count);
    }
}