namespace JsonPolymorphicSerialization
{
    public class Professor : Person
    {
        public string? OfficeNumber { get; set; }
        public List<string> CoursesOffered { get; set; } = new List<string>();
    }
}
