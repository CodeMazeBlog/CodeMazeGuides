namespace FuncAndActionDelegatesInCSharp;

public static class ActionExample
{
    public static void ProcessStringsUsingAction(List<string> words, Action<string> outputAction)
    {
        // The ForEach method iterates over each item in the list and applies the specified action delegate.
        words.ForEach(outputAction);
    }
}