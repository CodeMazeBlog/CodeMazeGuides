namespace ActionAndFuncDelegatesInCSharp
{
    public interface IConsole
    {
        void Output(string text);
    }

    internal class Console : IConsole
    {
        public void Output(string text) => System.Console.WriteLine(text);
    }
}
