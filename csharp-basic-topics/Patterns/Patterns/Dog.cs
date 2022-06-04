namespace Patterns
{
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
