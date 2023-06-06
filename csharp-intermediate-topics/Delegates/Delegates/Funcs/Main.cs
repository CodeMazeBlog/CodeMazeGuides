namespace Delegates.Funcs;

public sealed class Main
{
    private int Execute(Func<int, int, int> addFunc, int a, int b)
    {
        return addFunc(a, b);
    }

    public void Run()
    {
        var result = Execute((a, b) => a + b, 1, 2);
    }
}