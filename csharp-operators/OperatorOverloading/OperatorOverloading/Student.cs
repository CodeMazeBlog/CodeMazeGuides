
namespace OperatorOverloading
{
    public class Student
    {
        private readonly int _rollNo;
        private readonly int _level;
        private readonly string _name;
        private readonly int _age;
        private int _numberOfPassedCourses;

        public Student(int rollNo, int level, string name, int age, int passedCourses)
        {
            _rollNo = rollNo;
            _level = level;
            _name = name;
            _age = age;
            _numberOfPassedCourses = passedCourses;
        }

        public int GetNumberOfPassedCourses() => _numberOfPassedCourses;

        public string GetName() => _name;

        public static Student operator ++(Student student)
        {
            student._numberOfPassedCourses++;
            return student;
        }

        public static bool operator <(Student studentLeft, Student studentRight)
        {
            if (studentLeft._age < studentRight._age)
                return true;
            else
                return false;
        }

        public static bool operator >(Student studentLeft, Student studentRight)
        {
            if (studentLeft._age > studentRight._age)
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

            var student1 = (Student)student;
            return (_rollNo == student1._rollNo) && (_level == student1._level) && (_age == student1._age);
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
