namespace HowToCloneAList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var toppings = new List<string>
            {
                "Mozzarella",
                "Olive oil",
                "Basil"
            };

            var toppingsClonedWithConstructor = new List<string>(toppings);

            var toppingsClonedWithCopyTo = new string[toppings.Count];
            toppings.CopyTo(toppingsClonedWithCopyTo);

            var toppingsClonedWithAddRange = new List<string>();
            toppingsClonedWithAddRange.AddRange(toppings);

            var toppingsClonedWithToList = toppings.ToList();

            var toppingsClonedWithConvertAll = toppings
                .ConvertAll(new Converter<string, string>(x => x));

            var customToppingsList = new ToppingsList<string>
            {
                "Mozzarella",
                "Olive oil",
                "Basil"
            };

            var toppingsClonedWithICloneable = (ToppingsList<string>)customToppingsList.Clone();

            Console.WriteLine("Original list: " + string.Join(", ", toppings));
            Console.WriteLine("Cloned with Constructor: " + string.Join(", ", toppingsClonedWithConstructor));
            Console.WriteLine("Cloned with CopyTo: " + string.Join(", ", toppingsClonedWithCopyTo));
            Console.WriteLine("Cloned with AddRange: " + string.Join(", ", toppingsClonedWithAddRange));
            Console.WriteLine("Cloned with ToList: " + string.Join(", ", toppingsClonedWithToList));
            Console.WriteLine("Cloned with ConverAll: " + string.Join(", ", toppingsClonedWithConvertAll));
            Console.WriteLine("Cloned with ICloneable: " + string.Join(", ", toppingsClonedWithICloneable));

            var pizzas = new List<Pizza>
            {
                new Pizza
                {
                    Name= "Margherita",
                    Toppings = new List<string>
                    {
                        "Mozzarella",
                        "Olive oil",
                        "Basil"
                    }
                },
                new Pizza
                {
                    Name= "Diavola",
                    Toppings = new List<string>
                    {
                        "Mozzarella",
                        "Ventricina",
                        "Chili peppers"
                    }
                }
            };

            var clonedPizzas = pizzas.ToList();

            var pizzasClonedWithICloneable = new List<Pizza>();

            foreach (var pizza in pizzas)
            {
                pizzasClonedWithICloneable.Add((Pizza)pizza.Clone());
            }

            var pizzasClonedWithCopyConstructor = new List<Pizza>();

            foreach (var pizza in pizzas)
            {
                pizzasClonedWithCopyConstructor.Add(new Pizza(pizza));
            }

            var margherita = pizzas
                .FirstOrDefault(x => x.Name == "Margherita");

            margherita.Toppings.Clear();

            Console.WriteLine($"Original Margherita: {pizzas.First()}");
            Console.WriteLine($"Cloned with ToList: {clonedPizzas.First()}");
            Console.WriteLine($"Cloned with ICloneable: {pizzasClonedWithICloneable.First()}");
            Console.WriteLine($"Cloned with Copy Constructor: {pizzasClonedWithCopyConstructor.First()}");
        }
    }
}