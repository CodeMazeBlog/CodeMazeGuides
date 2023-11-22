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
        var student = new CollegeStudent();
        student.Id = 1;
        student.Name = "John Doe";
        student.DateOfBirth = new DateTime(1994, 12, 31);
        Console.WriteLine("The student details using a non-static class: " + student.StudentDetails());
    }
   
}
