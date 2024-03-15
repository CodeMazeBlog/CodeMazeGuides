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

            var enrolments = EnrolmentHelper.GetEnrolments(
                Enrolment.GetDummyEnrolment()
            );

            EnrolmentHelper.PrintEnrolments(enrolments);

            var filteredEnrolments = EnrolmentHelper.FilterEnrolments(
                Enrolment.GetDummyEnrolment()
            );

            EnrolmentHelper.PrintEnrolments(filteredEnrolments);

            var filteredAndGroupedEnrolments = EnrolmentHelper.FilterAndGroupEnrolments(
                Enrolment.GetDummyEnrolment()
            );

            EnrolmentHelper.PrintEnrolmentsGroup(filteredAndGroupedEnrolments);

            Console.ReadKey();
        }
    }
}
