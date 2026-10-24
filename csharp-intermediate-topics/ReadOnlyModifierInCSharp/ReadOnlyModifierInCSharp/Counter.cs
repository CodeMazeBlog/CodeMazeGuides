namespace ReadOnlyModifierInCSharp
{
    public struct Counter
    {
        public int Value { get; private set; }

        public void Increment()
        {
            Value++;
        }

        public readonly string Describe()
        {
            return $"Counted {Value} times";
        }
    }
}
