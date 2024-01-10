namespace ListExistsInAnotherCSharp;

public class CompareStudentsExamples
{
    public bool CompareStudentsUsingIntersect(List<Student> firstList, List<Student> secondList)
    {
        return firstList
            .Select(student => $"{student.FirstName} {student.LastName}")
            .Intersect(secondList.Select(student => $"{student.FirstName} {student.LastName}"))
            .Any();
    }

    public bool CompareStudentsUsingAnyContains(List<Student> firstList, List<Student> secondList)
    {
        return secondList.Any(student =>
            firstList.Any(s =>
                s.FirstName == student.FirstName && s.LastName == student.LastName));
    }

    public bool CompareStudentsUsingIteration(List<Student> firstList, List<Student> secondList)
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

    public bool CompareStudentsUsingExcept(List<Student> firstList, List<Student> secondList)
    {
        return secondList
            .Select(student => $"{student.FirstName} {student.LastName}")
            .Except(firstList.Select(student => $"{student.FirstName} {student.LastName}"))
            .Count() != secondList.Count;
    }

    public bool CompareStudentsUsingWhereAny(List<Student> firstList, List<Student> secondList)
    {
        return secondList
            .Any(student =>
                firstList.Any(s =>
                    s.FirstName == student.FirstName && s.LastName == student.LastName));
    }
}
