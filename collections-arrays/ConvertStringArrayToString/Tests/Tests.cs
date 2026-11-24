using StringArrayToString;

namespace Tests;

public class Tests
{
    private readonly string[] _array = ["Code", "Maze", "C#"];
    private readonly string _result = "CodeMazeC#";
    private readonly ArrayConverter _arrayConverter = new();

    [Fact]
    public void GivenAnArray_WhenUsingLoopStringAdditionAssignment_ThenConvertIntoString()
    {
        var result = _arrayConverter.UsingLoopStringAdditionAssignment(_array);

        Assert.Equal(_result, result);
    }

    [Fact]
    public void GivenAnArray_WhenUsingLoopStringBuilder_ThenConvertIntoString()
    {
        var result = _arrayConverter.UsingLoopStringBuilder(_array);

        Assert.Equal(_result, result);
    }

    [Fact]
    public void GivenAnArray_WhenUsingStringJoin_ThenConvertIntoString()
    {
        var result = _arrayConverter.UsingStringJoin(_array);

        Assert.Equal(_result, result);
    }

    [Fact]
    public void GivenAnArray_WhenUsingStringJoinWithSeparator_ThenSeparatorOnlyBetweenElements()
    {
        var result = _arrayConverter.UsingStringJoinWithSeparator(_array, " ");

        Assert.Equal("Code Maze C#", result);
    }

    [Fact]
    public void GivenAnArray_WhenUsingStringConcat_ThenConvertIntoString()
    {
        var result = _arrayConverter.UsingStringConcat(_array);

        Assert.Equal(_result, result);
    }

    [Fact]
    public void GivenAnArray_WhenUsingAggregation_ThenConvertIntoString()
    {
        var result = _arrayConverter.UsingAggregation(_array);

        Assert.Equal(_result, result);
    }

    [Fact]
    public void GivenAnArray_WhenUsingAggregationWithStringBuilder_ThenConvertIntoString()
    {
        var result = _arrayConverter.UsingAggregationWithStringBuilder(_array);

        Assert.Equal(_result, result);
    }

    [Fact]
    public void GivenAnEmptyArray_WhenUsingAggregation_ThenThrowInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => _arrayConverter.UsingAggregation([]));
    }

    [Fact]
    public void GivenAnEmptyArray_WhenUsingTheOtherMethods_ThenReturnEmptyString()
    {
        string[] empty = [];

        Assert.Equal(string.Empty, _arrayConverter.UsingLoopStringAdditionAssignment(empty));
        Assert.Equal(string.Empty, _arrayConverter.UsingLoopStringBuilder(empty));
        Assert.Equal(string.Empty, _arrayConverter.UsingStringJoin(empty));
        Assert.Equal(string.Empty, _arrayConverter.UsingStringConcat(empty));
        Assert.Equal(string.Empty, _arrayConverter.UsingAggregationWithStringBuilder(empty));
    }

    [Fact]
    public void GivenAnArray_WhenCallingToString_ThenReturnTypeName()
    {
        Assert.Equal("System.String[]", _array.ToString());
    }
}
