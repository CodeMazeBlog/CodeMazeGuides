namespace NullReference
{
    public class Teacher
    {
        public string? FirstName { get; set; }

        public Teacher()
        {
        }

        public Teacher[] AddRange(string[] firstNames)
        {
            var teachers = new Teacher[firstNames.Length];

            for (int i = 0; i < firstNames.Length; i++) 
            {
                teachers[i] = new Teacher(firstNames[i]);
            }
                
            return teachers;
        }

        public Teacher(string firstName)
        {
            this.FirstName = firstName;
        }
    }
}
