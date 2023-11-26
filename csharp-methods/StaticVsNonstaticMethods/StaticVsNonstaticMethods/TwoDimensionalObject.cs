namespace StaticVsNonstaticMethods
{
    public class TwoDimensionalObject
    {
        public virtual string Surface()
        {
            return "This object does not have a surface.";
        }

        public static string Description() 
        {
            return "This is a basic 2D object";
        }
    }
}
