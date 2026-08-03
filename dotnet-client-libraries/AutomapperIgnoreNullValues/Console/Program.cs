using Newtonsoft.Json;

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

        Console.WriteLine("\nSource : {0}", JsonConvert.SerializeObject(source, Formatting.Indented));

        try
        {
            Console.WriteLine("\nUsing DefaultMappingProfile:");
            AutoMapperManager.UpdateStudent(source);
            Console.WriteLine("Mapped without exception");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Mapped with exception : " + ex.Message);
        }

        try
        {
            Console.WriteLine("\nUsing IgnoreNullMappingProfile:");
            AutoMapperManager.UpdateStudentIgnoreNullValues(source);
            Console.WriteLine("Mapped without exception");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Mapped with exception : " + ex.Message);
        }

        Console.ReadLine();
    }
}