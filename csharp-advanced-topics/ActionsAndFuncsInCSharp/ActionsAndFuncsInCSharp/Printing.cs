namespace ActionsAndFuncsInCSharp
{
    /// <summary>
    /// Includes methods for printing statements to the console window.
    /// </summary>
    public static class Printing
    {
        /// <summary>
        /// Prints statements in the console window.
        /// </summary>
        public static void PrintInfo()
        {
            Console.WriteLine("Hello world!");
        }

        /// <summary>
        /// Returns a printable statement in the console window.
        /// </summary>
        public static string PrintInfo2()
        {
            return "Hello world!";
        }

        /// <summary>
        /// Prints statements in the console window.
        /// </summary>
        /// <param name="caption">
        /// The caption text to be printed.
        /// </param>
        public static void PrintInfo(string caption)
        {
            Console.WriteLine(caption);
        }

        /// <summary>
        /// Returns a printable statement in the console window.
        /// </summary>
        /// <param name="caption">
        /// The caption text to be displayed.
        /// </param>
        public static string PrintInfo2(string caption)
        {
            return caption;
        }

        /// <summary>
        /// Outputs a multiple of two integer values.
        /// </summary>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        public static int Multiply(int x, int y) 
        { 
            return x * y; 
        }
    }
}