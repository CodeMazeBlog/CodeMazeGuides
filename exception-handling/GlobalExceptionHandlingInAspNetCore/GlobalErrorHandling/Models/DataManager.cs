namespace GlobalErrorHandling.Models;

public static class DataManager
{
    public static List<Student> GetAllStudents() =>
    [
        new(1, "John Doe"),
        new(2, "Jane Smith"),
        new(3, "Mike Johnson")
    ];
}
