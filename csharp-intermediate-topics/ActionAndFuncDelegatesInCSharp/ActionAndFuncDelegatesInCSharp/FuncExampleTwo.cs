namespace ActionAndFuncDelegatesInCSharp
{
    public class FuncExampleTwo
    {
        Func<string, string> changeToUpperCase;
        public FuncExampleTwo()
        {
            changeToUpperCase = ChangeTextToUpperCase;
            changeToUpperCase("codemaze is great"); //This outputs: CODEMAZE IS GREAT
        }

        public string ChangeTextToUpperCase(string text)
        {
            return text.ToUpper();
        }
    }
}