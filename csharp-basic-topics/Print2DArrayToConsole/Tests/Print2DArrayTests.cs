namespace Tests;
using GenerateChessBoard;
using Xunit;

public class ChessBoardTests
{
    [Fact]
    public void GivenRowColSumIsEven_WhenGettingBackgroundColor_ThenReturnsWhite()
    {
        const int row = 0;
        const int col = 0;

        var color = Print2DArrayChessBoard.GetBackgroundColorOfSquare(row, col);

        Assert.Equal(ConsoleColor.White, color);
    }

    [Fact]
    public void GivenRowColSumIsOdd_WhenGettingBackgroundColor_ThenReturnsBlack()
    {
        const int row = 0;
        const int col = 1;

        var color = Print2DArrayChessBoard.GetBackgroundColorOfSquare(row, col);

        Assert.Equal(ConsoleColor.Black, color);
    }
}