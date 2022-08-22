using System.Collections.Concurrent;

namespace ConcurrentBag;

public class ConcurrentBagImplementation
{
    private readonly ConcurrentBag<string> _concurrentBag = new ConcurrentBag<string>();
    private List<string> _result = new List<string>();
    public void AddtoConcurrentBag(int i, string taskName)
    {
        int counter = 0;
        while (counter < 3)
        {
            var data = $"{taskName}: Added {i}";
            _result.Add(data);
            _concurrentBag.Add($"{i}");
            i++;
            counter++;
        }
    }
    public void ReadConcurrentBag(string taskName)
    {
        string? value;
        if (_concurrentBag.TryTake(out value))
        {
            var data = $"{taskName}: Read {value}";
            _result.Add(data);
        }
    }
    public List<string> UpdateConcurrentBag()
    {
        var task1 = Task.Run(() =>
        {
            AddtoConcurrentBag(1,"T1");
            Thread.Sleep(1000);
            ReadConcurrentBag("T1");
            ReadConcurrentBag("T1");
            ReadConcurrentBag("T1");
            ReadConcurrentBag("T1");
            ReadConcurrentBag("T1");
        });
        var task2 = Task.Run(() =>
        {
            AddtoConcurrentBag(20,"T2");
            ReadConcurrentBag("T1");
            Thread.Sleep(2000);
            ReadConcurrentBag("T2");
            ReadConcurrentBag("T1");
            ReadConcurrentBag("T1");
            ReadConcurrentBag("T1");

        });
        Task.WaitAll(task1, task2);
        return _result;
    }

}
