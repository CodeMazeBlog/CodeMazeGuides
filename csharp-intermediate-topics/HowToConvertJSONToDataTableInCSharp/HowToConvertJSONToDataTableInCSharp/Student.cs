namespace HowToConvertJSONToDataTableInCSharp
{
    public class Student
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int BirthYear { get; set; }
        public string[] Subjects { get; set; } = Array.Empty<string>();
    }
}