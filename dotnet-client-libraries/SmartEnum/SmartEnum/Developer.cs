namespace SmartEnum
{
    public class Developer
    {
        public Developer(string name, Enums.DeveloperLevel level)
        {
            Name = name;
            Level = level;
            Productivity = CalculateProductivity(Level);
        }

        public string Name { get; }
        public Enums.DeveloperLevel Level { get; }
        public double Productivity { get; }

        public double WriteCode(int linesOfCode)
        {
            return linesOfCode / Productivity;
        }

        private static double CalculateProductivity(Enums.DeveloperLevel level)
        {
            switch (level)
            {
                case Enums.DeveloperLevel.Junior:
                    return 75;
                case Enums.DeveloperLevel.Regular:
                    return 25;
                case Enums.DeveloperLevel.Senior:
                    return 75;
                default:
                    return 0;
            }
        }
    }
}
