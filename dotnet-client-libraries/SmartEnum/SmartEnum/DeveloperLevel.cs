using Ardalis.SmartEnum;

namespace SmartEnum
{
    public sealed class DeveloperLevel : SmartEnum<DeveloperLevel>
    {
        private static readonly DeveloperLevel Junior = new DeveloperLevel(nameof(Junior), 1, 75);
        private static readonly DeveloperLevel Regular = new DeveloperLevel(nameof(Regular), 2, 125);
        private static readonly DeveloperLevel Senior = new DeveloperLevel(nameof(Senior), 3, 175);

        public DeveloperLevel(string name, int value, double productivity)
            : base(name, value)
        {
            Productivity = productivity;
        }

        public double Productivity { get; }
    }
}
