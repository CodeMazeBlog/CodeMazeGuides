namespace MethodOverridingInCSharp
{
    public class Shape
    {
        public required string Color { get; set; }

        public virtual string Draw()
        {
            return $"Drawing a {Color} colored shape";
        }
    }
}
