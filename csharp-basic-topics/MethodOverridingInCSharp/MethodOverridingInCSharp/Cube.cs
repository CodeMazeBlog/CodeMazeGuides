namespace MethodOverridingInCSharp
{
    public class Cube : Shape
    {
        public int Edge { get; set; }

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"Drawing a cube with edges of length, width, and height of {Edge} units");
        }
    }
}
