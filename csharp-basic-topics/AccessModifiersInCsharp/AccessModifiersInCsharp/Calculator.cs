namespace AccessModifiersInCsharp
{
    public class Calculator
    {
        public int Value { get; set; }

        public int IncrementValue(int value)
        {
            return value + 1;
        }
    }
}
