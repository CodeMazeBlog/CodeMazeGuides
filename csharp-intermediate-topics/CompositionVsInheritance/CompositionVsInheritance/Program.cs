namespace CompositionVsInheritance
{
    public class Program
    {
        static void Main(string[] args)
        {
            var house1 = new GlassHouse();
            house1.Color = "Transparent";
            house1.GetCeiling();
            house1.GetAddress();
            house1.WarningSign();

            var house2 = new BrickHouse();
            house2.Color = "Red";
            house2.GetFloor();
            house2.GetAddress();
        }
    }
}
