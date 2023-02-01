using Bogus;

namespace LinqInnerJoin
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
    
        public static IEnumerable<Student> GetDummyStudents()
        {
           IEnumerable<Student> students = new Faker<Student>()
                                            .RuleFor(x => x.Id, f => f.IndexFaker+1)
                                            .RuleFor(x => x.Name, f => f.Person.FirstName)
                                            .RuleFor(x => x.IsActive, f => f.PickRandomParam(new bool[] { true, true, false }))
                                            .RuleFor(x => x.Age, f => f.PickRandomParam(new int[] { 20, 22, 25, 30, 40, 45, 23, 29, 32, 55, 31, 47 }))
                                            .Generate(10);
    
            return students;
    
        }
    }
}
