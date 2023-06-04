using System.Text;

namespace CorrectlyInitializeStringInCSharp
{
    public class StringExamples
    {
        public static string MyString1()
        {
            var myString = "Hello, World!";

            return myString;
        }

        public static string MyString2()
        {
            var myString = "Hello,\nWorld!";

            return myString;
        }

        public static string FullName(string firstName, string lastName)
        {
            var fullName = firstName + " " + lastName;

            return fullName;
        }

        public static string Path()
        {
            var path = @"C:\Users\Codemaze\Documents";

            return path;
        }

        public static string MultiLineString()
        {
            var message = @"This is
            a multi-line
            string.";

            return message;
        }

        public static string EmptyString()
        {
            var emptyString = string.Empty;

            return emptyString;
        }

        public static string? NullString()
        {
            string? nullString = null;

            return nullString;
        }

        public static string? DefaultString()
        {
            var myString3 = default(string);

            return myString3;
        }

        public static string StringBuilderString()
        {
            var sb = new StringBuilder();
            sb.Append("Hello");
            sb.Append(" World");
            var myString4 = sb.ToString();

            return myString4;
        }

        public static string StringBuilderInsert()
        {
            var stringBuilder = new StringBuilder("Hello World!");
            stringBuilder.Insert(5, ", ");
            var result = stringBuilder.ToString();

            return result;

        }

        public static string StringBuilderReplace()
        {
            var stringBuilder = new StringBuilder("Hello World!");
            stringBuilder.Replace("World", "Universe");
            var result = stringBuilder.ToString();

            return result;
        }

        public static string StringBuilderClear()
        {
            var stringBuilder = new StringBuilder("Hello World!");
            stringBuilder.Clear();
            var result = stringBuilder.ToString();

            return result;
        }
        public static string SumString(int num1, int num2)
        {
            var myString5 = $"The sum of {num1} and {num2} is {num1 + num2}";

            return myString5;
        }

        public static string AsteriskString(int count)
        {
            var myString6 = new string('*', count);

            return myString6;
        }
    }
}
