namespace StaticVsNonstaticMethods
{
    public class Square : TwoDimensionalObject
    {
        public double SideLength { get; set; }

        public static Square Create(double sideLength)
        {
            return new Square() { SideLength = sideLength };
        }

        public override string Surface()
        {
            var line1 = $"Base object's surface: {base.Surface()}";
            var line2 = $"Square object's surface: {SideLength * SideLength}";

            return $"{line1}{Environment.NewLine}{line2}";
        }

        public new static string Description()
        {
            var line1 = $"Base object's description: {TwoDimensionalObject.Description()}";
            var line2 = $"Square object's description: This is a square";

            return $"{line1}{Environment.NewLine}{line2}";
        }
    }
}
