namespace InitSetters
{
    public class Airport(string code, string name)
    {
        public string Code { get; init; } = code;
        public string Name { get; init; } = name;
    }
}
