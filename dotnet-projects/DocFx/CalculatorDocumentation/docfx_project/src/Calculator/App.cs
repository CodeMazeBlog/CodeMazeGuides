namespace Calculator;

/// <summary>
/// This is our Calculator app, which performs basic mathmatical operations.
/// </summary>
public static class App
{
    /// <summary>
    /// Takes two numbers and adds them together
    /// </summary>
    /// <param name="one">The first number</param>
    /// <param name="two">The second number</param>
    /// <returns>int</returns>
    public static int Add(int one, int two)
        => one + two;

    /// <summary>
    /// Subtracts the second number from the first number
    /// </summary>
    /// <param name="one">The first number</param>
    /// <param name="two">The second number</param>
    /// <returns>int</returns>
    public static int Subtract(int one, int two)
        => one - two;
}