namespace Tests;

public class HowToUseTheArraySegmentStructInCSharpTest
{
    [Fact]
    public void GivenArray_WhenEntireArrayIsDelimitedAsSegment_ThenSegmentAndArrayAreOfEqualLength()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5];
        var arraySegment = new ArraySegment<int>(array);

        //Assert
        Assert.Equal(array.Length, arraySegment.Count);
    }

    [Fact]
    public void GivenArray_WhenArraySegmentIsCreated_ThenArraySegmentContainsPortionOfArray()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5];
        var arraySegment = new ArraySegment<int>(array, 1, 2);

        //Assert
        Assert.Equal(2, arraySegment.Count);
    }

    [Fact]
    public void GivenArraySegment_WhenIndexIsSpecified_ThenCorrectElementIsRetrieved()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var arraySegment = new ArraySegment<int>(array, 4, 3); // [5, 6, 7]

        // Act
        var output = arraySegment[1]; // 6

        //Assert
        Assert.Equal(6, output);
    }

    [Fact]
    public void GivenArraySegment_WhenArrayPropertyIsUsed_ThenOriginalArrayIsAccessed()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, 4, 3);

        // Act
        var segmentArray = segment.Array;

        //Assert
        Assert.Equal(array, segmentArray);
    }

    [Fact]
    public void GivenArraySegment_WhenCountPropertyIsUsed_ThenCorrectNumberOfElementsIsReturned()
    {
        // Arrange
        const int count = 3;
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var arraySegment = new ArraySegment<int>(array, 4, count);

        //Assert
        Assert.Equal(count, arraySegment.Count);
    }

    [Fact]
    public void GivenArraySegment_WhenOffsetPropertyIsUsed_ThenCorrectOffsetIsReturned()
    {
        // Arrange
        const int offset = 4;
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, offset, 3);

        //Assert
        Assert.Equal(offset, segment.Offset);
    }

    [Fact]
    public void WhenArraySegmentEmptyPropertyIsUsed_ThenEmptySegmentIsCreated()
    {
        // Act
        var emptySegment = ArraySegment<int>.Empty;

        //Assert
        Assert.Empty(emptySegment);
    }

    [Fact]
    public void GivenEqualArraySegments_WhenCompared_ThenAreEqual()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment1 = new ArraySegment<int>(array, 4, 3);
        var segment2 = new ArraySegment<int>(array, 4, 3);

        //Assert
        Assert.Equal(segment1, segment2);
        Assert.StrictEqual(segment1, segment2);
        Assert.True(segment1 == segment2);
    }

    [Fact]
    public void GivenUnequalSegments_WhenCompared_ThenAreNotEqual()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment1 = new ArraySegment<int>(array, 3, 4);
        var segment2 = new ArraySegment<int>(array, 4, 3);

        //Assert
        Assert.NotEqual(segment1, segment2);
        Assert.NotStrictEqual(segment1, segment2);
        Assert.False(segment1 == segment2);
    }

    [Fact]
    public void GivenArraySegment_WhenStartIndexAndLengthArePassed_ThenCorrectSliceIsReturned()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, 3, 4); // [4, 5, 6, 7]

        // Act
        var slice = segment.Slice(2, 2); // [6, 7]

        //Assert
        Assert.Contains(6, slice);
        Assert.Contains(7, slice);
        Assert.DoesNotContain(4, slice);
        Assert.DoesNotContain(5, slice);
    }

    [Fact]
    public void GivenArraySegment_WhenSettingViaIndexer_ThenSegmentAndArrayAreModified()
    {
        // Arrange
        const int expectedValue = 600;
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, 3, 4); // [4, 5, 6, 7]

        // Act
        segment[2] = expectedValue;

        //Assert
        Assert.Equal(expectedValue, segment[2]);
        Assert.Equal(expectedValue, array[5]);
    }
}