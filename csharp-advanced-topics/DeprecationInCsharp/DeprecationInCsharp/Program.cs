namespace Deprecation
{
    public class Program
    {
        public static void Main()
        {
            var originalString = StringUtils.input;
            var reversed = StringUtils.ReverseString(originalString); // Deprecated method
            var reversedV2 = StringUtils.ReverseStringV2(originalString); // Recommended method

            Console.WriteLine("Reversed (Deprecated Method): " + reversed);
            Console.WriteLine("Reversed V2 (Recommended Method): " + reversedV2);
        }
    }
}