namespace JsonPolymorphicSerialization
{
    public class Student : Person
    {
        public int RegistrationYear { get; set; }
        public List<Course> CoursesTaken { get; set; } = new List<Course>();
    }
}
