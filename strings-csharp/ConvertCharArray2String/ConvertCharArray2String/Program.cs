
using System.Text;

namespace ConvertCharArray2String
{
    public class Program
    {
        public static void Main(string[] args)
        {

            char[] charArray = { 'c', 'o', 'd', 'e', ' ', 'm', 'a', 'z', 'e' };

            var convertedToString = new string(charArray);

            Console.WriteLine(convertedToString);

            var joinedToString = string.Join("", charArray);
            
            Console.WriteLine(joinedToString);

            var concattedToString = string.Concat(charArray);

            Console.WriteLine(concattedToString); 

            Console.ReadLine();
        }
    }
}