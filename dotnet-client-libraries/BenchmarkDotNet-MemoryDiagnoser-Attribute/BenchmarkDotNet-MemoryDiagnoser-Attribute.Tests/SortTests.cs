using FluentAssertions;

namespace BenchmarkDotNet_MemoryDiagnoser_Attribute.Tests
{
    public class SortTests
    {
        [Fact]
        public void WhenQuickSortIsInvoked_ThenArrayBeSortedInAscendingOrder()
        {
            // Arrange
            int[] arr = { 5, 3, 1, 4, 2 };
            int[] expected = { 1, 2, 3, 4, 5 };

            // Act
            Sort.QuickSort(arr, 0, arr.Length - 1);

            // Assert
            arr.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void WhenMergeSortIsInvoked_ThenArrayBeSortedInAscendingOrder()
        {
            // Arrange
            int[] arr = { 5, 3, 1, 4, 2 };
            int[] expected = { 1, 2, 3, 4, 5 };

            // Act
            Sort.MergeSort(arr, 0, arr.Length - 1);

            // Assert
            arr.Should().BeEquivalentTo(expected);
        }
    }
}