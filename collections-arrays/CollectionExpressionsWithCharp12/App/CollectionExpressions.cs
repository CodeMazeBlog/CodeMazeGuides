namespace App;

public static class CollectionExpressions
{
    public static string[] Names => ["John", "Paul", "George", "Ringo"];

    public static int[] CreateNewArrayUsingSpreadOperator(int[] array1, int[] array2, int[] array3)
    {
        int[] largeArray = [.. array1, .. array2, .. array3];

        return largeArray;
    }

    public static int[] CreateNewArrayUsingSpreadOperatorWithAdditionalItems(int[] array1, int[] array2, int[] array3)
    {
        int[] largeArray = [.. array1, 50, .. array2, .. array3];

        return largeArray;
    }

    public static int[][] CreateJaggedArray()
    {
        int[] row0 = [1, 2, 3];
        int[] row1 = [4, 5, 6];
        int[] row2 = [7, 8, 9];
        int[][] vector = [row0, row1, row2];

        return vector;
    }

    // Using C#12 Array Expression Syntax on Lists
    public static List<string> CreateListUsingNewExpressionSyntax()
    {
        List<string> myList = ["John", "Paul", "George", "Ringo"];

        return myList;
    }

    // Using new syntax with Span<T> and ReadOnlySpan<T>

    public static Span<int> CreateSpanUsingNewExpressionSyntax()
    {
        Span<int> span1 = [1, 2, 3, 4];

        return span1.ToArray();
    }
}