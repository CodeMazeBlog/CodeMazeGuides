namespace GenerateChessBoard;

public static class Print2DArrayChessBoard
{
    private static readonly string[,] board = new string[8, 8]
    {
        { "R", "N", "B", "Q", "K", "B", "N", "R" },
        { "P", "P", "P", "P", "P", "P", "P", "P" },
        { "-", "-", "-", "-", "-", "-", "-", "-" },
        { "-", "-", "-", "-", "-", "-", "-", "-" },
        { "-", "-", "-", "-", "-", "-", "-", "-" },
        { "-", "-", "-", "-", "-", "-", "-", "-" },
        { "P", "P", "P", "P", "P", "P", "P", "P" },
        { "R", "N", "B", "Q", "K", "B", "N", "R" }
    };

    public static ConsoleColor GetBackgroundColorOfSquare(int row, int col)
    {
        return (row + col) % 2 == 0 ? ConsoleColor.White : ConsoleColor.Black;
    }

    public static void Display()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.BackgroundColor = GetBackgroundColorOfSquare(i, j);
                Console.ForegroundColor = Console.BackgroundColor == ConsoleColor.White ? ConsoleColor.Black : ConsoleColor.White;
                Console.Write(" " + board[i, j] + " ");
                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}