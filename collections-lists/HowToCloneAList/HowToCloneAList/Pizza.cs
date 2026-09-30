using System.Diagnostics.CodeAnalysis;

namespace HowToCloneAList
{
    public class Pizza : ICloneable
    {
        public Pizza()
        {
        }

        [SetsRequiredMembers]
        public Pizza(Pizza pizza)
        {
            Name = pizza.Name;
            Toppings = pizza.Toppings.ToList();
        }

        public required string Name { get; set; }
        public required List<string> Toppings { get; set; }

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
