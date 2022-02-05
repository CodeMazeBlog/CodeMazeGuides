
namespace OperatorOverloading
{
    public class Student
    {
        private int RollNo { get; set; }
        private int Level { get; set; }
        private string Name { get; set; }
        private int Age { get; set; }
        private int NumberOfPassedCourses { get; set; }

        public Student(int rollNo, int level, string name, int age, int passedCourses)
        {
            RollNo = rollNo;
            Level = level;
            Name = name;
            Age = age;
            NumberOfPassedCourses = passedCourses;
        }

        public int GetNumberOfPassedCourses() => NumberOfPassedCourses;

        public string GetName() => Name;

        public static Student operator ++(Student student)
        {
            student.NumberOfPassedCourses++;
            return student;
        }

        public static bool operator <(Student studentLeft, Student studentRight)
        {
            if (studentLeft.Age < studentRight.Age)
                return true;
            else
                return false;
        }

        public static bool operator >(Student studentLeft, Student studentRight)
        {
            if (studentLeft.Age > studentRight.Age)
                return true;
            else
                return false;
        }

        public override bool Equals(object student)
        {
            if (student == null)
                return false;
            if (GetType() != student.GetType())
                return false;

            Student student1 = (Student)student;
            return (RollNo == student1.RollNo) && (Level == student1.Level) && (Age == student1.Age);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(Student studentLeft, Student studentRight)
        {
            if (studentLeft.Equals(studentRight))
                return true;
            else
                return false;
        }

        public static bool operator !=(Student studentLeft, Student studentRight)
        {
            if (studentLeft.Equals(studentRight))
                return false;
            else
                return true;
        }
    }
}
