namespace ListExistsInAnotherCSharp;

public class CompareListsMethods
{
    public bool CompareListUsingIntersect(List<int> firstList, List<int> secondList) 
    {
        return firstList.Intersect(secondList).Any();
    }

    public bool CompareListUsingAnyContains(List<int> firstList, List<int> secondList)
    {
        return secondList.Any(firstList.Contains);
    }

    public bool CompareListUsingExcept(List<int> firstList, List<int> secondList)
    {
        return !(secondList.Except(firstList).Any());
    }
}
