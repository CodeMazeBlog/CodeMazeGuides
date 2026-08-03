using NUnit.Framework;
using System;
using System.Linq;
using System.Xml.Linq;

namespace LINQtoXMLUnitTests
{
    public class SimpleFunctionalityUnitTests
    {
        XElement StudentsXML;

        [SetUp]
        public void Setup()
        {
            StudentsXML = XElement.Load("./Students.xml");
        }

        [Test]
        public void WhenUsingQuerySyntax_ThenWeGetAllStudents()
        {
            var students = 
                from student in StudentsXML.Elements("Student")
                select student.Element("FirstName").Value + " " + student.Element("LastName").Value;

            var expected = new string[] { "John Doe", "Jane Doe", "Jim Doe" };
            CollectionAssert.AreEqual(expected, students.ToArray());
        }

        [Test]
        public void WhenUsingMethodSyntax_ThenWeGetAllStudents()
        {
            var students = StudentsXML.Elements("Student")
                .Select(student => student.Element("FirstName").Value + " " + student.Element("LastName").Value);

            var expected = new string[] { "John Doe", "Jane Doe", "Jim Doe" };
            CollectionAssert.AreEqual(expected, students.ToArray());
        }

        [Test]
        public void WhenCastingElementsToString_ThenWeGetAllStudents()
        {
            var students = StudentsXML.Elements("Student")
                .Select(student => (string)student.Element("FirstName") + " " + (string)student.Element("LastName"));

            var expected = new string[] { "John Doe", "Jane Doe", "Jim Doe" };
            CollectionAssert.AreEqual(expected, students.ToArray());
        }

        [Test]
        public void WhenFilteringForDate_ThenWeGetStudentsFrom2000()
        {
            var students = StudentsXML.Elements("Student")
                .Where(student => ((DateTime)student.Element("DateOfBirth")).Year == 2000)
                .Select(student => (string)student.Element("FirstName")
                    + " " + (string)student.Element("LastName")
                    + " (" + ((DateTime)student.Element("DateOfBirth")).ToShortDateString() + ")");

            Assert.AreEqual(2, students.Count());
            Assert.IsTrue(students.ElementAt(0).StartsWith("John Doe"));
            Assert.IsTrue(students.ElementAt(1).StartsWith("Jim Doe"));
        }

        [Test]
        public void WhenFilteringForId_ThenWeGetStudentWithId222()
        {
            var student = StudentsXML.Elements("Student")
                .Where(student => (int)student.Attribute("ID") == 222)
                .FirstOrDefault();

            Assert.AreEqual(student.Attribute("ID").Value, "222");
        }

        [Test]
        public void WhenFilteringForClassId_ThenWeGetTwoStudents()
        {
            var students = StudentsXML.Elements("Student")
                .Where(student => student.Elements("Courses").Elements("Course")
                    .Any(course => (string)course.Attribute("ID") == "CS103"));

            Assert.AreEqual(2, students.Count());
            Assert.AreEqual("111", students.ElementAt(0).Attribute("ID").Value);
            Assert.AreEqual("333", students.ElementAt(1).Attribute("ID").Value);
        }

        [Test]
        public void WhenUpdatingStudentName_ThenWeGetCorrectStudent()
        {
            var student = StudentsXML.Elements("Student")
                .Where(student => (int)student.Attribute("ID") == 333)
                .FirstOrDefault();

            student.Element("FirstName").Value = "Jimmy";

            Assert.AreEqual(student.Attribute("ID").Value, "333");
        }

        [Test]
        public void WhenUpdatingMajor_ThenWeGetUpdatedStudent()
        {
            var students = StudentsXML.Elements("Student")
                .Where(student => (int)student.Element("Semester") == 2
                    && (string)student.Element("Major") == "Computer Science");

            foreach (var student in students)
            {
                student.Element("Courses").Add(new XElement("Course", new XAttribute("ID", "CS204"), new XElement("Grade")));
            }

            Assert.AreEqual("111", students.ElementAt(0).Attribute("ID").Value);
            Assert.AreEqual(3, students.ElementAt(0).Element("Courses").Elements("Course").Count());
            Assert.AreEqual("333", students.ElementAt(1).Attribute("ID").Value);
            Assert.AreEqual(3, students.ElementAt(1).Element("Courses").Elements("Course").Count());
        }

        [Test]
        public void WhenDeletingStudent_ThenWeGetCorrectRemainingStudent()
        {
            StudentsXML.Elements("Student")
                .Where(student => (int)student.Attribute("ID") == 333)
                .Remove();

            var students = StudentsXML.Elements("Student");

            Assert.AreEqual("111", students.ElementAt(0).Attribute("ID").Value);
            Assert.AreEqual("222", students.ElementAt(1).Attribute("ID").Value);
        }

        [Test]
        public void WhenCreatingNewStudent_ThenWeGetOneStudent()
        {
            XElement students =
                new XElement("Students",
                    new XElement("Student",
                        new XAttribute("ID", "111"),
                        new XElement("FirstName", "John"),
                        new XElement("LastName", "Doe"),
                        new XElement("DateOfBirth", "2000-10-2"),
                        new XElement("Semester", "2"),
                        new XElement("Major", "Computer Science"),
                        new XElement("Courses",
                            new XElement("Course",
                                new XAttribute("ID", "CS103"),
                                new XElement("Grade", "7.3")
                            ),
                            new XElement("Course",
                                new XAttribute("ID", "CS202"),
                                new XElement("Grade", "6.9")
                            )
                        )
                    )
                );

            Assert.AreEqual(1, students.Elements("Student").Count());
        }

        [Test]
        public void WhenCreatingNewStudentWithDefaultNamespace_ThenWeGetOneStudent()
        {
            XNamespace st = "http://www.testuni.edu/def";
            XElement students =
                new XElement(st + "Students",
                    new XElement(st + "Student",
                        new XAttribute("ID", "111"),
                        new XElement(st + "FirstName", "John"),
                        new XElement(st + "LastName", "Doe"),
                        new XElement(st + "DateOfBirth", "2000-10-2"),
                        new XElement(st + "Semester", "2"),
                        new XElement(st + "Major", "Computer Science"),
                        new XElement(st + "Courses",
                            new XElement(st + "Course",
                                new XAttribute("ID", "CS103"),
                                new XElement(st + "Grade", "7.3")
                            ),
                            new XElement(st + "Course",
                                new XAttribute("ID", "CS202"),
                                new XElement(st + "Grade", "6.9")
                            )
                        )
                    )
                );

            Assert.AreEqual(1, students.Elements(st + "Student").Count());
        }

        [Test]
        public void WhenCreatingNewStudentWithPrefixedNamespace_ThenWeGetOneStudent()
        {
            XNamespace st = "http://www.testuni.edu/def";
            XElement students =
                new XElement(st + "Students",
                    new XAttribute(XNamespace.Xmlns + "st", "http://www.testuni.edu/def"),
                    new XElement(st + "Student",
                        new XAttribute("ID", "111"),
                        new XElement(st + "FirstName", "John"),
                        new XElement(st + "LastName", "Doe"),
                        new XElement(st + "DateOfBirth", "2000-10-2"),
                        new XElement(st + "Semester", "2"),
                        new XElement(st + "Major", "Computer Science"),
                        new XElement(st + "Courses",
                            new XElement(st + "Course",
                                new XAttribute("ID", "CS103"),
                                new XElement(st + "Grade", "7.3")
                            ),
                            new XElement(st + "Course",
                                new XAttribute("ID", "CS202"),
                                new XElement(st + "Grade", "6.9")
                            )
                        )
                    )
                );

            Assert.AreEqual(1, students.Elements(st + "Student").Count());
        }
    }
}