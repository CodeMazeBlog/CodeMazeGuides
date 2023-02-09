namespace Guard_Clauses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine(150, 4, "Inline", 250, FuelType.Diesel);
            var car = new Car(engine);
        }
    }
}