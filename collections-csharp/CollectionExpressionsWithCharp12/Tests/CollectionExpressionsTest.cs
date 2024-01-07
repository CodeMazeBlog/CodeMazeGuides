namespace Tests;

public class CollectionExpressionsTests
{
    [Fact]
    public void WhenAccessNames_ThenReturnExpectedNames()
    {
        string[] expected = ["John", "Paul", "George", "Ringo"];
        var result = CollectionExpressions.Names;

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GivenThreeArrays_WhenCreateNewArrayUsingSpreadOperator_ThenReturnCombinedArray()
    {
        int[] array1 = [1, 2, 3];
        int[] array2 = [4, 5, 6];
        int[] array3 = [7, 8, 9];
        int[] expected = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        var result = CollectionExpressions.CreateNewArrayUsingSpreadOperator(array1, array2, array3);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void
        GivenThreeArraysAndAdditionalItems_WhenCreateNewArrayUsingSpreadOperator_ThenReturnCombinedArrayWithAdditionalItems()
    {
        int[] array1 = [1, 2, 3];
        int[] array2 = [4, 5, 6];
        int[] array3 = [7, 8, 9];
        int[] expected = [1, 2, 3, 50, 4, 5, 6, 7, 8, 9];
        var result = CollectionExpressions.CreateNewArrayUsingSpreadOperatorWithAdditionalItems(array1, array2, array3);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void WhenCreateJaggedArray_ThenReturnExpectedJaggedArray()
    {
        var expected = new int[][]
        {
            [1, 2, 3],
            [4, 5, 6],
            [7, 8, 9]
        };
        var result = CollectionExpressions.CreateJaggedArray();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void WhenCreateListUsingNewExpressionSyntax_ThenReturnExpectedList()
    {
        List<string> expected = ["John", "Paul", "George", "Ringo"];
        var result = CollectionExpressions.CreateListUsingNewExpressionSyntax();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void WhenCreateSpanUsingNewExpressionSyntax_ThenReturnExpectedArray()
    {
        var expected = new Memory<int>([1, 2, 3, 4]);
        var result = CollectionExpressions.CreateSpanUsingNewExpressionSyntax();

        Assert.Equal(expected.ToArray(), result.ToArray());
    }
}