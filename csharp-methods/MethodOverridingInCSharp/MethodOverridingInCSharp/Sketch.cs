namespace MethodOverridingInCSharp
{
    public class Sketch : Shape
    {
        public new string Draw()
        {
            return $"Sketching a {Color} outline";
        }
    }
}
