using System.Text;

namespace ManagedVsUnmanagedCodeInCSharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Showcasing Best Practices

            // Bad practice: creating unnecessary objects
            var str = string.Empty;
            for (var i = 0; i < 10; i++)
            {
                str += i.ToString();
            }

            // Good practice: avoiding unnecessary objects
            var sb = new StringBuilder();
            for (var i = 0; i < 10; i++)
            {
                sb.Append(i);
            }
            var result = sb.ToString();

            Console.WriteLine(result);
        }
    }
}