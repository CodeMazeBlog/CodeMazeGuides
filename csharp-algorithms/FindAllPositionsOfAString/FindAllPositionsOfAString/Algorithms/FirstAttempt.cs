namespace FindAllPositionsOfAString.Algorithms;

public static class FirstAttempt
{
    public static List<int> FindAll(string text, string searchText)
    {
        List<int> positions = [];

        var index = text.IndexOf(searchText);
        while (index != -1)
        {
            positions.Add(index);
            index = text.IndexOf(searchText, index + 1);
        }

        return positions;
    }
}
