using System.Collections;

namespace TheForEachMethodAndForeachStatement.Tests.Data;

public class ListOfIntTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new List<int> { 1 }, 1 };
        yield return new object[] { new List<int> { -100, 0 }, -100 };
        yield return new object[] { new List<int> { 1, 2, 3, 4, 5 }, 15 };
        yield return new object[] { new List<int> { 1, 2, 3, 4, -5 }, 5 };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
