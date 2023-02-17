namespace SmartEnum
{
    public class Developer
    {
        public Developer(string name, DeveloperEnum developerType)
        {
            Name = name;
            DeveloperType = developerType;
            Productivity = SetProductivity(DeveloperType);
        }

        public string Name { get; }
        public DeveloperEnum DeveloperType { get; }
        public double Productivity { get; }

        private static double SetProductivity(DeveloperEnum developerType)
        {
            switch (developerType)
            {
                case DeveloperEnum.Junior:
                    return 0.75;
                case DeveloperEnum.Regular:
                    return 1.25;
                case DeveloperEnum.Senior:
                    return 1.75;
                default:
                    return 0;
            }
        }
    }
}
