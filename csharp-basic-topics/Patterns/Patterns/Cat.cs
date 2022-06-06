namespace Patterns
{
    public class Cat : Animal
    {
        public Cat()
        {
            InitializeCat();
        }

        private void InitializeCat()
        {
            Name = "Cat";
            Description = "furry animal with long tail and claws";
            Age = new Random().Next(100);
        }

        public Cat(bool clone)
        {
            Clone = clone;
            InitializeCat();
        }

        public override Animal CreateClone()
        {
            Cloned = true;
            return new Cat(true);
        }
    }
}
