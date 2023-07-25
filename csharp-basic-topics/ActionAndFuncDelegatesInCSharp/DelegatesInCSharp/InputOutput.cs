public class InputOutput
{
    private string lastInput;

    public void Read(Func<string> input)
    {
        lastInput = input();
    }

    public void Write(Action<string> printCallback)
    {
        var length = lastInput == null ? 0 : lastInput.Length;
        printCallback($"'{lastInput}' has {length} characters.");
    }
}