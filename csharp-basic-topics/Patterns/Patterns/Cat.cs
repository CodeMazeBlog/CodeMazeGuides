namespace Patterns
{
    public class Cat : Animal
    {
        public Cat()
        {
            Name = "Cat";
            Description = "furry animal with long tail and claws";
            Age = new Random().Next(100);
        }
    }
}
