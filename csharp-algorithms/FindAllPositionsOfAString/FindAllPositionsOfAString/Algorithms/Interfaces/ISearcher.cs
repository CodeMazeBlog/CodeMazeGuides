namespace FindAllPositionsOfAString.Algorithms.Interfaces;

internal interface ISearcher
{
    bool CaseSensitive { get; set; }
    bool SkipWholeFoundText { get; set; }

    void Initialize(string searchText);

    List<int> FindAll(string text);
}
