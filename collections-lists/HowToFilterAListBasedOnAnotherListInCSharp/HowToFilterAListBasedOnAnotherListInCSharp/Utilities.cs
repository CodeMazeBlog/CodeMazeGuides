namespace HowToFilterAListBasedOnAnotherListInCSharp;

public static class Utilities
{
    public static string PrintList<T>(List<T> list)
    {
        return string.Join(", ", list);
    }
       
    public static List<int> FilterContainedUsingLoop(List<int> listToFilter, List<int> filteringList)
    {
        List<int> filteredList = [];

        foreach (int item in listToFilter)
        {
            if (filteringList.Contains(item))
                filteredList.Add(item);
        }

        return filteredList;
    }

    public static List<int> FilterNotContainedUsingLoop(List<int> listToFilter, List<int> filteringList)
    {
        List<int> filteredList = [];

        foreach (int item in listToFilter)
        {
            if (!filteringList.Contains(item))
                filteredList.Add(item);
        }

        return filteredList;
    }

    public static List<int> FilterContainedUsingWhere(List<int> listToFilter, List<int> filteringList)
    {
        return listToFilter.Where(filteringList.Contains).ToList();
    }

    public static List<int> FilterNotContainedUsingWhere(List<int> listToFilter, List<int> filteringList)
    {
        return listToFilter.Where(x => !filteringList.Contains(x)).ToList();
    }
    
    public static List<int> FilterContainedUnique(List<int> listToFilter, List<int> filteringList)
    {
        return listToFilter.Where(filteringList.Contains).Distinct().ToList();
    }

    public static List<int> FilterNotContainedUsingExcept(List<int> listToFilter, List<int> filteringList)
    {
        return listToFilter.Except(filteringList).ToList();
    }

    public static List<string> FilterStringsByInts(List<string> listToFilter, List<int> filteringList)
    {
        return listToFilter.Where(x => filteringList.Contains(int.Parse(x))).ToList();
    }

    public static List<string> FilterAnimalNamesByLengths(List<string> listToFilter, List<int> filteringList)
    {
        return listToFilter.Where(animalName => filteringList.Any(length => animalName.Length == length))
            .ToList();
    }
        
    public static List<Student> FilterStudentsBySchoolCity(List<Student> listToFilter, List<School> filteringList)
    {
        return listToFilter.Where(student => filteringList.Any(school => student.City == school.City))
            .ToList();
    }

    public static List<string> FilterStudentsWithProperties(List<Student> listToFilter, List<int> filteringList)
    {
        return listToFilter.Where(student => filteringList.Contains(student.SchoolId))
            .Select(student => student.Name).ToList();
    }

    public static void UpdateCityProperty(List<Student> listToFilter, List<int> filteringList)
    {
        listToFilter.ForEach(student =>
        {
            if (filteringList.Contains(student.Id))
                student.City = "Berlin";
        });
    }
        
    public static List<int> FilterUsingHashSet(List<int> listToFilter, List<int> filteringList)
    {
        HashSet<int> hashToFilter = new HashSet<int>(listToFilter);
        hashToFilter.IntersectWith(filteringList);

        return hashToFilter.ToList();
    }

    public static List<int> FilterUsingMask(List<int> listToFilter, List<bool> mask)
    { 
        return listToFilter.Where((item, index) => mask[index % mask.Count]).ToList();
    }
}
