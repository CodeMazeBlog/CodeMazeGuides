namespace ReadOnlyModifierInCSharp
{
    public class Tally
    {
        private readonly Counter _counter;

        public int Total => _counter.Value;

        public void Count()
        {
            _counter.Increment();
        }
    }
}
