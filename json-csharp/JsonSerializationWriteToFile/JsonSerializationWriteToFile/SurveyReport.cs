namespace JsonSerializationWriteToFile;

public static class SurveyReport
{
    public static List<College> GetColleges() => new()
    {
        new("Juvenile", 300, false),
        new("Cambrian", 650, true),
        new("Mapple Leaf", 450, true)
    };

    public static IEnumerable<College> GetColleges(
        int noOfColleges, 
        int teachersPerCollege, 
        int coursesPerTeacher)
    {
        for (var i = 0; i < noOfColleges; i++)
        {
            yield return new($"College{i}", 100, true, GetTeachers());
        }

        List<Teacher>? GetTeachers()
            => Enumerable.Repeat<Teacher>(new($"John", 8, false, GetCourses()), teachersPerCollege).ToList();        

        List<Course>? GetCourses()
            => Enumerable.Repeat<Course>(new($"Course", 4, false), coursesPerTeacher).ToList();
    }
}