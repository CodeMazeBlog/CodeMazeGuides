public class InputOutput
{
    private string lastInput;
    
    public void Read(Func<string> input)
    {
        lastInput = input();
    }
    
    public void Write(Action<string> printCallback)
    {
        printCallback($"'{lastInput}' has {lastInput.Length} characters.");
    }
}