using SelectionSort;

namespace SelectionSortTest;

[TestClass]
public class SelectionSortUnitTest
{
    [TestMethod]
    public void GivenUnsortedArray_ThenReturnSortedArray()
    {
        var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        var sortFunction = new Selection();
        sortFunction.NumArray = array;

        var sortedArray = sortFunction.SortArray();

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenUnsortedArray_CheckInstanceType()
    {
        var sortFunction = new Selection();
        sortFunction.NumArray = Selection.AddRandomElements(200);

        var sortedArray = sortFunction.SortArray();

        Assert.IsInstanceOfType(sortedArray, typeof(int[]));
    }

    [TestMethod]
    public void GivenUnsortedArray_CheckSortedNotNull()
    {
        var sortFunction = new Selection();
        sortFunction.NumArray = Selection.AddRandomElements(200);

        var sortedArray = sortFunction.SortArray();

        Assert.IsNotNull(sortedArray);
    }

    [TestMethod]
    public void GivenRandomArray_WhenSorted_ThenMatchesArraySort()
    {
        var source = Selection.AddRandomElements(500);
        var expected = source.ToArray();
        Array.Sort(expected);

        var sortedArray = new Selection { NumArray = source.ToArray() }.SortArray();

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    [DataRow(new int[] { })]
    [DataRow(new int[] { 42 })]
    [DataRow(new int[] { 5, 3, 5, 1, 3, 5 })]
    [DataRow(new int[] { 1, 2, 3, 4, 5 })]
    [DataRow(new int[] { 5, 4, 3, 2, 1 })]
    public void GivenEdgeCaseArray_WhenSorted_ThenMatchesArraySort(int[] array)
    {
        var expected = array.ToArray();
        Array.Sort(expected);

        var sortedArray = new Selection { NumArray = array }.SortArray();

        CollectionAssert.AreEqual(expected, sortedArray);
    }
}
