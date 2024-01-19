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
        var expected = array.Length;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenArray_WhenArraySegmentIsCreated_ThenArraySegmentContainsPortionOfArray()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5];
        var arraySegment = new ArraySegment<int>(array, 1, 2);

        //Assert
        var expected = 2;

        Assert.Equal(expected, output);
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
        var expected = 6;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenArraySegment_WhenArrayPropertyIsUsed_ThenOriginalArrayIsAccessed()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, 4, 3);

        // Act
        var output = Utilities.GetOriginalArray(segment)[0];

        //Assert
        var expected = 1;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenArraySegment_WhenCountPropertyIsUsed_ThenCorrectNumberOfElementsIsReturned()
    {
        // Arrange
        const int count = 3;
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var arraySegment = new ArraySegment<int>(array, 4, count);

        //Assert
        var expected = 3;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenArraySegment_WhenOffsetPropertyIsUsed_ThenCorrectOffsetIsReturned()
    {
        // Arrange
        const int offset = 4;
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, offset, 3);

        //Assert
        var expected = 4;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void WhenArraySegmentEmptyPropertyIsUsed_ThenEmptySegmentIsCreated()
    {
        // Act
        var emptySegment = ArraySegment<int>.Empty;

        //Assert
        var expected = 0;

        Assert.Equal(expected, output);
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
    public void GivenModifySegmentElementMethod_WhenIndexAndNewValueArePassed_ThenSegmentAndArrayAreModified()
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