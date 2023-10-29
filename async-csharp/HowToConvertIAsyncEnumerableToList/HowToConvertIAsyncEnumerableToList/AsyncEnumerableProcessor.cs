namespace HowToConvertIAsyncEnumerableToList;

public class AsyncEnumerableProcessor
{
    public async IAsyncEnumerable<string> GetDataAsync()
    {
        for (int i = 0; i < 3; i++)
        {
            await Task.Delay(1000);
            yield return $"item{i}";
        }
    }
}
