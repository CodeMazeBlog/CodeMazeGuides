namespace UsingMariaDBWithASP.NETCoreWebAPI.CodeFirstModels
{
    public class Student
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? Address { get; set; }

        public virtual ICollection<Course>? Courses { get; set; }
    }
}