using NUnit.Framework;
using System;
using System.Linq;
using System.Xml.Linq;
using LINQtoXML;

namespace LINQtoXMLUnitTests
{
    public class AdvancedFunctionalityUnitTests
    {
        XElement UniversityXML;

        [SetUp]
        public void Setup()
        {
            UniversityXML = XElement.Load("University.xml");
        }

        [Test]
        public void WhenJoiningTwoXMLTrees_ThenWeGetAnonymousObject()
        {
            var students = UniversityXML.Elements("Students").Elements("Student")
                .Where(student => (string)student.Attribute("ID") == "111")
                .Select(student => new
                {
                    Name = (string)student.Element("FirstName") + " " + (string)student.Element("LastName"),
                    Courses = student.Elements("Courses").Elements("Course")
                        .Join(UniversityXML.Elements("Courses").Elements("Course"),
                            studentCourse => (string)studentCourse.Attribute("ID"),
                            course => (string)course.Attribute("ID"),
                            (studentCourse, course) => new
                            {
                                Id = (string)course.Attribute("ID"),
                                Title = (string)course.Element("Title"),
                                Grade = (decimal)studentCourse.Element("Grade"),
                                Credits = (int)course.Element("Credits")
                            })
                });

            Assert.AreEqual("John Doe", students.ElementAt(0).Name);
            Assert.IsTrue(students.GetType().Name.Contains("WhereSelectEnumerableIterator"));
        }

        [Test]
        public void WhenJoiningTwoXMLTreesWithQuerySyntax_ThenWeGetAnonymousObject()
        {
            var students = 
                from student in UniversityXML.Elements("Students").Elements("Student")
                where (string)student.Attribute("ID") == "111"
                select new
                {
                    Name = (string)student.Element("FirstName") + " " + (string)student.Element("LastName"),
                    Courses =
                    (
                        from studentCourses in student.Elements("Courses").Elements("Course")
                        join course in UniversityXML.Elements("Courses").Elements("Course")
                        on (string)(studentCourses.Attribute("ID")) equals (string)course.Attribute("ID")
                        select new
                        {
                            Id = (string)course.Attribute("ID"),
                            Title = (string)course.Element("Title"),
                            Grade = (decimal)studentCourses.Element("Grade"),
                            Credits = (int)course.Element("Credits")
                        }
                    )
                };

            Assert.AreEqual("John Doe", students.ElementAt(0).Name);
            Assert.IsTrue(students.GetType().Name.Contains("WhereSelectEnumerableIterator"));
        }

        [Test]
        public void WhenJoiningTwoXMLTrees_ThenWeGetStudentClass()
        {
            var students = UniversityXML.Elements("Students").Elements("Student")
                .Where(student => (string)student.Attribute("ID") == "111")
                .Select(student => new Student()
                {
                    Name = (string)student.Element("FirstName") + " " + (string)student.Element("LastName"),
                    Courses = student.Elements("Courses").Elements("Course")
                        .Join(UniversityXML.Elements("Courses").Elements("Course"),
                            studentCourse => (string)studentCourse.Attribute("ID"),
                            course => (string)course.Attribute("ID"),
                            (studentCourse, course) => new Course()
                            {
                                Id = (string)course.Attribute("ID"),
                                Title = (string)course.Element("Title"),
                                Grade = (decimal)studentCourse.Element("Grade"),
                                Credits = (int)course.Element("Credits")
                            })
                });

            Assert.AreEqual("John Doe", students.ElementAt(0).Name);
            Assert.AreEqual("Student", students.ElementAt(0).GetType().Name);
        }

        [Test]
        public void WhenJoiningTwoXMLTrees_ThenWeGetXElementObject()
        {
            var newElement = 
                new XElement("Students",
                    UniversityXML.Elements("Students").Elements("Student")
                        .Where(student => (string)student.Attribute("ID") == "111")
                        .Select(student => new XElement("Student",
                            new XElement("Name", (string)student.Element("FirstName") + " " + (string)student.Element("LastName")),
                            new XElement("Courses", student.Elements("Courses").Elements("Course")
                                .Join(UniversityXML.Elements("Courses").Elements("Course"),
                                        studentCourse => (string)studentCourse.Attribute("ID"),
                                        course => (string)course.Attribute("ID"),
                                        (studentCourse, course) => new XElement("Course",
                                            new XAttribute("ID", (string)course.Attribute("ID")),
                                            new XElement("Title", (string)course.Element("Title")),
                                            new XElement("Grade", (decimal)studentCourse.Element("Grade")),
                                            new XElement("Credits", (int)course.Element("Credits"))
                                        )
                                )
                            )
                        ))
                    );

            Assert.AreEqual("XElement", newElement.GetType().Name);
            Assert.AreEqual(1, newElement.Elements("Student").Count());
            Assert.AreEqual("John Doe", newElement.Elements("Student").ElementAt(0).Element("Name").Value);
        }

        [Test]
        public void WhenJoiningTwoXMLTrees_ThenWeGetSumAndCount()
        {
            var students = UniversityXML.Elements("Students").Elements("Student")
                .Select(student => new
                {
                    Name = (string)student.Element("FirstName") + " " + (string)student.Element("LastName"),
                    TotalCredits = student.Elements("Courses").Elements("Course")
                        .Join(UniversityXML.Elements("Courses").Elements("Course"),
                            studentCourse => (string)studentCourse.Attribute("ID"),
                            course => (string)course.Attribute("ID"),
                            (studentCourse, course) => (int)course.Element("Credits")
                        )
                        .Sum(),
                    CoursesCount = student.Elements("Courses").Elements("Course")
                        .Join(UniversityXML.Elements("Courses").Elements("Course"),
                            studentCourse => (string)studentCourse.Attribute("ID"),
                            course => (string)course.Attribute("ID"),
                            (studentCourse, course) => (string)course.Attribute("ID")
                        )
                        .Count()
                });

            Assert.AreEqual(3, students.Count());
            Assert.AreEqual("John Doe", students.ElementAt(0).Name);
            Assert.AreEqual(9, students.ElementAt(0).TotalCredits);
            Assert.AreEqual(2, students.ElementAt(0).CoursesCount);
            Assert.IsTrue(students.GetType().Name.Contains("SelectEnumerableIterator"));
        }

        [Test]
        public void WhenGroupingResults_ThenWeGetStudentsBySemester()
        {
            var students = 
                new XElement("Semesters",
                    UniversityXML.Elements("Students").Elements("Student")
                        .GroupBy(student => (int)student.Element("Semester"))
                        .Select(group => new XElement("Semester",
                            new XAttribute("ID", (int)group.Key),
                            group.Select(s =>
                                new XElement("Student",
                                    new XElement("FirstName", (string)s.Element("FirstName")),
                                    new XElement("LastName", (string)s.Element("LastName"))
                                )
                            )
                        )));

            Assert.AreEqual(2, students.Elements("Semester").Count());
            Assert.AreEqual("1", students.Elements("Semester").ElementAt(0).Attribute("ID").Value);
            Assert.AreEqual("2", students.Elements("Semester").ElementAt(1).Attribute("ID").Value);
        }
    }
}