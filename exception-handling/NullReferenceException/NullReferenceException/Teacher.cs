namespace NullReference
{
    public class Teacher
    {
        public string? LastName { get; set; }

        public Teacher()
        {
        }

        public Teacher[] AddRange(string[] lastNames)
        {
            var teachers = new Teacher[lastNames.Length];

            for (int i = 0; i < lastNames.Length; i++) 
            {
                teachers[i] = new Teacher(lastNames[i]);
            }
                
            return teachers;
        }

        public Teacher(string lastName)
        {
            this.LastName = lastName;
        }
    }
}
