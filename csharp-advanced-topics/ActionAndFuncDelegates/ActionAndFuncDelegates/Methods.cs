namespace ActionAndFuncDelegates;

public class Methods
{
    public bool LoggerCalled;
    
    public int Adder(int a, int b)
    {
        return a + b;
    }

    public void Logger(string message)
    {
        // Actual implementation would log error message
        LoggerCalled = true;
    }
}