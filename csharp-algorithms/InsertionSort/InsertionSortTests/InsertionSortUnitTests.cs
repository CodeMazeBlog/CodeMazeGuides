using InsertionSort;

namespace InsertionSortTests;

[TestClass]
public class InsertionSortUnitTests
{
    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenReturnSortedArray()
    {
        var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        var sortFunction = new InsertionSortMethods();

        var sortedArray = sortFunction.SortArray(array, array.Length);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsRandomized_ThenCheckInstanceType()
    {
        var sortFunction = new InsertionSortMethods();
        var array = InsertionSortMethods.CreateRandomArray(200);

        var sortedArray = sortFunction.SortArray(array, array.Length);

        Assert.IsInstanceOfType<int[]>(sortedArray);
    }

    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsSorted_ThenResultingArrayIsNotNull()
    {
        var sortFunction = new InsertionSortMethods();
        var array = InsertionSortMethods.CreateRandomArray(200);

        var sortedArray = sortFunction.SortArray(array, array.Length);

        Assert.IsNotNull(sortedArray);
    }

    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsRandomized_ThenReturnSortedArrayUsingRecursion()
    {
        var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        var sortFunction = new InsertionSortMethods();

        var sortedArray = sortFunction.SortArrayRecursive(array, array.Length);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenArray_WhenArrayHasSingleElement_ThenReturnSortedArray()
    {
        var array = new int[] { 73 };
        var expected = new int[] { 73 };
        var sortFunction = new InsertionSortMethods();

        var sortedArray = sortFunction.SortArray(array, array.Length);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    [DataRow("Random")]
    [DataRow("Sorted")]
    [DataRow("Reversed")]
    [DataRow("Duplicates")]
    [DataRow("Empty")]
    public void GivenInput_WhenSortedWithBothVersions_ThenResultsMatchArraySort(string input)
    {
        var random = new Random(42);
        int[] source = input switch
        {
            "Sorted" => InsertionSortMethods.CreateSortedArray(500),
            "Reversed" => InsertionSortMethods.CreateReversedArray(InsertionSortMethods.CreateSortedArray(500)),
            "Duplicates" => Enumerable.Range(0, 500).Select(_ => random.Next(10)).ToArray(),
            "Empty" => [],
            _ => Enumerable.Range(0, 500).Select(_ => random.Next()).ToArray()
        };
        var expected = (int[])source.Clone();
        Array.Sort(expected);
        var sortFunction = new InsertionSortMethods();

        var imperative = sortFunction.SortArray((int[])source.Clone(), source.Length);
        var recursive = sortFunction.SortArrayRecursive((int[])source.Clone(), source.Length);

        CollectionAssert.AreEqual(expected, imperative);
        CollectionAssert.AreEqual(expected, recursive);
    }
}
