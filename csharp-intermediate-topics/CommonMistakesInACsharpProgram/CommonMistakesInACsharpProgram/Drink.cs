namespace CommonMistakesInACsharpProgram
{
    public class Drink
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public string Color { get; set; }

        public string Taste { get; set; }

        public void Break()
        {
            Console.WriteLine("Broken into pieces");
        }

        public void Evaporate()
        {
            Console.WriteLine("Eveporating into thin air");
        }
    }
}
