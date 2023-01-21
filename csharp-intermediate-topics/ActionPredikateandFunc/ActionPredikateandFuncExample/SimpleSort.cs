namespace ActionPredikateandFuncExample
{
  public class SimpleSort
  {
    public void SortNumbers(int[] numbers) =>
      bubbleSort(numbers, (a, b) => a > b);

    public void SortStrings(string[] words) =>
      bubbleSort(words, (a, b) => string.Compare(a, b) > 0);

    public void DisplyArray<T>(string prefix, T[] array) =>
      Console.WriteLine($"{prefix}: {string.Join(",", array)}");

    private void bubbleSort<T>(T[] array, Func<T, T, bool> comparison)
    {
      bool swapped;
      do
      {
        swapped = false;
        for (int i = 0; i < array.Length - 1; i++)
          if (comparison(array[i], array[i + 1]))
          {
            T temp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = temp;
            swapped = true;
          }
      } while (swapped);
    }
  }
}
