namespace GetFirstRecordInEachGroup;

public class Student
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int BirthYear { get; set; }
    public string Class { get; set; } = string.Empty;

    public override bool Equals(object? obj)
    {
        var student = obj as Student;
        
        if(student == null) return false;

        return student.FirstName.Equals(FirstName) &&
            student.LastName.Equals(LastName) &&
            student.BirthYear.Equals(BirthYear);
    }
}
