namespace ActionAndFuncDelegates
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float CGPA { get; set; }
    }

    public class StudentEligibility
    {
        public Func<Student, bool> StudentFunc { get; set; }

        public StudentEligibility()
        {
            StudentFunc = (Student student) =>
            {
                return student.CGPA >= 8;
            };
        }
    }
}
