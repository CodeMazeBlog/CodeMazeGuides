namespace ListExistsInAnotherCSharp;

public class CompareStudentsExamples
{
    public static bool CompareStudentsUsingIntersect(List<Student> firstList, List<Student> secondList)
    {
        return firstList
            .Select(student => $"{student.FirstName} {student.LastName}")
            .Intersect(secondList.Select(student => $"{student.FirstName} {student.LastName}"))
            .Any();
    }

    public static bool CompareStudentsUsingAnyContains(List<Student> firstList, List<Student> secondList)
    {
        return secondList.Any(student =>
            firstList.Any(s =>
                s.FirstName == student.FirstName && s.LastName == student.LastName));
    }

    public static bool CompareStudentsUsingIteration(List<Student> firstList, List<Student> secondList)
    {
        foreach (var student in firstList)
        {
            if (secondList.Any(s =>
                s.FirstName == student.FirstName && s.LastName == student.LastName))
            {
                return true;
            }
        }

        return false;
    }

    public static bool CompareStudentsUsingExcept(List<Student> firstList, List<Student> secondList)
    {
        return secondList
            .Select(student => $"{student.FirstName} {student.LastName}")
            .Except(firstList.Select(student => $"{student.FirstName} {student.LastName}"))
            .Count() != secondList.Count;
    }

    public static bool CompareStudentsUsingWhereAny(List<Student> firstList, List<Student> secondList)
    {
        return secondList
            .Any(student =>
                firstList.Any(s =>
                    s.FirstName == student.FirstName && s.LastName == student.LastName));
    }
}
