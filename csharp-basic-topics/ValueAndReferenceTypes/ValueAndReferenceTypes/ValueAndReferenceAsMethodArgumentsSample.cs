namespace ValueAndReferenceTypes
{
    public class ValueAndReferenceAsMethodArgumentsSample
    {
        public void ValueTypeArguments(ValueTypeRectangle rect)
        {
            rect.Length = rect.Length + 1;
            Console.WriteLine($"Length inside function = {rect.Length}");
        }

        public void ReferenceTypeArguments(ReferenceTypeRectangle rect)
        {
            rect.Length = rect.Length + 1;
            Console.WriteLine($"Length inside function = {rect.Length}");
        }

    }
}
