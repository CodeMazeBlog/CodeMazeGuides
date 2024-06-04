namespace FindAllPositionsOfAString.Algorithms.Interfaces;

internal interface ISearcher
{
    bool CaseSensitive { get; set; }
    bool SkipWholeFoundText { get; set; }

    List<int> FindAll(string text, string searchText);
}
