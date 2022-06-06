namespace Patterns
{
    public class Dog : Animal
    {
        public Dog()
        {
            InitializeDog();
        }

        private void InitializeDog()
        {
            Name = "Dog";
            Description = "furry animal with tail and paws";
            Age = new Random().Next(100);
        }

        public Dog(bool clone)
        {
            Clone = clone;
            InitializeDog();
        }

        public override Animal CreateClone()
        {
            Cloned = true;
            return new Dog(true);
        }
    }
}
