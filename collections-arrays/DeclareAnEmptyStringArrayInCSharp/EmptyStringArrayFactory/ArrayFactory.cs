namespace EmptyStringArrayFactory
{
    public class ArrayFactory
    {
        public static string[] CreateEmptyArrayExample1()
        {
            return new string[0];
        }

        public static string[] CreateEmptyArrayExample2()
        {
            return new string[] { };
        }

        public static string[] CreateEmptyArrayExample3()
        {
            string[] myArray = { };

            return myArray;
        }

        public static string[] CreateEmptyArrayExample4()
        {
            return Enumerable.Empty<string>().ToArray();
        }

        public static string[] CreateEmptyArrayExample5()
        {
            return Enumerable.Repeat("", 0).ToArray();
        }

        public static string[] CreateEmptyArrayExample6()
        {
            return Enumerable.Repeat(string.Empty, 0).ToArray();
        }

        public static string[] CreateEmptyArrayExample7()
        {
            return Array.Empty<string>();
        }
    }
}