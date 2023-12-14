namespace DtoVsPoco.Domain
{
    public class Person
    {
        public Person(int id)
        {
            Id = id;
        }

        public int Id { get; private init; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? JobTitle { get; set; }

        public string DoWork()
        {
            return $"{JobTitle} doing his work!";
        }

        public bool IsAdult()
        {
            var currentYear = DateTime.Now.Year;
            var age = currentYear - DateOfBirth.Year;

            return age >= 21;
        }
    }
}
