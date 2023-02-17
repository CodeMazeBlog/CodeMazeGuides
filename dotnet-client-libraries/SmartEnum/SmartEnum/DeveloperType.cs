using Ardalis.SmartEnum;

namespace SmartEnum
{
    public sealed class DeveloperType : SmartEnum<DeveloperType>
    {
        private static readonly DeveloperType Junior = new DeveloperType(nameof(Junior), 1, 0.75);
        private static readonly DeveloperType Regular = new DeveloperType(nameof(Regular), 2, 1.25);
        private static readonly DeveloperType Senior = new DeveloperType(nameof(Senior), 3, 1.75);

        public DeveloperType(string name, int value, double productivity)
            : base(name, value)
        {
            Productivity = productivity;
        }

        public double Productivity { get; }
    }
}
