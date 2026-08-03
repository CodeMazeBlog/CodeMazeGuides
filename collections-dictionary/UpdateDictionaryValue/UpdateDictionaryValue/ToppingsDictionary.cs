namespace UpdateDictionaryValue
{
    public class ToppingsDictionary
    {
        public Dictionary<string, int> Toppings { get; private set; }

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
    }
}
