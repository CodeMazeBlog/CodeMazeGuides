namespace ActionAndFuncDelegatesInCSharp
{
    public static class FuncDelegate
    {
        // Define a method to add two numbers and return the result
       public static Func<int, int, int> add = (a, b) => a + b;
    }
}
