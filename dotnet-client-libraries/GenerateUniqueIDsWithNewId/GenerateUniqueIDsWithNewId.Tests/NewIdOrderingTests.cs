using System.Data.SqlTypes;
using MassTransit;

namespace GenerateUniqueIDsWithNewId.Tests;

public class NewIdOrderingTests
{
    private static List<Guid> Generate(Func<Guid> next, int count = 1000) =>
        Enumerable.Range(0, count).Select(_ => next()).ToList();

    [Fact]
    public void WhenNextGuidIsUsed_ThenSqlServerOrderMatchesCreationOrder()
    {
        var ids = Generate(NewId.NextGuid);

        Assert.Equal(ids, ids.OrderBy(id => new SqlGuid(id)));
    }

    [Fact]
    public void WhenNextSequentialGuidIsUsed_ThenGuidAndTextOrderMatchCreationOrder()
    {
        var ids = Generate(NewId.NextSequentialGuid);

        Assert.Equal(ids, ids.OrderBy(id => id));
        Assert.Equal(ids, ids.OrderBy(id => id.ToString(), StringComparer.Ordinal));
    }

    [Fact]
    public void WhenCreateVersion7IsUsedOncePerMillisecond_ThenGuidOrderMatchesButSqlServerOrderDoesNot()
    {
        var ids = Generate(() =>
        {
            Thread.Sleep(2);
            return Guid.CreateVersion7();
        }, 50);

        Assert.Equal(ids, ids.OrderBy(id => id));
        Assert.NotEqual(ids, ids.OrderBy(id => new SqlGuid(id)));
    }
}
