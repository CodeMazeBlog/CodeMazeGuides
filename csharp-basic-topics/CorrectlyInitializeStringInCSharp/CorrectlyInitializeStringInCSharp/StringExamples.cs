using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectlyInitializeStringInCSharp
{
    public class StringExamples
    {
        public static string MyString1()
        {
            string myString = "Hello, World!";
            return myString;
        }

        public static string MyString2()
        {
            string myString = "Hello,\nWorld!";
            return myString;
        }

        public static string FullName(string firstName, string lastName)
        {
            string fullName = firstName + " " + lastName;
            return fullName;
        }

        public static string Path()
        {
            string path = @"C:\Users\Codemaze\Documents";
            return path;
        }

        public static string MultiLineString()
        {
            string message = @"This is
            a multi-line
            string.";
            return message;
        }

        public static string EmptyString()
        {
            string emptyString = string.Empty;
            return emptyString;
        }

        public static string? NullString()
        {
            string? nullString = null;
            return nullString;
        }

        public static string? DefaultString()
        {
            string? myString3 = default(string);
            return myString3;
        }

        public static string StringBuilderString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello");
            sb.Append(" World");
            string myString4 = sb.ToString();
            return myString4;
        }

        public static string SumString(int num1, int num2)
        {
            string myString5 = $"The sum of {num1} and {num2} is {num1 + num2}";
            return myString5;
        }

        public static string AsteriskString(int count)
        {
            string myString6 = new string('*', count);
            return myString6;
        }

    }

}
