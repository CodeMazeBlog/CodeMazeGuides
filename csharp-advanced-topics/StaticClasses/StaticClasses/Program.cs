using StaticClasses;

public class Program 
{
    static void Main(string[] args)
    {
        //static class implementation
        //no instantiation needed
        Student.Id = 1;
        Student.Name = "John Doe";
        Student.DateOfBirth = new DateTime(1994, 12, 31);
        Console.WriteLine("The student using a static class: " + Student.StudentDetails());

        //non-static class student implementation 
        //the class has to be instantiated
        CollegeStudent student = new CollegeStudent();
        student.Id = 1;
        student.Name = "John Doe";
        student.DateOfBirth = new DateTime(1994, 12, 31);
        Console.WriteLine("The student details using a non-static class: " + student.StudentDetails());
    }
   
    public static class Student
    {
        //private fields 
        private static string name;

        //static properties
        public static int Id { get; set; }
        public static string Name { get { return name; } set => name = value; }
        public static DateTime DateOfBirth { get; set; }

        //static methods
        //function to return the student's age
        public static int CalculateAge(DateTime DateOfBirth)
        {
            //get today's date 
            DateTime today = DateTime.Today;

            //calculate age
            int age = today.Year - DateOfBirth.Year;

            //Go back to the previous year in case the student was born on a leap year
            if (DateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        //function to return the student's details on the screen
        public static string StudentDetails()
        {
            string studentDetails = string.Empty;
            studentDetails = Name + " " + DateOfBirth + " " + CalculateAge(DateOfBirth);
            return studentDetails;
        }
    }
}
