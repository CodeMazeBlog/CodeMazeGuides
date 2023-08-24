namespace JsonSerializationWriteToFile;

public record class College(
    string Name, 
    int NoOfStudents, 
    bool IsPublic, 
    List<Teacher>? Teachers = null);

public record class Teacher(
    string Name, 
    int WorkHours, 
    bool InProbation, 
    List<Course>? Courses = null);

public record class Course(
    string Name, 
    int CreditHours, 
    bool IsOptional);