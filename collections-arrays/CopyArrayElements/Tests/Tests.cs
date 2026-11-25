using CopyArrayElements;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class Tests
{
    private readonly ElementCopier _elementCopier = new();

    [TestMethod]
    public void GivenTheClassProgram_ThenRunTheMainMethodAndWriteResultsAtTheConsole()
    {
        Program.Main([]);

        Assert.AreEqual(1, Program.OutputResult);
    }

    [TestMethod]
    public void GivenAnInitialArray_ThenReturnSameArrayUsingTheMethodCopyUsingAssignment()
    {
        var initialArray = Program.InstantiateInitialArray();

        var destinationArray = _elementCopier.CopyUsingAssignment(initialArray);

        Assert.AreSame(initialArray, destinationArray);
    }

    [TestMethod]
    public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingArrayClass()
        => AssertShallowCopy(_elementCopier.CopyUsingArrayClass);

    [TestMethod]
    public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingClone()
        => AssertShallowCopy(_elementCopier.CopyUsingClone);

    [TestMethod]
    public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingCopyTo()
        => AssertShallowCopy(_elementCopier.CopyUsingCopyTo);

    [TestMethod]
    public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingRange()
        => AssertShallowCopy(_elementCopier.CopyUsingRange);

    [TestMethod]
    public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingSpan()
        => AssertShallowCopy(_elementCopier.CopyUsingSpan);

    [TestMethod]
    public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingCollectionExpression()
        => AssertShallowCopy(_elementCopier.CopyUsingCollectionExpression);

    [TestMethod]
    public void GivenAnInitialArray_ThenReturnNewArrayUsingTheMethodCopyUsingToArray()
        => AssertShallowCopy(_elementCopier.CopyUsingToArray);

    [TestMethod]
    public void GivenAnInitialArray_ThenCopyLastTwoElementsUsingTheMethodCopyPartUsingArrayClass()
    {
        var initialArray = Program.InstantiateInitialArray();

        var destinationArray = _elementCopier.CopyPartUsingArrayClass(initialArray);

        Assert.AreEqual(initialArray.Length, destinationArray.Length);
        Assert.AreSame(initialArray[1], destinationArray[0]);
        Assert.AreSame(initialArray[2], destinationArray[1]);
        Assert.IsNull(destinationArray[2]);
    }

    [TestMethod]
    public void GivenAnInitialArray_ThenCopyIndexOneAndTwoUsingTheMethodCopyPartUsingRange()
    {
        var initialArray = Program.InstantiateInitialArray();

        var destinationArray = _elementCopier.CopyPartUsingRange(initialArray);

        Assert.AreEqual(2, destinationArray.Length);
        Assert.AreSame(initialArray[1], destinationArray[0]);
        Assert.AreSame(initialArray[2], destinationArray[1]);
    }

    [TestMethod]
    public void GivenAnInitialArray_ThenCopyIndexOneAndTwoUsingTheMethodCopyPartUsingSpan()
    {
        var initialArray = Program.InstantiateInitialArray();

        var destinationArray = _elementCopier.CopyPartUsingSpan(initialArray);

        Assert.AreEqual(initialArray.Length, destinationArray.Length);
        Assert.AreSame(initialArray[1], destinationArray[0]);
        Assert.AreSame(initialArray[2], destinationArray[1]);
        Assert.IsNull(destinationArray[2]);
    }

    [TestMethod]
    public void GivenAnInitialArray_ThenReturnDeepCopyUsingTheMethodCopyUsingLinq()
        => AssertDeepCopy(_elementCopier.CopyUsingLinq);

    [TestMethod]
    public void GivenAnInitialArray_ThenReturnDeepCopyUsingTheMethodManuallyCopy()
        => AssertDeepCopy(_elementCopier.ManuallyCopy);

    [TestMethod]
    public void GivenAShallowCopy_WhenAnElementChangesThroughTheCopy_ThenTheSourceSeesTheChange()
    {
        var initialArray = Program.InstantiateInitialArray();
        var destinationArray = _elementCopier.CopyUsingArrayClass(initialArray);

        destinationArray[0].Title = "Changed through the copy";

        Assert.AreEqual("Changed through the copy", initialArray[0].Title);
    }

    private static void AssertShallowCopy(Func<Article[], Article[]> copy)
    {
        var initialArray = Program.InstantiateInitialArray();

        var destinationArray = copy(initialArray);

        Assert.AreNotSame(initialArray, destinationArray);
        Assert.AreEqual(initialArray.Length, destinationArray.Length);
        Assert.AreSame(initialArray[0], destinationArray[0]);
    }

    private static void AssertDeepCopy(Func<Article[], Article[]> copy)
    {
        var initialArray = Program.InstantiateInitialArray();

        var destinationArray = copy(initialArray);

        Assert.AreNotSame(initialArray, destinationArray);
        Assert.AreEqual(initialArray.Length, destinationArray.Length);
        Assert.AreNotSame(initialArray[0], destinationArray[0]);
        Assert.AreEqual(initialArray[0].Title, destinationArray[0].Title);
    }
}
