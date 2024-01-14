using HowToUseTheArraySegmentStructInCSharp;

namespace Tests;

public class HowToUseTheArraySegmentStructInCSharpTest
{   
    [Fact]
    public void GivenGetArraySegmentLengthMethod_WhenEnireArrayIsDelimited_ThenSegmentAndArrayAreOfEqualLength()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5];

        // Act
        var output = Utilities.GetArraySegmentLength(array);

        //Assert
        var expected = array.Length;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenGetArraySegmentLengthMethod_WhenArraySegmentIsCreated_ThenArraySegmentContainsPortionOfArray()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5];

        // Act
        var output = Utilities.GetArraySegmentLength(array, 1, 2);

        //Assert
        var expected = 2;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenRetrieveElementMethod_WhenIndexIsSpecified_ThenCorrectElementIsRetrieved()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, 4, 3); // [5, 6, 7]

        // Act
        var output = Utilities.RetrieveElement(segment, 1); // 6

        //Assert
        var expected = 6;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenGetOriginalArrayMethod_WhenArrayPropertyIsUsed_ThenOriginalArrayIsAccessed()
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
    public void GivenCountElementsInSegmentMethod_WhenCountPropertyIsUsed_ThenCorrectNumberOfElementsIsReturned()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, 4, 3);

        // Act
        var output = Utilities.CountElementsInSegment(segment);

        //Assert
        var expected = 3;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenGetOffsetMethod_WhenOffsetPropertyIsUsed_ThenCorrectOffsetIsReturned()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, 4, 3);

        // Act
        var output = Utilities.GetOffset(segment);

        //Assert
        var expected = 4;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenCreateEmptySegmentMethod_WhenEmptyPropertyIsUsed_ThenEmptySegmentIsCreated()
    {
        // Act
        var output = Utilities.CreateEmptySegment<int>().Count;

        //Assert
        var expected = 0;

        Assert.Equal(expected, output);
    }

    [Fact]
    public void GivenCompareArraySegmentsMethod_WhenEqualSegmentsAreCompared_ThenTrueIsReturned()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment1 = new ArraySegment<int>(array, 4, 3);
        var segment2 = new ArraySegment<int>(array, 4, 3);

        // Act
        var output = Utilities.CompareArraySegments(segment1, segment2);

        //Assert
        Assert.True(output);
    }

    [Fact]
    public void GivenCompareArraySegmentsMethod_WhenDifferentSegmentsAreCompared_ThenFalseIsReturned()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment1 = new ArraySegment<int>(array, 3, 4);
        var segment2 = new ArraySegment<int>(array, 4, 3);

        // Act
        var output = Utilities.CompareArraySegments(segment1, segment2);

        //Assert
        Assert.False(output);
    }

    [Fact]
    public void GivenGetSegmentSliceMethod_WhenStartIndexAndLengthArePassed_ThenCorrectSliceIsReturned()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, 3, 4); // [4, 5, 6, 7]

        // Act
        var output = Utilities.GetSegmentSlice(segment, 2, 2); // [6, 7]

        //Assert
        Assert.Contains(6, output);
        Assert.Contains(7, output);
        Assert.DoesNotContain(4, output);
        Assert.DoesNotContain(5, output);
    }

    [Fact]
    public void GivenModifySegmentElementMethod_WhenIndexAndNewValueArePassed_ThenSegmentAndArrayAreModified()
    {
        // Arrange
        int[] array = [1, 2, 3, 4, 5, 6, 7, 8];
        var segment = new ArraySegment<int>(array, 3, 4); // [4, 5, 6, 7]

        // Act
        Utilities.ModifySegmentElement(segment, 2, 600);

        //Assert
        var expected = 600;
        Assert.Equal(segment[2], expected);
        Assert.Equal(array[5], expected);
    }
}