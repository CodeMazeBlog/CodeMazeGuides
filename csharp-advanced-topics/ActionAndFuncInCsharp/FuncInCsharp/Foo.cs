namespace FuncInCsharp;

public class Foo
{
    public Foo(params int[] values)
    {
        this.values = values;
    }

    private readonly int[] values;

    public IReadOnlyCollection<int> Values => this.values;

    public void Recalculate(Func<int, int> operation)
    {
        for (var i = 0; i < this.values.Length; i++)
        {
            this.values[i] = operation(this.values[i]);
        }
    }
}
