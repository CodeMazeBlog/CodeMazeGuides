namespace CommonMistakesInACsharpProgram
{
    public class Wine
    {
        public string Color { get; set; }

        public string Taste { get; set; }

        public void Evaporate()
        {
            Console.WriteLine("Eveporating into thin air");
        }
    }
}
