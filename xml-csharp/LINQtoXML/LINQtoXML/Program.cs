using System;
using System.Linq;
using System.Xml.Linq;

namespace LINQtoXML
{
    class Program
    {
        public void MethodSyntax()
        {
            var studentsXML = XElement.Load("Students.xml");
            var students = studentsXML.Elements("Student")
                .Select(student => student.Element("FirstName").Value + " " + student.Element("LastName").Value);

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void QuerySyntax()
        {
            var studentsXML = XElement.Load("Students.xml");
            var students = 
                from student in studentsXML.Elements("Student")
                select student.Element("FirstName").Value + " " + student.Element("LastName").Value;

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        static void Main(string[] args)
        {
            var program = new Program();
            Console.WriteLine("Method Syntax");
            program.MethodSyntax();
            Console.WriteLine("Query Syntax");
            program.QuerySyntax();
        }
    }
}
