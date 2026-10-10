using System.Runtime.InteropServices;

namespace UpdateDictionaryValue
{
    public class ToppingsDictionary
    {
        public Dictionary<string, int> Toppings { get; }

        public ToppingsDictionary()
        {
            Toppings = new Dictionary<string, int>()
            {
                { "pepperoni", 4 },
                { "meatball", 8 },
                { "olive", 0 }
            };
        }

        public void AddToppings(string toppingType, int amount)
        {
            if (Toppings.TryGetValue(toppingType, out int currentAmount))
            {
                Toppings[toppingType] = currentAmount + amount;
            }
            else
            {
                Toppings.Add(toppingType, amount);
            }
        }

        public void AddToppingIfMissing(string toppingType, int amount)
        {
            if (!Toppings.TryAdd(toppingType, amount))
            {
                Console.WriteLine($"{toppingType} is already on the pizza.");
            }
        }

        public void AddToppingsByRef(string toppingType, int amount)
        {
            ref var currentAmount = ref CollectionsMarshal
                .GetValueRefOrAddDefault(Toppings, toppingType, out _);

            currentAmount += amount;
        }
    }
}
