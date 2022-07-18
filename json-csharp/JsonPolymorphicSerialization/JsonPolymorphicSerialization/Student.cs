namespace JsonPolymorphicSerialization
{
    public class Student : Person
    {
        public int RegistrationYear { get; set; }
        public List<string> CoursesTaken { get; set; } = new List<string>();
    }
}
