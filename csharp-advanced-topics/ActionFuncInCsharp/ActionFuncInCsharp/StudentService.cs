namespace ActionFuncInCsharp
{
    public static class StudentService
    {
        public static Student GetStudent(
          IEnumerable<Student> students,
          Func<Student, bool> predicate)
        {
            foreach (var student in students)
            {
                if (predicate(student))
                {
                    return student;
                }
            }

            return default!;
        }

        public static void EnrollStudentToCourse(
                Student student,
                Course course,
                Action<Student> notify)
        {
            student.Courses.Add(course);

            notify(student);
        }
    }
}
