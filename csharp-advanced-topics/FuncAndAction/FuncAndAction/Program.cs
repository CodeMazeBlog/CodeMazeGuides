using FuncAndAction;

internal class Program
{
    private static void Main(string[] args)
    {
        var sut = new FuncAndActionDelegates();
        var resultFromFunc = sut.FromFunc(12);
        sut.FromAction("Welcome To CodeMaze From The Action Delegate");
        Console.WriteLine($"This result is coming from a Func delegate {resultFromFunc}");
    }
}