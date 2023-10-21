namespace FuncAndActionDelegatesInCSharp
{
    public delegate string GenerateText(string word, int number);

    public static class RegularDelegate
    {
        public static void UseRegularDelegateToRepeatWord()
        {
            GenerateText generate = Utilities.RepeatWord;
            Console.WriteLine(generate("delegate", 4));
        }
    }
}
