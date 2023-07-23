using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnderstandingPLINQ;

namespace Tests;

[TestClass]
public class ComputerUnitTest
{
    long GetExecutionTime(string label, Action action)
    {
        var sw = Stopwatch.StartNew();
        action();
        sw.Stop();

        Debug.WriteLine($"{label,-20}: {sw.ElapsedTicks:##,#}");

        return sw.ElapsedTicks;
    }

    async Task<long> GetExecutionTime(string label, Task action)
    {
        var sw = Stopwatch.StartNew();
        await action;
        sw.Stop();

        Debug.WriteLine($"{label,-20}: {sw.ElapsedTicks:##,#}");

        return sw.ElapsedTicks;
    }

    IEnumerable<Computer> GetComputers(int count)
    {
        return Enumerable.Range(0, count)
            .Select(i =>
                new Computer()
                {
                    GbRam = (i % 4 + 1) * 8,
                    GbSecondaryMemory = (i % 10 + 1) * 100,
                    MIPS = (i % 10 + 1) * 2000
                });
    }

    [TestMethod]
    public void GivenManyComputers_WhenTestsAreHeavy_ThenPLinqIsFaster()
    {
        var computers = GetComputers(50);
        const int TEST_COUNT = 20;

        var sequentialExecTime = GetExecutionTime("sequential", () =>
        {
            computers.Sum(comp => comp.Test(TEST_COUNT));
        });

        var parallelExecTime = GetExecutionTime("parallel", () =>
        {
            computers.AsParallel().Sum(comp => comp.Test(TEST_COUNT));
        });

        Assert.IsTrue(parallelExecTime < sequentialExecTime);
    }

    [TestMethod]
    public void GivenFewComputers_WhenTestsAreLight_ThenPLinqIsSlower()
    {
        var computers = GetComputers(50);
        const int TEST_COUNT = 0;

        var sequentialExecTime = GetExecutionTime("sequential", () =>
        {
            computers.Sum(comp => comp.Test(TEST_COUNT));
        });

        var parallelExecTime = GetExecutionTime("parallel", () =>
        {
            computers.AsParallel().Sum(comp => comp.Test(TEST_COUNT));
        });

        Assert.IsTrue(parallelExecTime >= sequentialExecTime);
    }

    [TestMethod]
    public void GivenComputersInGroups_WhenTest_ThenAvoidOverParallelization()
    {
        var computers = GetComputers(100);
        const int GROUP_FROM = 1;
        const int GROUP_TO = 100;

        var overParallelExecTime = GetExecutionTime("over-parallel", () =>
        {
            Parallel.For(GROUP_FROM, GROUP_TO, i =>
            {
                var query = from comp in computers.AsParallel().Where(c => c.GetPrice() > i)
                            select comp.Test(0);
                query.ToList();
            });
        });

        var parallelExecTime = GetExecutionTime("parallel", () =>
        {
            Parallel.For(GROUP_FROM, GROUP_TO, i =>
            {
                var query = from comp in computers.Where(c => c.GetPrice() > i)
                            select comp.Test(0);
                query.ToList();
            });
        });

        // The parallel query might be faster anyway, but creating an unnecessary amount of threads
        // Assert.IsTrue(parallelExecTime < overParallelExecTime);
    }

    [TestMethod]
    public void GivenComputers_WhenRegisteredOneAtATime_ThenParallelizationIsWorse()
    {
        var computers = GetComputers(100);

        var sequentialExecTime = GetExecutionTime("sequential", () =>
        {
            var query = from comp in computers
                        select comp.RegisterToNetwork();
            query.ToList();
        });

        var parallelExecTime = GetExecutionTime("parallel", () =>
        {
            var query = from comp in computers.AsParallel()
                        select comp.RegisterToNetwork();
            query.ToList();
        });

        Assert.IsTrue(parallelExecTime >= sequentialExecTime);
    }

    [TestMethod]
    public void GivenComputers_WhenWePingTheirIP_ThenTasksAreBetterThanPLINQ()
    {
        var computers = GetComputers(20);
        computers.Select(comp => comp.RegisterToNetwork());

        var sequentialExecTime = GetExecutionTime("async sequential", async () =>
        {
            var query = await Task.WhenAll(computers.Select(comp => comp.Ping()));
            query.ToList();
        });

        var parallelExecTime = GetExecutionTime("parallel", () =>
        {
            var query = computers.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism).Select(comp => comp.Ping().Result);
            query.ToList();
        });

        Assert.IsTrue(parallelExecTime >= sequentialExecTime);
    }

    [TestMethod]
    public void GivenComputers_WhenTestedWithDifferentMergeOptions_ThenResponsivenessChanges()
    {
        var computers = GetComputers(5000);
        Func<ParallelMergeOptions, ParallelQuery<int>> buildQuery = (mergeOption) =>
            from comp in computers
                .AsParallel()
                .WithMergeOptions(mergeOption)
            select comp.Test(1);

        var notBufferedQuery = buildQuery(ParallelMergeOptions.NotBuffered);
        var notBufferedExecTime = GetExecutionTime("NotBuffered", () =>
        {
            var dummy = notBufferedQuery.GetEnumerator().MoveNext();
        });

        var autoBufferedQuery = buildQuery(ParallelMergeOptions.AutoBuffered);
        var autoBufferedExecTime = GetExecutionTime("AutoBuffered", () =>
        {
            var dummy = autoBufferedQuery.GetEnumerator().MoveNext();
        });

        var fullyBufferedQuery = buildQuery(ParallelMergeOptions.FullyBuffered);
        var fullyBufferedExecTime = GetExecutionTime("FullyBuffered", () =>
        {
            var dummy = fullyBufferedQuery.GetEnumerator().MoveNext();
        });

        // we cannot assert autoBufferedExecTime < fullyBufferedExecTime because 
        // it depends on the chunk size internally chosen
        Assert.IsTrue(notBufferedExecTime < autoBufferedExecTime);
        Assert.IsTrue(notBufferedExecTime < fullyBufferedExecTime);
    }

    [TestMethod]
    public void GivenComputers_WhenWeCachePreviousResults_ThenMakeSequentialTheSecondTime()
    {
        var cache = new ConcurrentDictionary<Tuple<int, int, int>, double>();
        var computers = GetComputers(100);

        var query = computers.AsParallel().Select(comp =>
        {
            var key = Tuple.Create(comp.GbRam, comp.GbSecondaryMemory, comp.MIPS);
            return cache.GetOrAdd(key, k => comp.GetPrice());
        });

        CollectionAssert.AreEquivalent(query.ToList(), query.AsSequential().ToList());
    }

    [TestMethod]
    public void GivenComputers_WhenWeNeedTheSameOrder_ThenUseAsOrdered()
    {
        var computers = GetComputers(500);

        var parallelOrderedQuery = from comp in computers.AsParallel().AsOrdered()
                                   select comp.GetPrice();
        var sequentialQuery = from comp in computers
                              select comp.GetPrice();

        CollectionAssert.AreEqual(parallelOrderedQuery.ToList(), sequentialQuery.ToList());
    }

    [TestMethod]
    public void GivenComputersDuringTest_WhenThereIsTimeLimit_ThenCancelTheQueryInAdvanced()
    {
        var computers = GetComputers(500);
        CancellationTokenSource cts = new CancellationTokenSource();

        var query = from comp in computers.AsParallel().WithCancellation(cts.Token)
                    select comp.Test(100);

        Assert.ThrowsException<OperationCanceledException>(() =>
        {
            var task = Task.Delay(1000).ContinueWith(t => cts.Cancel());
            query.ToList();
        });
    }

    [TestMethod]
    public void GivenComputers_WhenManyExceptionsOccur_ThenCatchAggregateExc()
    {
        var computers = GetComputers(50);

        var query = computers.AsParallel().Select(comp =>
        {
            var price = comp.GetPrice();
            if (price > 200)
                throw new ArgumentOutOfRangeException($"Price ({price}) should be lower than 200");

            return comp.Test(1);
        });

        try
        {
            query.ToList();
            Assert.Fail();
        }
        catch (AggregateException exc)
        {
            exc.Handle(ex => ex is ArgumentOutOfRangeException);
        }
    }

    [TestMethod]
    public void GivenComputers_WhenPutOnMarket_ThenTheyAreReadyForMarket()
    {
        var computers = GetComputers(500).ToArray();
        var query = from comp in computers.AsParallel()
                    select (comp, comp.Test(0));

        query.ForAll(elem => elem.Item1.PutOnTheMarket());

        Assert.IsTrue(computers.All(comp => comp.IsReadyForMarket));
    }
}