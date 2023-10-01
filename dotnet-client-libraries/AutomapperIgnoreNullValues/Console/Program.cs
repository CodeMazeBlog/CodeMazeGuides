namespace AutoMapperIgnoreNullValues;
internal class Program
{
    static void Main(string[] args)
    {
        var source = new StudentItemDto()
        {
            Name = "Test",
            AgeInfo = 29,
            University = null,
            Grades = null
        };

        AutoMapperManager.UpdateStudent(source);

        AutoMapperManager.UpdateStudentIgnoreNullValues(source);

        Console.ReadLine();
    }
}