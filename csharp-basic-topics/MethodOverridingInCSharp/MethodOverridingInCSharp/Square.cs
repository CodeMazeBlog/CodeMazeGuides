namespace MethodOverridingInCSharp
{
    public class Square : Shape
    {
        public int Side { get; set; }

        public override void Draw()
        {
            Console.WriteLine($"Drawing a square of color {Color} with its sides having length and width of {Side} units");
        }
    }
}
