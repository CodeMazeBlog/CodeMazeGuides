namespace Delegates;

public sealed class Main
{
    private int Execute(AddDelegate addDelegate, int a, int b)
    {
        return addDelegate(a, b);
    }

    public void Run()
    {
        var result = Execute((a, b) => a + b, 1, 2);
    }
}