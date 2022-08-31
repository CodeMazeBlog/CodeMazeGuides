namespace NullReference
{
    public class Teacher
    {
        public string? LastName { get; set; }

        public Teacher()
        {
        }

        public Teacher[] AddRange(String[] lastNames)
        {
            var teachers = new Teacher[lastNames.Length];

            for (int i = 0; i < lastNames.Length; i++)
                teachers[i] = new Teacher(lastNames[i]);

            return teachers;
        }

        public Teacher(String lastName)
        {
            this.LastName = lastName;
        }
    }
}
