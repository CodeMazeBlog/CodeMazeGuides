namespace JsonPolymorphicSerialization
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address HomeAddress { get; set; } = new Address();

    }

    public class Student: Person
    {
        public int RegistrationYear { get; set; }
        public List<Course> CoursesTaken { get; set; } = new List<Course>();
    }

    public class Professor: Person
    {
        public string? OfficeNumber { get; set; }
        public List<Course> CoursesOffered { get; set; } = new List<Course>();
    }

    public class Address
    {
        public string? Street { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }

    public class Course
    {
        public string? Name { get; set; }
        public int Semester { get; set; }
    }

}
