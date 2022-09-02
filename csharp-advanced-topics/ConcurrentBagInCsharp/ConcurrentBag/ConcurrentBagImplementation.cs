using System.Collections.Concurrent;

namespace ConcurrentBag;

public class ConcurrentBagImplementation
{
    private readonly ConcurrentBag<int> _concurrentBag = new ConcurrentBag<int>();
    private List<string> _result = new List<string>();
    public ConcurrentBag<int> CreateConcurrentBag(int[] number)
    {
        var concurrentBag = new ConcurrentBag<int>(number);
        return concurrentBag;
    }

public (int,int,int) MultiThread_Implementation(List<int> task1Input, List<int> task2Input)
{
    var task1 = Task.Run(() =>
    {
        int count = 0;
        int sum = 0;
        int value = 0;
        foreach (var item in task1Input)
        {
            _concurrentBag.Add(item);
            if (count == task1Input.Count - 2)
            {
                _concurrentBag.TryTake(out value);
                sum += value;
                _concurrentBag.TryTake(out value);
                sum += value;
                Thread.Sleep(500);
            }
            count++;
        }
        value = 0;
        _concurrentBag.TryTake(out value);
        sum += value;
        _concurrentBag.TryTake(out value);
        sum += value;
        _concurrentBag.TryTake(out value);
        sum += value;
        return sum;
    });
    var task2 = Task.Run(() =>
    {
        int sum = 0;
        int value = 0;
        foreach (var item in task2Input)
        {
            _concurrentBag.Add(item);         
        }
        Thread.Sleep(2000);
        _concurrentBag.TryTake(out value);
        sum += value;
        _concurrentBag.TryTake(out value);
        sum += value;
        return sum;
    });
    Task.WaitAll(task1, task2);
    return (task1.Result,task2.Result, _concurrentBag.Sum());
}
}
