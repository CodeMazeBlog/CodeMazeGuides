using ShellSort;

namespace ShellSortTests;

[TestClass]
public class ShellSortUnitTests
{
    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenReturnSortedArray()
    {
        var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        var sortFunction = new ShellSortMethods();

        var sortedArray = sortFunction.ShellSort(array, array.Length);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsRandomized_ThenCheckInstanceType()
    {
        var sortFunction = new ShellSortMethods();
        var array = ShellSortMethods.CreateRandomArray(200, 0, 200);

        var sortedArray = sortFunction.ShellSort(array, array.Length);

        Assert.IsInstanceOfType(sortedArray, typeof(int[]));
    }

    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsSorted_ThenResultingArrayIsNotNull()
    {
        var sortFunction = new ShellSortMethods();
        var array = ShellSortMethods.CreateRandomArray(200, 0, 200);

        var sortedArray = sortFunction.ShellSort(array, array.Length);

        Assert.IsNotNull(sortedArray);
    }

    [TestMethod]
    public void GivenArray_WhenArrayHasSingleElement_ThenReturnSortedArray()
    {
        var array = new int[] { 73 };
        var expected = new int[] { 73 };
        var sortFunction = new ShellSortMethods();

        var sortedArray = sortFunction.ShellSort(array, array.Length);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenEmptyArray_WhenSorted_ThenReturnEmptyArray()
    {
        var sortFunction = new ShellSortMethods();

        var sortedArray = sortFunction.ShellSort([], 0);

        Assert.IsEmpty(sortedArray);
    }

    [TestMethod]
    [DataRow("Random")]
    [DataRow("Sorted")]
    [DataRow("Imbalanced")]
    public void GivenGeneratedArray_WhenSorted_ThenMatchesArraySort(string input)
    {
        var array = input switch
        {
            "Random" => ShellSortMethods.CreateRandomArray(1_000, 0, 50),
            "Sorted" => ShellSortMethods.CreateSortedArray(1_000),
            _ => ShellSortMethods.CreateImbalancedArray(1_024, 1, 2_000_000)
        };
        var expected = (int[])array.Clone();
        Array.Sort(expected);
        var sortFunction = new ShellSortMethods();

        var sortedArray = sortFunction.ShellSort(array, array.Length);

        CollectionAssert.AreEqual(expected, sortedArray);
    }
}
