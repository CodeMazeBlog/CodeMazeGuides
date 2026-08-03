namespace FindAllPositionsOfAString.Algorithms.Interfaces;

internal interface ISearcher
{
    bool CaseSensitive { get; }
    bool SkipWholeFoundText { get; }

    List<int> FindAll(string text);
}
