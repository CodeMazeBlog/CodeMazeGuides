using System.Collections;

namespace RangesAndIndicesExample;

public class NameList : IEnumerable<string>
{
    private List<string> _names;

    public NameList()
    {
        _names = new List<string>();
    }

    public string this[int index] => _names[index];

    public int Count => _names.Count;

    public IEnumerator<string> GetEnumerator()
    {
        return _names.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_names).GetEnumerator();
    }

    public void Add(string name) => _names.Add(name);

    public List<string> Slice(int start, int length)
        => _names
              .Skip(start)
              .Take(length)
              .ToList();

}