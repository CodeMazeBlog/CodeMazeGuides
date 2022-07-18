namespace JsonPolymorphicSerialization
{
    public class Professor : Person
    {
        public string? OfficeNumber { get; set; }
        public List<Course> CoursesOffered { get; set; } = new List<Course>();
    }
}
