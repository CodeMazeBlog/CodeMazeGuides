namespace ActionAndFuncDelegatesInCSharp;

public class FuncDemonstrationFormatting
{
    public class ObjectPrinter<T>
    {
        public T Object { get; set; }

        public Func<T, string> Formatter { get; set; }

        public override string ToString() => Formatter?.Invoke(Object);

        public void Print() => Console.Write(ToString());
    }

    public class EnumerablePrinter<T>
    {
        public IEnumerable<T> Objects { get; set; }

        public Func<T, string> Formatter { get; set; }

        public override string ToString() => string.Join(", ", Objects.Select(Formatter));

        public void Print() => Console.Write(ToString());
    }
}
