namespace ActionFuncDelegatesInCSharp
{
    public class FuncDelegates
    {
        static string Concatenate(string firstPart, string secondPart)
        {
            return firstPart + " " + secondPart;
        }

        public static void CreateFuncDelegates()
        {
            Func<string, string, string> concat = Concatenate;
            string output = concat("Output", "1");
            Console.WriteLine(output);

            Func<string, string, string> concatenate = new Func<string, string, string>(Concatenate);
            string output2 = concatenate("Output", "2");
            Console.WriteLine(output2);

            Func<string, string, string> concatenateString = delegate (string firstPart, string secondPart)
            {
                return firstPart + " " + secondPart;
            };
            string output3 = concatenateString("Output", "3");
            Console.WriteLine(output3);

            Func<string, string, string> concatString = (string firstPart, string secondPart) => firstPart + " " + secondPart;
            string output4 = concatString("Output", "4");
            Console.WriteLine(output4);
        }
    }
}
