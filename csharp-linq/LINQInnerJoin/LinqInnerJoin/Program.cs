namespace LinqInnerJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
             //// print dummy courses
            //Console.WriteLine("\n-----the courses-----\n");
            //EnrolmentHelper.PrintDummyCourses();
            //// print dummy categories
            //Console.WriteLine("\n-----the categories-----\n");
            //EnrolmentHelper.PrintDummyCategories();

            //EnrolmentHelper.PrintCoursesWithCategory(EnrolmentHelper.GetCoursesWithCategory(Course.GetDummyCourses()));
            //EnrolmentHelper.PrintCoursesWithCategory(EnrolmentHelper.GetCoursesWithCategoryName(Course.GetDummyCourses()));

            //EnrolmentHelper.PrintEnrollments(EnrolmentHelper.GetEnrollments(Enrolment.GetDummyEnrolment()));
            //EnrolmentHelper.PrintEnrollments(EnrolmentHelper.FilterEnrollments(Enrolment.GetDummyEnrolment()));
            EnrolmentHelper.PrintEnrollmentsGroup(EnrolmentHelper.FilterAndGroupEnrollments(Enrolment.GetDummyEnrolment()));

            Console.ReadKey();

        }
        
    }
}