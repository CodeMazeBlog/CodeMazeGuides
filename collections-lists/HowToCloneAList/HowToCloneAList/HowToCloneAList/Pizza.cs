namespace HowToCloneAList
{
    public class Pizza : ICloneable
    {
        public string Name { get; set; }
        public List<string> Toppings { get; set; }

        public object Clone()
        {
            return new Pizza
            {
                Name = Name,
                Toppings = Toppings.ToList(),
            };
        }

        public override string ToString()
        {
            return $"Pizza name: {Name}; Toppings: {string.Join(", ", Toppings)}";
        }
    }
}
