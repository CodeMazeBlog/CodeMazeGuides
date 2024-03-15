using Ardalis.SmartEnum;

namespace SmartEnum
{
    public sealed class DeveloperLevel : SmartEnum<DeveloperLevel>
    {
        public static readonly DeveloperLevel Junior = new DeveloperLevel(nameof(Junior), 1, 75);
        public static readonly DeveloperLevel Regular = new DeveloperLevel(nameof(Regular), 2, 125);
        public static readonly DeveloperLevel Senior = new DeveloperLevel(nameof(Senior), 3, 175);

        public double Productivity { get; }

        public DeveloperLevel(string name, int value, double productivity)
            : base(name, value)
        {
            Productivity = productivity;
        }
    }
}
