namespace Tests;
using GenerateChessBoard;
using Xunit;

public class ChessBoardTests
{
    [Fact]
    public void GetBackgroundColorForCell_WhenRowColSumIsEven_ReturnsWhite()
    {
        int row = 0;
        int col = 0;

        var color = Print2DArrayChessBoard.GetBackgroundColorOfSqaure(row, col);

        Assert.Equal(ConsoleColor.White, color);
    }

    [Fact]
    public void GetBackgroundColorForCell_WhenRowColSumIsOdd_ReturnsBlack()
    {
        int row = 0;
        int col = 1;

        var color = Print2DArrayChessBoard.GetBackgroundColorOfSqaure(row, col);

        Assert.Equal(ConsoleColor.Black, color);
    }
}