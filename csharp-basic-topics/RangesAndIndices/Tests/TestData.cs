using RangesAndIndicesExample;
using System.Collections;

namespace Tests;

internal class TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "1", "2", "3", "4", "5", "6" };
        yield return new object[] { "A", "B", "C", "D", "E", "X", "Y", "Z" };
        yield return new object[] {
            "John",
            "Abdul",
            "Abby",
            "Abigail",
            "Doe",
            "Jerod",
            "Adele",
            "Nader",
            "Adam",
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}

internal class NameListTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new NameList() { "1", "2", "3", "4", "5", "6" } };
        yield return new object[] { new NameList() { "A", "B", "C", "D", "E", "X", "Y", "Z" } };
        yield return new object[] { new NameList() {
            "John",
            "Abdul",
            "Abby",
            "Abigail",
            "Doe",
            "Jerod",
            "Adele",
            "Nader",
            "Adam",
        } };
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}