namespace ActionPredikateandFuncExample
{
  public static class FuncDelegate
  {
    public static void Execute()
    {
      SimpleSort simpleSort = new();

      int[] numbers = { 4, 2, 9, 6, 23, 12, 34, 0, 1 };
      simpleSort.DisplyArray("BEFORE", numbers);
      simpleSort.SortNumbers(numbers);
      simpleSort.DisplyArray("AFTER ", numbers);

      string[] words = { "hello", "world", "goodbye", "csharp" };
      simpleSort.DisplyArray("BEFORE", words);
      simpleSort.SortStrings(words);
      simpleSort.DisplyArray("AFTER ", words);
    }
  }
}
