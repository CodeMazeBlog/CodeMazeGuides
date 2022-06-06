namespace Patterns
{
    public abstract class Animal
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Age { get; set; }
        public bool Cloned { get; set; } = false;
        public bool Clone { get; set; } = false;
        public abstract Animal CreateClone();
    }
}
