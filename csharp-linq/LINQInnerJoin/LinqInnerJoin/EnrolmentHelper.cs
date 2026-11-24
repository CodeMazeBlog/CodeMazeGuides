namespace LinqInnerJoin;

public static class EnrolmentHelper
{
    public static IEnumerable<dynamic> GetEnrolments(
        IEnumerable<Enrolment> enrolments)
    {
        var students = Student.GetDummyStudents();

        var courses = Course.GetDummyCourses();

        var enrolmentsRelation = GetEnrolmentsRelation(
            enrolments,
            students,
            courses);

        var result = enrolmentsRelation.Select(
            e =>
                new
                {
                    e.enrolmentStudentRelation.enrolment.Id,
                    StudentName = e.enrolmentStudentRelation.student.Name,
                    CourseName = e.course.Name,
                }
        );

        return result;
    }

    public static IEnumerable<dynamic> FilterEnrolments(IEnumerable<Enrolment> enrolments)
    {
        var students = Student.GetDummyStudents();

        var courses = Course.GetDummyCourses();

        var enrolmentsRelation = GetEnrolmentsRelation(enrolments, students, courses);

        var result = enrolmentsRelation
            .Select(
                e =>
                    new
                    {
                        e.enrolmentStudentRelation.enrolment.Id,
                        StudentName = e.enrolmentStudentRelation.student.Name,
                        CourseId = e.course.Id,
                        CourseName = e.course.Name,
                    }
            )
            .Where(x => x.CourseId == 1);

        return result;
    }

    public static IEnumerable<IGrouping<dynamic, dynamic>> FilterAndGroupEnrolments(
        IEnumerable<Enrolment> enrolments)
    {
        var students = Student.GetDummyStudents();

        var courses = Course.GetDummyCourses();

        var enrolmentsRelation = GetEnrolmentsRelation(
            enrolments,
            students,
            courses);

        var result = enrolmentsRelation
            .Select(
                e =>
                    new
                    {
                        e.enrolmentStudentRelation.enrolment.Id,
                        StudentName = e.enrolmentStudentRelation.student.Name,
                        CourseId = e.course.Id,
                        CourseName = e.course.Name,
                    }
            )
            .Where(x => x.CourseId < 5)
            .GroupBy(x => x.CourseId);

        return result;
    }

    public static IEnumerable<dynamic> GetCoursesWithCategory(
        IEnumerable<Course> courses)
    {
        var categories = Category.GetDummyCourseCategories();

        var courseWithCategory =
            from course in courses
            join category in categories on
            course.CategoryId equals category.Id
            select new
            {
                course.Id,
                course.Name,
                CategoryName = category.Name
            };

        return courseWithCategory;
    }

    public static IEnumerable<dynamic> GetCoursesWithCategoryName(
        IEnumerable<Course> courses)
    {
        var categories = Category.GetDummyCourseCategories();

        var courseWithCategoryName = courses.Join(
            categories,
            course => course.CategoryId,
            category => category.Id,
            (course, category) => new
            {
                course.Id,
                course.Name,
                CategoryName = category.Name
            }
        );

        return courseWithCategoryName;
    }

    public static IEnumerable<(Course Outer, Category Inner)> GetCourseCategoryPairs(
        IEnumerable<Course> courses)
    {
        var categories = Category.GetDummyCourseCategories();

        return courses.Join(
            categories,
            course => course.CategoryId,
            category => category.Id);
    }

    public static IEnumerable<dynamic> GetEnrolmentsWithGrade(
        IEnumerable<Enrolment> enrolments)
    {
        var grades = Grade.GetDummyGrades();

        var enrolmentsWithGrade =
            from enrolment in enrolments
            join grade in grades on
            new { enrolment.StudentId, enrolment.CourseId }
            equals new { grade.StudentId, grade.CourseId }
            select new
            {
                enrolment.Id,
                enrolment.StudentId,
                enrolment.CourseId,
                grade.Mark
            };

        return enrolmentsWithGrade;
    }

    public static IEnumerable<dynamic> GetEnrolmentsWithGradeMethodSyntax(
        IEnumerable<Enrolment> enrolments)
    {
        var grades = Grade.GetDummyGrades();

        return enrolments.Join(
            grades,
            enrolment => new { enrolment.StudentId, enrolment.CourseId },
            grade => new { grade.StudentId, grade.CourseId },
            (enrolment, grade) => new
            {
                enrolment.Id,
                enrolment.StudentId,
                enrolment.CourseId,
                grade.Mark
            });
    }

    public static IEnumerable<dynamic> GetEnrolmentCountPerCourse(
        IEnumerable<Course> courses)
    {
        var enrolments = Enrolment.GetDummyEnrolment();

        return courses.GroupJoin(
            enrolments,
            course => course.Id,
            enrolment => enrolment.CourseId,
            (course, courseEnrolments) => new
            {
                course.Name,
                EnrolmentCount = courseEnrolments.Count()
            });
    }

    public static void PrintCoursesWithCategory(IEnumerable<dynamic> courses)
    {
        foreach (var course in courses)
        {
            Console.WriteLine(
                $"Id: {course.Id} " +
                $"Course: {course.Name} " +
                $"Category: {course.CategoryName}"
            );
        }
    }

    public static void PrintDummyCourses()
    {
        foreach (var course in Course.GetDummyCourses())
        {
            Console.WriteLine(
                $"Id: {course.Id} " +
                $"Course: {course.Name} " +
                $"CategoryId: {course.CategoryId}"
            );
        }
    }

    public static void PrintDummyCategories()
    {
        foreach (var category in Category.GetDummyCourseCategories())
        {
            Console.WriteLine(
                $"Id: {category.Id} " +
                $"Category: {category.Name}");
        }
    }

    public static void PrintEnrolments(IEnumerable<dynamic> enrolments)
    {
        foreach (var enrolment in enrolments)
        {
            Console.WriteLine(
                $"Id: {enrolment.Id}, " +
                $"Student Name: {enrolment.StudentName}, " +
                $"Course: {enrolment.CourseName}"
            );
        }
    }

    public static void PrintEnrolmentsGroup(
        IEnumerable<IGrouping<dynamic, dynamic>> enrolmentGroups)
    {
        foreach (var group in enrolmentGroups)
        {
            Console.WriteLine($"Enrolments for Course Id: {group.Key}");

            foreach (var enrolment in group)
            {
                Console.WriteLine(
                    $"Id: {enrolment.Id}, " +
                    $"Student Name: {enrolment.StudentName}, " +
                    $"Course: {enrolment.CourseName}"
                );
            }
        }
    }

    public static void PrintEnrolmentsWithGrade(IEnumerable<dynamic> enrolments)
    {
        foreach (var enrolment in enrolments)
        {
            Console.WriteLine(
                $"Enrolment: {enrolment.Id}, " +
                $"StudentId: {enrolment.StudentId}, " +
                $"CourseId: {enrolment.CourseId}, " +
                $"Mark: {enrolment.Mark}"
            );
        }
    }

    public static void PrintEnrolmentCountPerCourse(IEnumerable<dynamic> courses)
    {
        foreach (var course in courses)
        {
            Console.WriteLine($"{course.Name}: {course.EnrolmentCount}");
        }
    }

    private static IEnumerable<dynamic> GetEnrolmentsRelation(
        IEnumerable<Enrolment> enrolments,
        IEnumerable<Student> students,
        IEnumerable<Course> courses)
    {
        return enrolments
            .Join(
                students,
                enrolment => enrolment.StudentId,
                student => student.Id,
                (enrolment, student) => new { enrolment, student }
            )
            .Join(
                courses,
                enrolmentStudentRelation =>
                enrolmentStudentRelation.enrolment.CourseId,
                course => course.Id,
                (enrolmentStudentRelation, course) =>
                new { enrolmentStudentRelation, course }
            );
    }
}
