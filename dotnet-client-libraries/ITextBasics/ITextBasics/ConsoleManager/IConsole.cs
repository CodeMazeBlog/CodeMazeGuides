namespace ITextBasics.ConsoleManager
{
    public interface IConsole
    {
        void Clear();

        void Write(string message);

        void WriteLine(string message);

        ConsoleKeyInfo ReadKey();
    }
}
