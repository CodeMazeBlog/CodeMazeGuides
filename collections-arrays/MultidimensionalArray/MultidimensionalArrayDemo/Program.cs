// int[,] matrix = new int[3, 4];
// int[][] jaggedArray = new int[3][];

int[,] matrix = new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
// int[][] jaggedArray = new int[3][] { new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 } };
int[][] jaggedArray = new int[3][] { new int[4], new int[3], new int[4] };

for (int row = 0; row < matrix.GetLength(0); row++)
{
    for (int column = 0; column < matrix.GetLength(1); column++)
    {
        Console.Write($"{matrix[row, column]} ");
    }
    Console.WriteLine();
}

for (int row = 0; row < jaggedArray.Length; row++)
{
    for (int column = 0; column < jaggedArray[row].Length; column++)
    {
        Console.Write($"{jaggedArray[row][column]} ");
    }
    Console.WriteLine();
}


