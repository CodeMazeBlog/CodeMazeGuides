namespace LinqInnerJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PrintEnrollments(GetEnrollments(Enrolment.GetDummyEnrolment()));
            //PrintEnrollments(FilterEnrollments(Enrolment.GetDummyEnrolment()));
            //PrintEnrollmentsGroup(FilterAndGroupEnrollments(Enrolment.GetDummyEnrolment()));

            //// print dummy courses
            //Console.WriteLine("\n-----the courses-----\n");
            //PrintDummyCourses();
            //// print dummy categories
            //Console.WriteLine("\n-----the categories-----\n");
            //PrintDummyCategories();

            //PrintCoursesWithCategory(GetCoursesWithCategory(Course.GetDummyCourses()));
            //PrintCoursesWithCategory(GetCoursesWithCategoryName(Course.GetDummyCourses()));
            Console.ReadKey();

        }

        public static IEnumerable<dynamic> GetEnrollments(IEnumerable<Enrolment> enrollments)
        {
            var students = Student.GetDummyStudents();
            var courses = Course.GetDummyCourses();

            var enrollements = enrollments  //Enrolment data source
                                            // First Join - Joining Student with Enrolment
                .Join(
                  students,
                  enrolment_lv1 => enrolment_lv1.StudentId,
                  student => student.Id,
                  (enrolment_lv1, student) => new { enrolment_lv1, student }   // result from first join
                 )
               // Second Join - Joining Course with the result of first join 
               .Join(
                  courses,
                  enrolment_lv2 => enrolment_lv2.enrolment_lv1.CourseId,
                  course => course.Id,
                  (enrolment_lv2, course) => new { enrolment_lv2, course }  // result fromn second join
                )
               // Selecting result from the selection of two joins
               .Select(e => new
               {
                   Id = e.enrolment_lv2.enrolment_lv1.Id,
                   StudentName = e.enrolment_lv2.student.Name,
                   CourseName = e.course.Name,
               });

            return enrollements;
        }

        public static IEnumerable<dynamic> FilterEnrollments(IEnumerable<Enrolment> enrollments)
        {
            var students = Student.GetDummyStudents();
            var courses = Course.GetDummyCourses();

            var enrollements = enrollments  //Enrolment data source
                                            // First Join - Joining Student with Enrolment
                .Join(
                  students,
                  enrolment_lv1 => enrolment_lv1.StudentId,
                  student => student.Id,
                  (enrolment_lv1, student) => new { enrolment_lv1, student }   // result from first join
                 )
               // Second Join - Joining Course with the result of first join 
               .Join(
                  courses,
                  enrolment_lv2 => enrolment_lv2.enrolment_lv1.CourseId,
                  course => course.Id,
                  (enrolment_lv2, course) => new { enrolment_lv2, course }  // result fromn second join
                )
               // Selecting result from the selection of two joins
               .Select(e => new
               {
                   Id = e.enrolment_lv2.enrolment_lv1.Id,
                   StudentName = e.enrolment_lv2.student.Name,
                   CourseId = e.course.Id,
                   CourseName = e.course.Name,
               })
               .Where(x => x.CourseId == 1);

            return enrollements;
        }

        public static IEnumerable<dynamic> FilterAndGroupEnrollments(IEnumerable<Enrolment> enrollments)
        {
            var students = Student.GetDummyStudents();
            var courses = Course.GetDummyCourses();

            var enrollements = enrollments  //Enrolment data source
                                            // First Join - Joining Student with Enrolment
                .Join(
                  students,
                  enrolment_lv1 => enrolment_lv1.StudentId,
                  student => student.Id,
                  (enrolment_lv1, student) => new { enrolment_lv1, student }   // result from first join
                 )
               // Second Join - Joining Course with the result of first join 
               .Join(
                  courses,
                  enrolment_lv2 => enrolment_lv2.enrolment_lv1.CourseId,
                  course => course.Id,
                  (enrolment_lv2, course) => new { enrolment_lv2, course }  // result fromn second join
                )
               // Selecting result from the selection of two joins
               .Select(e => new
               {
                   Id = e.enrolment_lv2.enrolment_lv1.Id,
                   StudentName = e.enrolment_lv2.student.Name,
                   CourseId = e.course.Id,
                   CourseName = e.course.Name,
               })
               .Where(x => x.CourseId < 5) // filter on course id
               .GroupBy(x => x.CourseId);  // group on course id

            return enrollements;
        }

        public static IEnumerable<dynamic> GetCoursesWithCategory(IEnumerable<Course> courses)
        {
            var catrgories = Category.GetDummyCourseCategories();

            var courseWithCategory = from course in courses  // outer sequence
                                     join category in catrgories // inner sequence
                                     on course.CategoryId equals category.Id //  key selector
                                     select new  // anonymous object to return
                                     {
                                         Id = course.Id,
                                         Name = course.Name,
                                         CategoryName = category.Name
                                     };

            return courseWithCategory;
        }

        public static IEnumerable<dynamic> GetCoursesWithCategoryName(IEnumerable<Course> courses)
        {
            var categories = Category.GetDummyCourseCategories();

            var courseWithCategoryName = courses.Join(   // outer sequence
                                          categories,     // inner sequence
                                          course => course.CategoryId, // outer sequence key selector
                                          category => category.Id,     // inner sequence key selector
                                          (course, category) => new     // // anonymous object to return
                                          {
                                              Id = course.Id,
                                              Name = course.Name,
                                              CategoryName = category.Name
                                          });

            return courseWithCategoryName;
        }

        private static void PrintCoursesWithCategory(IEnumerable<dynamic> courses)
        {
            foreach (var course in courses)
            {
                Console.WriteLine($"Id: {course.Id} Course: {course.Name}  Category: {course.CategoryName}");
            }
        }

        private static void PrintDummyCourses()
        {
            foreach (var course in Course.GetDummyCourses())
            {
                Console.WriteLine($"Id: {course.Id} Course: {course.Name}  CategoryId: {course.CategoryId} ");
            }
        }

        private static void PrintDummyCategories()
        {
            foreach (var category in Category.GetDummyCourseCategories())
            {
                Console.WriteLine($"Id: {category.Id} Category: {category.Name}");
            }
        }

        private static void PrintEnrollments(IEnumerable<dynamic> enrollments)
        {
            foreach (var enrolment in enrollments)
            {
                Console.WriteLine($"Id: {enrolment.Id}, Student Name: {enrolment.StudentName}, Course: {enrolment.CourseName} \n");
            }
        }

        private static void PrintEnrollmentsGroup(IEnumerable<dynamic> enrollmentGroups)
        {
            foreach (var group in enrollmentGroups)
            {
                Console.WriteLine($"Enrollements for Course Id: {group.Key} \n");
                foreach (var enrolment in group)
                {
                    Console.WriteLine($"Id: {enrolment.Id}, Student Name: {enrolment.StudentName}, Course: {enrolment.CourseName} \n");
                }
            }
        }
    }
}