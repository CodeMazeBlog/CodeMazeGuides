using AutoMapper;

namespace AutoMapperIgnoreNullValues;

public class AutoMapperManager
{
    private const string DepartmentIsNullMessage = "Department is null";

    public static StudentEntity UpdateStudent(StudentItemDto source)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<DefaultMappingProfile>();
        });

        IMapper mapper = config.CreateMapper();
        var destination = GetSampleEntity();
        destination = mapper.Map(source, destination);

        if (destination.Department == null)
            throw new Exception(DepartmentIsNullMessage);

        return destination;
    }

    public static StudentEntity UpdateStudentIgnoreNullValues(StudentItemDto source)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<IgnoreNullMappingProfile>();
        });

        IMapper mapper = config.CreateMapper();
        var destination = GetSampleEntity();
        destination = mapper.Map(source, destination);

        if (destination.Department == null)
            throw new Exception(DepartmentIsNullMessage);

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
