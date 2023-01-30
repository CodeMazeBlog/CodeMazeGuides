namespace MethodOverridingInCSharp
{
    public class Shape
    {
        public string Color { get; set; }

        public virtual string Draw()
        {
            return $"Drawing a {Color} colored shape";
        }
    }
}
