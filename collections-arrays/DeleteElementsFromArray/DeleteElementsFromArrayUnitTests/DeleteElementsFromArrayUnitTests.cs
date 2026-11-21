using DeleteElementsFromAnArray;

namespace Tests;

[TestClass]
public class DeleteElementsFromArrayUnitTests
{
    private readonly int[] _myArray = [3, 4, 5, 3, 5, 7];

    [TestMethod]
    public void GivenMethodFindAll_WhenDeleteElement3_ThenArray4557()
    {
        var value = Methods.DeleteWithFindAll(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodFindAll_WhenDeleteElement6_ThenArray345357()
    {
        var value = Methods.DeleteWithFindAll(_myArray, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodWhere_WhenDeleteElement3_ThenArray4557()
    {
        var value = Methods.DeleteWithWhere(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodWhere_WhenDeleteElement6_ThenArray345357()
    {
        var value = Methods.DeleteWithWhere(_myArray, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodRemoveAll_WhenDeleteElement3_ThenArray4557()
    {
        var value = Methods.DeleteWithRemoveAll(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodRemoveAll_WhenDeleteElement6_ThenArray345357()
    {
        var value = Methods.DeleteWithRemoveAll(_myArray, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodLoop_WhenDeleteElement3_ThenArray45357()
    {
        var value = Methods.DeleteWithLoop(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodLoop_WhenDeleteElement6_ThenArray345357()
    {
        var value = Methods.DeleteWithLoop(_myArray, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodLoopAndResize_WhenDeleteElement3_ThenArray45357()
    {
        var array = (int[])_myArray.Clone();

        Methods.DeleteWithLoopAndResize(ref array, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 3, 5, 7 }, array);
    }

    [TestMethod]
    public void GivenMethodLoopAndResize_WhenDeleteElement6_ThenArray345357()
    {
        var array = (int[])_myArray.Clone();

        Methods.DeleteWithLoopAndResize(ref array, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, array);
    }

    [TestMethod]
    public void GivenMethodArrayCopy_WhenDeleteElement3_ThenArray45357()
    {
        var value = Methods.DeleteWithArrayCopy(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodArrayCopy_WhenDeleteElement6_ThenArray345357()
    {
        var value = Methods.DeleteWithArrayCopy(_myArray, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodArraySegment_WhenDeleteElement3_ThenArray45357()
    {
        var value = Methods.DeleteWithArraySegment(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodArraySegment_WhenDeleteElement6_ThenArray345357()
    {
        var value = Methods.DeleteWithArraySegment(_myArray, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodBufferCopy_WhenDeleteElement3_ThenArray45357()
    {
        var value = Methods.DeleteWithBufferCopy(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodBufferCopy_WhenDeleteElement6_ThenArray345357()
    {
        var value = Methods.DeleteWithBufferCopy(_myArray, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodCollectionExpression_WhenDeleteElement3_ThenArray45357()
    {
        var value = Methods.DeleteWithCollectionExpression(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodCollectionExpression_WhenDeleteElement7_ThenArray34535()
    {
        var value = Methods.DeleteWithCollectionExpression(_myArray, 7);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5 }, value);
    }

    [TestMethod]
    public void GivenMethodCollectionExpression_WhenDeleteElement6_ThenArray345357()
    {
        var value = Methods.DeleteWithCollectionExpression(_myArray, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodList_WhenDeleteElement3_ThenArray4557()
    {
        var value = Methods.DeleteWithList(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenMethodList_WhenDeleteElement6_ThenArray345357()
    {
        var value = Methods.DeleteWithList(_myArray, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenPooledArray_WhenDeleteElement3_ThenArray4557()
    {
        var value = Methods.DeleteWithPooledArray(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 4, 5, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenPooledArray_WhenDeleteElement6_ThenArray345357()
    {
        var value = Methods.DeleteWithPooledArray(_myArray, 6);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenAnArray_WhenDeleteFirstElement_ThenArray45357()
    {
        var value = Methods.DeleteFirstElement(_myArray);

        CollectionAssert.AreEqual(new int[] { 4, 5, 3, 5, 7 }, value);
    }

    [TestMethod]
    public void GivenAnyDeleteMethod_WhenDeleteElement3_ThenInputArrayIsUnchanged()
    {
        Methods.DeleteWithArrayCopy(_myArray, 3);
        Methods.DeleteWithCollectionExpression(_myArray, 3);
        Methods.DeleteWithWhere(_myArray, 3);
        Methods.DeleteWithPooledArray(_myArray, 3);

        CollectionAssert.AreEqual(new int[] { 3, 4, 5, 3, 5, 7 }, _myArray);
    }
}
