namespace FuncAndActionDelegatesInCSharp
{
    public delegate string GenerateText(string word, int number);

    public static class RegularDelegate
    {
        public static void UseRegularDelegateToRepeatWord()
        {
            GenerateText Generate = Utilities.RepeatWord;
            Console.WriteLine(Generate("delegate", 4));
        }
    }
}
