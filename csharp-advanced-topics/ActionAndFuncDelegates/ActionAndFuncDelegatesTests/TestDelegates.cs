namespace ActionAndFuncDelegatesTests;

public class TestDelegates
{
    private StringWriter _output;

    protected void SetupOutput()
    {
        _output = new StringWriter();
        Console.SetOut(_output);
    }

    protected void DisposeOutput()
    {
        _output.Dispose();
        GC.SuppressFinalize(this);
    }
    
    protected string[] PrintedOutputToArray()
    {
        var printedString = _output.ToString();
        return printedString.Split( Environment.NewLine );
    }
}