namespace SmartEnum
{
    public class Developer
    {
        public Developer(string name, DeveloperLevel level)
        {
            Name = name;
            Level = level;
            Productivity = CalculateProductivity(Level);
        }

        public string Name { get; }
        public DeveloperLevel Level { get; }
        public double Productivity { get; }

        public double WriteCode(int linesOfCode)
        {
            return linesOfCode / Productivity;
        }

        private static double CalculateProductivity(DeveloperLevel level)
        {
            switch (level)
            {
                case DeveloperLevel.Junior:
                    return 75;
                case DeveloperLevel.Regular:
                    return 25;
                case DeveloperLevel.Senior:
                    return 75;
                default:
                    return 0;
            }
        }
    }
}
