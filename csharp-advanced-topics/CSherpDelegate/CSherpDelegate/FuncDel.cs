using System;
namespace CodeMaze {
    class FuncDel {
    public static int DoSum(int x, int y, int z)
    {
        return x + y + z;
    }

    static void Main(string[] args)
    {
        Func<int, int, int, int> SumObj = DoSum;
        Console.WriteLine("Total: "+SumObj(10, 20, 40));
    }
}
}
