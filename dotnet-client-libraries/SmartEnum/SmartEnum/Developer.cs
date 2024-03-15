namespace SmartEnum
{
    public class Developer
    {
        public string Name { get; }
        public DeveloperLevel Level { get; }

        public Developer(string name, DeveloperLevel level)
        {
            Name = name;
            Level = level;
        }

        public double WriteCode(int linesOfCode)
        {
            return linesOfCode / Level.Productivity;
        }
    }
}
