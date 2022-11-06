using System.Text;
using System.Text.RegularExpressions;

namespace ConvertCharArray2String
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputString = "Hello1";


            //Method 1
            {
                bool result = char.IsDigit(inputString.Last());
            }

            //Method 2
            {
                var lastChar = inputString.Last();
                bool result = lastChar >= '0' && lastChar <= '9';
            }
            //Method 3
            {
                bool result = inputString.Substring(inputString.Length - 1).All(char.IsDigit);
            }

            //Method 4
            {
                var regex = new Regex(@"\d+$");
                bool result = regex.Match(inputString).Success;
            }

        }
    }
}