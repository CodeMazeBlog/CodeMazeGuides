namespace MethodOverridingInCSharp.Abstract
{
    public abstract class Shape
    {
        public required string Color { get; set; }
        public abstract string Draw();
    }
}
