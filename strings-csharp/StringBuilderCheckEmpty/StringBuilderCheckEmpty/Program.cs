
using System.Text;

namespace StringBuilderCheckEmpty 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var filledStringBuilder = new StringBuilder("example string value");
            if(filledStringBuilder.Length == 0)
            {
                Console.WriteLine("StringBuilder is empty!");
            }
            else
            {
                Console.WriteLine($"StringBuilder is not empty and length is {filledStringBuilder.Length} character ");
            }

            var emptyStringBuilder = new StringBuilder();

            var converted2String = emptyStringBuilder.ToString();

            if (string.IsNullOrEmpty(converted2String))
            {
                Console.WriteLine("emptyStringBuilder is empty!");
            }


            if (emptyStringBuilder.ToString() == "")
            {
                Console.WriteLine("emptyStringBuilder is empty!");
            }


            if (emptyStringBuilder.ToString() == string.Empty)
            {
                Console.WriteLine("emptyStringBuilder is empty!");
            }

            Console.ReadLine();
        }
    }
}