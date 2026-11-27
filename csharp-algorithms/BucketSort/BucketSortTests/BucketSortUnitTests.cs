using BucketSort;

namespace BucketSortTests;

[TestClass]
public class BucketSortUnitTests
{
    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenReturnSortedArray()
    {
        var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        var sortFunction = new BucketSortMethods();

        var sortNormal = sortFunction.SortArray([73, 57, 49, 99, 133, 20, 1]);
        var sortOptimized = sortFunction.SortArrayOptimized([73, 57, 49, 99, 133, 20, 1]);

        CollectionAssert.AreEqual(expected, sortNormal);
        CollectionAssert.AreEqual(expected, sortOptimized);
    }

    [TestMethod]
    public void GivenUnsortedArray_WhenSortedWithSortArray_ThenReturnSortedArray()
    {
        var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        var sortFunction = new BucketSortMethods();

        var sortedArray = sortFunction.SortArray(array);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsRandomized_ThenCheckInstanceType()
    {
        var sortFunction = new BucketSortMethods();
        var array = BucketSortMethods.CreateRandomArray(200);

        var sortedArray = sortFunction.SortArrayOptimized(array);

        Assert.IsInstanceOfType(sortedArray, typeof(int[]));
    }

    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsSorted_ThenResultingArrayIsNotNull()
    {
        var sortFunction = new BucketSortMethods();
        var array = BucketSortMethods.CreateRandomArray(200);

        var sortedArray = sortFunction.SortArrayOptimized(array);

        Assert.IsNotNull(sortedArray);
    }

    [TestMethod]
    public void GivenArray_WhenArrayHasSingleElement_ThenReturnSortedArray()
    {
        var array = new int[] { 73 };
        var expected = new int[] { 73 };
        var sortFunction = new BucketSortMethods();

        var sortedArray = sortFunction.SortArrayOptimized(array);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    [DataRow(new int[0])]
    [DataRow(new[] { 100, 101 })]
    [DataRow(new[] { 1000, 1001, 1002 })]
    [DataRow(new[] { -50, -10, 3, -50 })]
    [DataRow(new[] { 5, 5, 5, 5 })]
    [DataRow(new[] { 42, 6, 16, 4, 12, 24, 46, 17 })]
    public void GivenEdgeCaseArray_WhenSorted_ThenBothVersionsMatchArraySort(int[] input)
    {
        var expected = (int[])input.Clone();
        Array.Sort(expected);
        var sortFunction = new BucketSortMethods();

        CollectionAssert.AreEqual(expected, sortFunction.SortArray((int[])input.Clone()));
        CollectionAssert.AreEqual(expected, sortFunction.SortArrayOptimized((int[])input.Clone()));
    }

    [TestMethod]
    public void GivenFullIntRange_WhenSorted_ThenSortArrayWorksAndOptimizedThrows()
    {
        var sortFunction = new BucketSortMethods();

        CollectionAssert.AreEqual(
            new[] { int.MinValue, 0, int.MaxValue },
            sortFunction.SortArray([int.MaxValue, int.MinValue, 0]));
        Assert.ThrowsExactly<OverflowException>(
            () => sortFunction.SortArrayOptimized([int.MaxValue, int.MinValue, 0]));
    }

    [TestMethod]
    public void GivenRandomArray_WhenSortedWithBothVersions_ThenResultsMatchArraySort()
    {
        var random = new Random(42);
        var input = Enumerable.Range(0, 1_000).Select(_ => random.Next(-500, 500)).ToArray();
        var expected = (int[])input.Clone();
        Array.Sort(expected);
        var sortFunction = new BucketSortMethods();

        CollectionAssert.AreEqual(expected, sortFunction.SortArray((int[])input.Clone()));
        CollectionAssert.AreEqual(expected, sortFunction.SortArrayOptimized((int[])input.Clone()));
    }
}
