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
            var output = concat("Output", "1");
            Console.Write(output + Environment.NewLine);

            Func<string, string, string> concatenate 
                = new Func<string, string, string>(Concatenate);
            var output2 = concatenate("Output", "2");
            Console.Write(output2 + Environment.NewLine);

            Func<string, string, string> concatenateString 
                = delegate (string firstPart, string secondPart)
            {
                return firstPart + " " + secondPart;
            };
            var output3 = concatenateString("Output", "3");
            Console.Write(output3 + Environment.NewLine);

            Func<string, string, string> concatString 
                = (string firstPart, string secondPart) => firstPart + " " + secondPart;
            var output4 = concatString("Output", "4");
            Console.Write(output4);
        }
    }
}
