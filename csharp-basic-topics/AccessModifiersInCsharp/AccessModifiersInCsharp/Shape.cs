namespace AccessModifiersInCsharp
{
    public class Shape
    {
        protected int Width { get; set; }
        protected int Height { get; set; }

        public virtual int GetArea()
        {
            return Width * Height;
        }
    }
}
