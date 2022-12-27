namespace ActionFuncInCsharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // fetch students and courses
            var students = Student.DummyStudents();
            var courses = Course.DummyeCourses();

            // get student with id: 1
            var student1 = StudentService.GetStudent(students, (s) => s.Id == 1);
            Print<Student>(student1, (s) => Console.WriteLine($"Id: {s.Id}  Name: {s.Name}"));

            // get student with name: Rahul
            var studentRahul = StudentService.GetStudent(students, (s) => s.Name.Equals("Rahul"));
            Print<Student>(student1, (s) => Console.WriteLine($"Id: {s.Id}  Name: {s.Name}"));

            // create an Action<Student> variable and assign a method
            Action<Student> sendNotifications = NotifyAdmin;
            // add another method to the sendNotifications
            sendNotifications += NotifyAccount;

            // call EnrollStudentToCourse passing student, course and sendNotifications
            StudentService.EnrollStudentToCourse(studentRahul, courses.First(x => x.Id == 1), sendNotifications);

            Console.ReadLine();
        }

        public static void Print<T>(T arg, Action<T> printAction)
        {
            Console.WriteLine("Let's look at the output..");

            printAction(arg);
        }

        public static void NotifyAdmin(Student student)
        {
            Console.WriteLine($"{student.Name} is now enrolled in {student.Courses.Last().Name.ToUpper()} course");
        }

        public static void NotifyAccount(Student student)
        {
            var course = student.Courses.Last();
            var amount = course.Price;

            Console.WriteLine($"Please deduct amount: {amount} dollars from {student.Name}");
        }
    }
}