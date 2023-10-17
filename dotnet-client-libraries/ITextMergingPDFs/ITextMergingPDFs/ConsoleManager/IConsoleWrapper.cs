namespace ITextMergingPDFs.ConsoleManager
{
    public interface IConsoleWrapper
    {
        void Clear();

        void Write(string message);

        void WriteLine(string message);

        ConsoleKeyInfo ReadKey();
    }
}
