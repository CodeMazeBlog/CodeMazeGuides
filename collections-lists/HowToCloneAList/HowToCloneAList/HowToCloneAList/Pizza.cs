namespace HowToCloneAList
{
    public class Pizza
    {
        public string Name { get; set; }
        public List<string> Toppings { get; set; }

        public override string ToString()
        {
            return $"Pizza name: {Name}; Toppings: {string.Join(", ", Toppings)}";
        }
    }
}
