using AutoMapper;
using Newtonsoft.Json;

namespace AutoMapperIgnoreNullValues;

public class AutoMapperManager
{
    public static StudentEntity UpdateStudent(StudentItemDto source)
    {
        return MapToStudentEntity<DefaultMappingProfile>(source);
    }

    public static StudentEntity UpdateStudentIgnoreNullValues(StudentItemDto source)
    {
        return MapToStudentEntity<IgnoreNullMappingProfile>(source);
    }

    private static StudentEntity MapToStudentEntity<TProfile>(StudentItemDto source)
           where TProfile : Profile, new()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<TProfile>();
        });

        IMapper mapper = config.CreateMapper();
        var destination = GetSampleEntity();
        destination = mapper.Map(source, destination);

        Console.WriteLine("Destination : {0}",
            JsonConvert.SerializeObject(destination, Formatting.Indented));

        if (destination.Department == null)
            throw new ArgumentNullException("Department", "Department is null");

        return destination;
    }

    public static StudentEntity GetSampleEntity()
    {
        var entity = new StudentEntity()
        {
            Id = 101,
            Name = "Sample",
            Age = 29,
            Department = "Computer Engineering",
            Grades = new List<decimal>() { 2.36M, 2.72M, 3.06M },
            University = new University() { Name = "Bosphorus University" }
        };

        return entity;
    }
}
