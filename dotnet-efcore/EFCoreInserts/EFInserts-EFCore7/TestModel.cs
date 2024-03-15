using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace EFInserts_EFCore7;

[SimpleJob(RunStrategy.ColdStart, launchCount:1, warmupCount:1, iterationCount:10)]
public class TestModel
{
private List<string> Names { get; set; }

private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
private static readonly Random Random = new Random();

private static string RandomString(int length)
{
    return new string(Enumerable.Repeat(Chars, length)
        .Select(s => s[Random.Next(s.Length)]).ToArray());
}
    
    private int _batchSize;
    [Params(100, 1000, 3000)]
    public int BatchSize { 
        get => _batchSize;
        set
        {
            _batchSize = value;            
            InitNames();
        } 
    }

    private void InitNames()
    {
        Names = new List<string>(_batchSize);
        for (var i = 0; i < _batchSize; i++)
        {
            Names.Add(RandomString(20));
        }
    }
    
    private readonly ModelContext _modelContext;

    public TestModel()
        :this(new ModelContext())
    {
    }

    public TestModel(ModelContext modelContext)
    {
        Names = new List<string>(0);
        _modelContext = modelContext;
    }
    
    private static Stopwatch StartTimer()
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        return stopWatch;
    }

    private static void PrintTimeElapsed(Stopwatch stopWatch)
    {
        stopWatch.Stop();
        var ts = stopWatch.Elapsed;
        Console.WriteLine($"Run time: {ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds / 10:00}");
    }

    [Benchmark]
    public void AddOneByOneWithSave()
    {
        var stopWatch = StartTimer();

        foreach (var name in Names)
        {
            _modelContext.Add(new Model.Person() { Name = name });
            _modelContext.SaveChanges();
        }
        
        PrintTimeElapsed(stopWatch);
    }

    [Benchmark]
    public void AddOneByOne()
    {
        var stopWatch = StartTimer();

        foreach (var name in Names)
        {
            _modelContext.Add(new Model.Person() { Name = name });    
        }
        _modelContext.SaveChanges();

        PrintTimeElapsed(stopWatch);
    }

    [Benchmark]
    public void AddRange()
    {
        var stopWatch = StartTimer();
        
        IList<Model.Person> batch = new List<Model.Person>(
            Names.Select(n => new Model.Person() { Name = n }));
        _modelContext.AddRange(batch);
        _modelContext.SaveChanges();
    
        PrintTimeElapsed(stopWatch);
    }

    [Benchmark]
    public void BulkExtensionBulkInsert()
    {
        var stopWatch = StartTimer();
        
        IList<Model.Person> batch = new List<Model.Person>(
            Names.Select(n => new Model.Person() { Name = n }));
        _modelContext.MockableBulkInsert(batch);
    
        PrintTimeElapsed(stopWatch);
    }

    public void RunEachMethod()
    {
        Console.WriteLine("Add one by one with save");
        AddOneByOneWithSave();
            
        Console.WriteLine("\nAdd one by one");
        AddOneByOne();
    
        Console.WriteLine("\nAdd range");
        AddRange();
        
        Console.WriteLine("\nBulkExtensions bulk insert");
        BulkExtensionBulkInsert();
    }
}