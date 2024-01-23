namespace WriteXML
{
    public record Person(
        string FirstName,
        string LastName,
        string Email,
        DateTime Birthday)
    {
        public int Age
        {
            get
            {
                var age = DateTime.Today.Year - Birthday.Year;
                if (Birthday > DateTime.Today.AddYears(-age)) age--;

                return age;
            }
        }
    }
}
