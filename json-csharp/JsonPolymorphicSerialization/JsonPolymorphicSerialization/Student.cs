namespace JsonPolymorphicSerialization
{
    public class Student : Member
    {
        public int RegistrationYear { get; set; }

        public List<string> Courses { get; set; } = new List<string>();
    }
}
