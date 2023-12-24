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

    public bool CompareListUsingIteration(List<int> firstList, List<int> secondList) 
    {
        var elementExists = false;

        foreach (var item in firstList)
        {
            if (secondList.Contains(item))
            {
                elementExists = true;
                break;
            }
        }

        return elementExists;
    }
    public bool CompareListUsingExcept(List<int> firstList, List<int> secondList)
    {
        return !(secondList.Except(firstList).Any());
    }
}
