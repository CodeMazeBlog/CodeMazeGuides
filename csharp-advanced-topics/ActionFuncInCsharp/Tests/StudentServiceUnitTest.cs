using ActionFuncInCsharp;
using Xunit;

namespace Tests
{
    public class StudentServiceUnitTest
    {
        private readonly IEnumerable<Student> _students;
        private readonly IEnumerable<Course> _courses;

        private static bool isAdminNotified = false;
        private static bool isAccountNotified = false;
        Action<Student> sendNotifications;
        public StudentServiceUnitTest()
        {
            _students = Student.DummyStudents();
            _courses = Course.DummyeCourses();
            sendNotifications = NotifyAdmin;
            sendNotifications += NotifyAccount;
        }

        [Theory]
        [MemberData(nameof(StudentsMatchingFilters))]
        public void WhenFilterMatchAStudent_ThenReturnThatStudent(Func<Student, bool> filter)
        {
            var student = StudentService.GetStudent(_students, filter);

            Assert.NotNull(student);
        }

        [Theory]
        [MemberData(nameof(StudentsNonMatchingFilters))]
        public void WhenFilterMatchNoStudent_ThenReturnDefault(Func<Student, bool> filter)
        {
            var student = StudentService.GetStudent(_students, filter);

            Assert.Null(student);
        }

        [Theory, MemberData(nameof(StudentCoursesMatchingFilters))]
        public void WhenStudentGetsEnrolled_ThenStudentGetsAssignedNewCourse((Func<Student, bool>, Func<IEnumerable<Course>, Course> ) studentCourseFilters)
        {
            var student = StudentService.GetStudent(_students, studentCourseFilters.Item1);
            var course = studentCourseFilters.Item2(_courses);

            StudentService.EnrollStudentToCourse(student, course, sendNotifications);

            Assert.Equal(student.Courses.Last(), course);
        }

        [Theory, MemberData(nameof(StudentCoursesMatchingFilters))]
        public void WhenStudentGetsEnrolled_ThenNotifyDepartments((Func<Student, bool>, Func<IEnumerable<Course>, Course>) studentCourseFilters)
        {
            isAdminNotified = false;
            isAccountNotified = false;

            var student = StudentService.GetStudent(_students, studentCourseFilters.Item1);
            var course = studentCourseFilters.Item2(_courses);

            StudentService.EnrollStudentToCourse(student, course, sendNotifications);

            Assert.True(isAdminNotified);
            Assert.True(isAccountNotified);
        }

        public static IEnumerable<object[]> StudentsMatchingFilters =>
        new List<object[]>
        {
             new object[] { studentWithId_1 },
             new object[] { studentWithName_Lara },
        };
        
        public static IEnumerable<object[]> StudentsNonMatchingFilters =>
        new List<object[]>
        {
           new object[] { studentWithId_Max },
           new object[] { studentWithName_Abc },
        };
        
        public static IEnumerable<object[]> StudentCoursesMatchingFilters =>
        new List<object[]>
        {
            new object[] { (studentWithId_1, courseWithId_1) },
            new object[] { (studentWithName_Lara, courseWithName_Docker) },
        };
        
        private static void NotifyAdmin(Student student) => isAdminNotified = true;
        
        private static void NotifyAccount(Student student) => isAccountNotified = true;
        
        private static readonly Func<Student, bool> studentWithId_1 = (s) => s.Id == 1;
        private static readonly Func<Student, bool> studentWithName_Lara = (s) => s.Name.Equals("Lara", StringComparison.InvariantCulture);
        
        private static readonly Func<Student, bool> studentWithId_Max = (s) => s.Id == int.MaxValue;
        private static readonly Func<Student, bool> studentWithName_Abc = (s) => s.Name.Equals("Abc", StringComparison.InvariantCulture);
        
        private static readonly Func<IEnumerable<Course>, Course> courseWithId_1 = (c) => c.First(x => x.Id == 1);
        private static readonly Func<IEnumerable<Course>, Course> courseWithName_Docker = (c) => c.First(x => x.Name.Equals("docker", StringComparison.InvariantCultureIgnoreCase));

    }
}