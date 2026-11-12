using RadixSort;

namespace RadixSortTests;

[TestClass]
public class RadixSortUnitTests
{
    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenReturnSortedArray()
    {
        var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        var sortFunction = new RadixSortMethods();

        var sortedArray = sortFunction.RadixSort(array, array.Length);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsRandomized_ThenCheckInstanceType()
    {
        var sortFunction = new RadixSortMethods();
        var array = RadixSortMethods.CreateRandomArray(200, 0, 200);

        var sortedArray = sortFunction.RadixSort(array, array.Length);

        Assert.IsInstanceOfType(sortedArray, typeof(int[]));
    }

    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsSorted_ThenResultingArrayIsNotNull()
    {
        var sortFunction = new RadixSortMethods();
        var array = RadixSortMethods.CreateRandomArray(200, 0, 200);

        var sortedArray = sortFunction.RadixSort(array, array.Length);

        Assert.IsNotNull(sortedArray);
    }

    [TestMethod]
    public void GivenArray_WhenArrayHasSingleElement_ThenReturnSortedArray()
    {
        var array = new int[] { 73 };
        var expected = new int[] { 73 };
        var sortFunction = new RadixSortMethods();

        var sortedArray = sortFunction.RadixSort(array, array.Length);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenEmptyArray_WhenSorted_ThenReturnEmptyArray()
    {
        var sortFunction = new RadixSortMethods();

        var sortedArray = sortFunction.RadixSort([], 0);

        Assert.IsEmpty(sortedArray);
    }

    [TestMethod]
    public void GivenRandomArrayWithDuplicates_WhenSorted_ThenMatchesArraySort()
    {
        var sortFunction = new RadixSortMethods();
        var array = RadixSortMethods.CreateRandomArray(1000, 0, 50);
        var expected = (int[])array.Clone();
        Array.Sort(expected);

        var sortedArray = sortFunction.RadixSort(array, array.Length);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenSortedArray_WhenSorted_ThenStaysSorted()
    {
        var sortFunction = new RadixSortMethods();
        var array = RadixSortMethods.CreateSortedArray(500);
        var expected = (int[])array.Clone();

        var sortedArray = sortFunction.RadixSort(array, array.Length);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenArrayWithIntMaxValue_WhenSorted_ThenMatchesArraySort()
    {
        var sortFunction = new RadixSortMethods();
        var array = RadixSortMethods.CreateImbalancedArray(
            RadixSortMethods.CreateRandomArray(999, 10000, 30000));
        var expected = (int[])array.Clone();
        Array.Sort(expected);

        var sortedArray = sortFunction.RadixSort(array, array.Length);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenArrayWithNegativeNumbers_WhenSortedWithNegatives_ThenMatchesArraySort()
    {
        var sortFunction = new RadixSortMethods();
        var array = RadixSortMethods.CreateRandomArray(1000, -5000, 5000);
        var expected = (int[])array.Clone();
        Array.Sort(expected);

        var sortedArray = sortFunction.RadixSortWithNegatives(array, array.Length);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenRangeWiderThanInt_WhenSortedWithNegatives_ThenThrowsOverflowException()
    {
        var sortFunction = new RadixSortMethods();
        var array = new int[] { int.MaxValue, 0, int.MinValue };

        Assert.ThrowsExactly<OverflowException>(
            () => sortFunction.RadixSortWithNegatives(array, array.Length));
    }
}
