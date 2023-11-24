namespace Lucene.NetBasicExample
{
    public class Person
    {
        public string? GUID { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Description { get; set; }

        public Person(string guid, string fname, string mname, string lname, string description)
        {
            GUID = guid;
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
            Description = description;
        }
    }
}
