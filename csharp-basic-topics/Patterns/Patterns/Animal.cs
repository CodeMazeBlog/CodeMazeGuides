namespace Patterns
{
    public abstract class Animal
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Age { get; set; }
        public Animal? AnimalParent { get; set; }
        public Animal? AnimalChild { get; set; }
    }
}
