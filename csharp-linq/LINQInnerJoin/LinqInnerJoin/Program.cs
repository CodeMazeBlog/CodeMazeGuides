using LinqInnerJoin;

Console.WriteLine("-----the courses-----");
EnrolmentHelper.PrintDummyCourses();

Console.WriteLine("-----the categories-----");
EnrolmentHelper.PrintDummyCategories();

Console.WriteLine("-----query syntax-----");
var coursesWithCategory = EnrolmentHelper.GetCoursesWithCategory(
    Course.GetDummyCourses());
EnrolmentHelper.PrintCoursesWithCategory(coursesWithCategory);

Console.WriteLine("-----method syntax-----");
var coursesWithCategoryName = EnrolmentHelper.GetCoursesWithCategoryName(
    Course.GetDummyCourses());
EnrolmentHelper.PrintCoursesWithCategory(coursesWithCategoryName);

Console.WriteLine("-----tuple join-----");
var pairs = EnrolmentHelper.GetCourseCategoryPairs(Course.GetDummyCourses());

foreach (var (course, category) in pairs.Take(3))
{
    Console.WriteLine($"{course.Name} is a {category.Name}");
}

Console.WriteLine("-----enrolments-----");
var enrolments = EnrolmentHelper.GetEnrolments(
    Enrolment.GetDummyEnrolment());
EnrolmentHelper.PrintEnrolments(enrolments);

Console.WriteLine("-----filtered enrolments-----");
var filteredEnrolments = EnrolmentHelper.FilterEnrolments(
    Enrolment.GetDummyEnrolment());
EnrolmentHelper.PrintEnrolments(filteredEnrolments);

Console.WriteLine("-----enrolments with grade-----");
var enrolmentsWithGrade = EnrolmentHelper.GetEnrolmentsWithGrade(
    Enrolment.GetDummyEnrolment());
EnrolmentHelper.PrintEnrolmentsWithGrade(enrolmentsWithGrade);

Console.WriteLine("-----enrolments with grade, method syntax-----");
EnrolmentHelper.PrintEnrolmentsWithGrade(
    EnrolmentHelper.GetEnrolmentsWithGradeMethodSyntax(Enrolment.GetDummyEnrolment()));

Console.WriteLine("-----filtered and grouped-----");
var filteredAndGroupedEnrolments = EnrolmentHelper.FilterAndGroupEnrolments(
    Enrolment.GetDummyEnrolment());
EnrolmentHelper.PrintEnrolmentsGroup(filteredAndGroupedEnrolments);

Console.WriteLine("-----group join-----");
var enrolmentCounts = EnrolmentHelper.GetEnrolmentCountPerCourse(
    Course.GetDummyCourses());
EnrolmentHelper.PrintEnrolmentCountPerCourse(enrolmentCounts);
