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

    public class Cat : Animal
    {
        public Cat()
        {
            Name = "Cat";
            Description = "furry animal with long tail and claws";
            Age = new Random().Next(100);
        }
    }

    public class Dog : Animal
    {
        public Dog()
        {
            Name = "Dog";
            Description = "furry animal with tail and paws";
            Age = new Random().Next(100);
        }
    }
}
