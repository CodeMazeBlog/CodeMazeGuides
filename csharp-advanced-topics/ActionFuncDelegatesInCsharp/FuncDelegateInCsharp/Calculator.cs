// Define a class that has an event that uses a Func delegate as a callback.
public class Calculator
{
    public event Func<int, int, int>? OnAddIntegers;

    public int AddIntegers(int a, int b)
    {
        // If the OnAddIntegers event has any subscribers, invoke them.
        if (OnAddIntegers != null)
        {
            return OnAddIntegers(a, b);
        }

        // Otherwise, return the sum of the two integers.
        return a + b;
    }
}

