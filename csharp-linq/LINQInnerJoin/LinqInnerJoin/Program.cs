namespace LinqInnerJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// print dummy courses
            Console.WriteLine("\n-----the courses-----\n");
            EnrolmentHelper.PrintDummyCourses();
            //// print dummy categories
            Console.WriteLine("\n-----the categories-----\n");
            EnrolmentHelper.PrintDummyCategories();

            var coursesWithCategory = EnrolmentHelper.GetCoursesWithCategory(
                Course.GetDummyCourses()
            );

            EnrolmentHelper.PrintCoursesWithCategory(coursesWithCategory);

            var coursesWithCategoryName = EnrolmentHelper.GetCoursesWithCategoryName(
                Course.GetDummyCourses()
            );

            EnrolmentHelper.PrintCoursesWithCategory(coursesWithCategoryName);

            var enrollments = EnrolmentHelper.GetEnrolments(
                Enrolment.GetDummyEnrolment()
            );

            EnrolmentHelper.PrintEnrollments(enrollments);

            var filteredEnrollments = EnrolmentHelper.FilterEnrolments(
                Enrolment.GetDummyEnrolment()
            );

            EnrolmentHelper.PrintEnrollments(filteredEnrollments);

            var filteredAndGroupedEnrollments = EnrolmentHelper.FilterAndGroupEnrolments(
                Enrolment.GetDummyEnrolment()
            );

            EnrolmentHelper.PrintEnrollmentsGroup(filteredAndGroupedEnrollments);

            Console.ReadKey();
        }
    }
}
