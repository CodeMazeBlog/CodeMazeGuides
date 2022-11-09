namespace ExecuteStoredProceduresInEFCore.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Mark { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
