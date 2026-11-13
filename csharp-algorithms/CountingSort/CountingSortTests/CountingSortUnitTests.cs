using CountingSort;

namespace CountingSortTests;

[TestClass]
public class CountingSortUnitTests
{
    private record Reading(string City, int Temperature);

    [TestMethod]
    public void GivenUnsortedArray_WhenArrayIsNotEmpty_ThenReturnSortedArray()
    {
        var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
        var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };
        var sortFunction = new CountingSortMethods();

        var sortedArray = sortFunction.CountingSort(array);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenArticleExample_WhenSorted_ThenReturnSortedArray()
    {
        var array = new int[] { 7, 1, 2, 8, 9, 9, 4, 1, 5, 5 };
        var expected = new int[] { 1, 1, 2, 4, 5, 5, 7, 8, 9, 9 };

        var sortedArray = new CountingSortMethods().CountingSort(array);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenRandomArray_WhenSorted_ThenMatchesArraySort()
    {
        var array = CountingSortMethods.CreateRandomArray(5_000, 0, 1_000);
        var expected = (int[])array.Clone();
        Array.Sort(expected);

        var sortedArray = new CountingSortMethods().CountingSort(array);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenSortedArray_WhenSorted_ThenArrayIsUnchanged()
    {
        var array = new int[] { 1, 2, 2, 3, 10 };
        var expected = new int[] { 1, 2, 2, 3, 10 };

        var sortedArray = new CountingSortMethods().CountingSort(array);

        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenArray_WhenArrayHasSingleElement_ThenReturnSortedArray()
    {
        var array = new int[] { 73 };
        var expected = new int[] { 73 };
        var sortFunction = new CountingSortMethods();

        var sortedArray = sortFunction.CountingSort(array);

        Assert.IsNotNull(sortedArray);
        CollectionAssert.AreEqual(expected, sortedArray);
    }

    [TestMethod]
    public void GivenEmptyArray_WhenSorted_ThenReturnEmptyArray()
    {
        var sortedArray = new CountingSortMethods().CountingSort([]);

        Assert.IsEmpty(sortedArray);
    }

    [TestMethod]
    public void GivenNegativeNumber_WhenSortedWithSimpleVersion_ThenThrows()
    {
        var array = new int[] { 3, -1, 2 };

        Assert.ThrowsExactly<IndexOutOfRangeException>(
            () => new CountingSortMethods().CountingSort(array));
    }

    [TestMethod]
    public void GivenReadingsWithEqualKeys_WhenStableSorted_ThenEqualKeysKeepTheirOrder()
    {
        Reading[] readings =
        [
            new("Oslo", -3), new("Cairo", 24), new("Lima", 18),
            new("Tromso", -3), new("Accra", 24), new("Quito", 18)
        ];

        var sorted = CountingSortMethods.StableCountingSort(readings, r => r.Temperature);

        CollectionAssert.AreEqual(
            new[] { "Oslo", "Tromso", "Lima", "Quito", "Cairo", "Accra" },
            sorted.Select(r => r.City).ToArray());
    }

    [TestMethod]
    public void GivenRandomKeysWithNegatives_WhenStableSorted_ThenMatchesOrderBy()
    {
        var random = new Random(42);
        var items = Enumerable.Range(0, 2_000)
            .Select(i => (Key: random.Next(-500, 500), Position: i))
            .ToArray();
        var expected = items.OrderBy(x => x.Key).ToArray();

        var sorted = CountingSortMethods.StableCountingSort(items, x => x.Key);

        CollectionAssert.AreEqual(expected, sorted);
    }

    [TestMethod]
    public void GivenEmptyArray_WhenStableSorted_ThenReturnEmptyArray()
    {
        var sorted = CountingSortMethods.StableCountingSort(Array.Empty<int>(), x => x);

        Assert.IsEmpty(sorted);
    }

    [TestMethod]
    public void GivenFullIntRange_WhenStableSorted_ThenThrowsBeforeAllocating()
    {
        int[] keys = [int.MinValue, int.MaxValue];

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => CountingSortMethods.StableCountingSort(keys, x => x));
    }

    [TestMethod]
    public void GivenIntMaxValue_WhenSortedWithSimpleVersion_ThenThrowsOverflow()
    {
        int[] array = [1, int.MaxValue];

        Assert.ThrowsExactly<OverflowException>(
            () => new CountingSortMethods().CountingSort(array));
    }
}
