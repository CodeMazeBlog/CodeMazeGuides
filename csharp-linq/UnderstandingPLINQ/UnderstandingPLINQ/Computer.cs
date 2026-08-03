using System.Net;

namespace UnderstandingPLINQ;

public class Computer
{
    private static readonly object networkObj = new object();
    public IPAddress IPAddress { get; private set; } = null!;
    public int GbRam { get; init; }
    public int GbSecondaryMemory { get; init; }
    public int MIPS { get; init; }
    public bool IsReadyForMarket { get; private set; } = false;

    public int Test(int testCount)
    {
        if (testCount > 0)
            Thread.Sleep(testCount);
        return new Random().Next() % (testCount + 1);
    }

    public double GetPrice()
    {
        Thread.Sleep(1);
        return (GbRam * 10) + (GbSecondaryMemory * 0.1) + (MIPS * 0.01);
    }

    public string RegisterToNetwork()
    {
        lock (networkObj)
        {
            IPAddress = new IPAddress(new Random().Next());
            return IPAddress.ToString();
        }
    }

    public async Task<int> Ping()
    {
        await Task.Delay(30);
        return 0;
    }

    public void PutOnTheMarket()
    {
        IsReadyForMarket = true;
    }
}
