namespace MethodOverridingInCSharp
{
    public class Shape
    {
        public string Color { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine($"Drawing a {Color} colored shape");
        }
    }
}
