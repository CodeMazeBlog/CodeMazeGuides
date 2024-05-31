namespace FindAllPositionsOfAString;

internal interface ISearcher
{
    void Initialize(string searchValue);

    List<int> FindAll(string text);
}
