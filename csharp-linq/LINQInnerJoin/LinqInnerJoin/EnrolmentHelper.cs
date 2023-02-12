namespace LinqInnerJoin
{
    public static class EnrolmentHelper
    {
        public static IEnumerable<dynamic> GetEnrolments(IEnumerable<Enrolment> enrolments)
        {
            var students = Student.GetDummyStudents();

            var courses = Course.GetDummyCourses();

            var enrolmensRelation = GetEnrolmentsRelation(enrolments, students, courses);

            var result = enrolmensRelation
                             .Select(e => new
                             {
                                 e.enrolmentLevel2.enrolmentLevel1.Id,
                                 StudentName = e.enrolmentLevel2.student.Name,
                                 CourseName = e.course.Name,
                             });

            return result;

        }

        public static IEnumerable<dynamic> FilterEnrolments(IEnumerable<Enrolment> enrolments)
        {
            var students = Student.GetDummyStudents();

            var courses = Course.GetDummyCourses();

            var enrolmensRelation = GetEnrolmentsRelation(enrolments, students, courses);

            var result = enrolmensRelation
                             .Select(e => new
                             {
                                 e.enrolmentLevel2.enrolmentLevel1.Id,
                                 StudentName = e.enrolmentLevel2.student.Name,
                                 CourseId = e.course.Id,
                                 CourseName = e.course.Name,
                             })
                             .Where(x => x.CourseId == 1);

            return result;

        }

        public static IEnumerable<dynamic> FilterAndGroupEnrolments(IEnumerable<Enrolment> enrolments)
        {
            var students = Student.GetDummyStudents();

            var courses = Course.GetDummyCourses();

            var enrolmensRelation = GetEnrolmentsRelation(enrolments, students, courses);

            var result = enrolmensRelation
                            .Select(e => new
                            {
                                e.enrolmentLevel2.enrolmentLevel1.Id,
                                StudentName = e.enrolmentLevel2.student.Name,
                                CourseId = e.course.Id,
                                CourseName = e.course.Name,
                            })
                            .Where(x => x.CourseId < 5)
                            .GroupBy(x => x.CourseId);

            return result;
        }

        public static IEnumerable<dynamic> GetCoursesWithCategory(IEnumerable<Course> courses)
        {
            var catrgories = Category.GetDummyCourseCategories();

            var courseWithCategory = from course in courses
                                     join category in catrgories
                                     on course.CategoryId equals category.Id
                                     select new
                                     {
                                         course.Id,
                                         course.Name,
                                         CategoryName = category.Name
                                     };

            return courseWithCategory;
        }

        public static IEnumerable<dynamic> GetCoursesWithCategoryName(IEnumerable<Course> courses)
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
                                         });

            return courseWithCategoryName;
        }

        public static void PrintCoursesWithCategory(IEnumerable<dynamic> courses)
        {
            foreach (var course in courses)
            {
                Console.WriteLine($"Id: {course.Id} Course: {course.Name}  Category: {course.CategoryName}");
            }
        }

        public static void PrintDummyCourses()
        {
            foreach (var course in Course.GetDummyCourses())
            {
                Console.WriteLine($"Id: {course.Id} Course: {course.Name}  CategoryId: {course.CategoryId} ");
            }
        }

        public static void PrintDummyCategories()
        {
            foreach (var category in Category.GetDummyCourseCategories())
            {
                Console.WriteLine($"Id: {category.Id} Category: {category.Name}");
            }
        }

        public static void PrintEnrolments(IEnumerable<dynamic> enrolments)
        {
            foreach (var enrolment in enrolments)
            {
                Console.WriteLine($"Id: {enrolment.Id}, Student Name: {enrolment.StudentName}, Course: {enrolment.CourseName} \n");
            }
        }

        public static void PrintEnrolmentsGroup(IEnumerable<dynamic> enrolmentGroups)
        {
            foreach (var group in enrolmentGroups)
            {
                Console.WriteLine($"Enrolments for Course Id: {group.Key} \n");
                foreach (var enrolment in group)
                {
                    Console.WriteLine($"Id: {enrolment.Id}, Student Name: {enrolment.StudentName}, Course: {enrolment.CourseName} \n");
                }
            }
        }

        private static IEnumerable<dynamic> GetEnrolmentsRelation(IEnumerable<Enrolment> enrolments, IEnumerable<Student> students, IEnumerable<Course> courses)
        {
            return enrolments
                                        .Join(
                                           students,
                                           enrolmentLevel1 => enrolmentLevel1.StudentId,
                                           student => student.Id,
                                           (enrolmentLevel1, student) => new { enrolmentLevel1, student })
                                        .Join(
                                           courses,
                                           enrolmentLevel2 => enrolmentLevel2.enrolmentLevel1.CourseId,
                                           course => course.Id,
                                           (enrolmentLevel2, course) => new { enrolmentLevel2, course });
        }
    }

}
