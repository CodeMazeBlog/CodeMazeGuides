using NUnit.Framework;
using System;
using System.Linq;
using System.Xml.Linq;
using LINQtoXML;

namespace LINQtoXMLUnitTests
{
    public class Tests2
    {
        XElement UniversityXML;
        string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<University>
  <Students>
    <Student ID=""111"">
      <FirstName>John</FirstName>
      <LastName>Doe</LastName>
      <DateOfBirth>2000-10-2</DateOfBirth>
      <Semester>1</Semester>
      <Major>Computer Science</Major>
      <Courses>
        <Course id=""CS101"">
          <Grade>7.3</Grade>
        </Course>
        <Course id=""CS102"">
          <Grade>6.9</Grade>
        </Course>
      </Courses>
    </Student>
    <Student ID=""222"">
      <FirstName>Jane</FirstName>
      <LastName>Doe</LastName>
      <DateOfBirth>2001-2-22</DateOfBirth>
      <Semester>1</Semester>
      <Major>Electrical Engineering</Major>
      <Courses>
        <Course id=""EE101"">
          <Grade>5.6</Grade>
        </Course>
        <Course id=""EE102"">
          <Grade>8.8</Grade>
        </Course>
      </Courses>
    </Student>
    <Student ID=""333"">
      <FirstName>Jim</FirstName>
      <LastName>Doe</LastName>
      <DateOfBirth>2000-3-12</DateOfBirth>
      <Semester>2</Semester>
      <Major>Computer Science</Major>
      <Courses>
        <Course id=""CS102"">
          <Grade>7.6</Grade>
        </Course>
        <Course id=""CS103"">
          <Grade>8.2</Grade>
        </Course>
      </Courses>
    </Student>
  </Students>
  <Courses>
    <Course id=""CS101"">
      <Title>Intro to programming</Title>
      <Credits>5</Credits>
    </Course>  
    <Course id=""CS102"">
      <Title>Discrete Mathematics</Title>
      <Credits>4</Credits>
    </Course>  
    <Course id=""CS103"">
      <Title>Data structures</Title>
      <Credits>6</Credits>
    </Course>  
    <Course id=""EE101"">
      <Title>Electromagnetism</Title>
      <Credits>5</Credits>
    </Course>  
    <Course id=""EE102"">
      <Title>Electronics</Title>
      <Credits>6</Credits>
    </Course>  
  </Courses>
</University>";

        [SetUp]
        public void Setup()
        {
            UniversityXML = XElement.Parse(xml);
        }

        [Test]
        public void WhenJoiningTwoXMLTrees_WeGetAnonymousObject()
        {
            var students = UniversityXML.Elements("Students").Elements("Student")
                            .Where(student => (string)student.Attribute("ID") == "111")
                            .Select(student => new
                            {
                                Name = (string)student.Element("FirstName") + " " + (string)student.Element("LastName"),
                                Courses = student.Elements("Courses").Elements("Course")
                                            .Join(UniversityXML.Elements("Courses").Elements("Course"),
                                            studentCourse => (string)studentCourse.Attribute("id"),
                                            course => (string)course.Attribute("id"),
                                            (studentCourse, course) => new
                                            {
                                                Id = (string)course.Attribute("id"),
                                                Title = (string)course.Element("Title"),
                                                Grade = (decimal)studentCourse.Element("Grade"),
                                                Credits = (int)course.Element("Credits")
                                            })
                            });

            var expected = new[]
            {
                new
                {
                    Name ="John Doe",
                    Courses = new[]
                    {
                        new
                        {
                            Id = "CS101",
                            Title = "Intro to programming",
                            Grade = 7.3,
                            Credits = 5
                        },
                        new
                        {
                            Id = "CS102",
                            Title = "Discrete Mathematics",
                            Grade = 6.9,
                            Credits = 4
                        }
                    }
                }
            };

            Assert.AreEqual(System.Text.Json.JsonSerializer.Serialize(expected), System.Text.Json.JsonSerializer.Serialize(students));
        }

        [Test]
        public void WhenJoiningTwoXMLTreesWithQuerySyntax_WeGetAnonymousObject()
        {
            var students = from student in UniversityXML.Elements("Students").Elements("Student")
                           where (string)student.Attribute("ID") == "111"
                           select new
                           {
                               Name = (string)student.Element("FirstName") + " " + (string)student.Element("LastName"),
                               Courses =
                               (
                                   from studentCourses in student.Elements("Courses").Elements("Course")
                                   join course in UniversityXML.Elements("Courses").Elements("Course")
                                   on (string)(studentCourses.Attribute("id")) equals (string)course.Attribute("id")
                                   select new
                                   {
                                       Id = (string)course.Attribute("id"),
                                       Title = (string)course.Element("Title"),
                                       Grade = (decimal)studentCourses.Element("Grade"),
                                       Credits = (int)course.Element("Credits")
                                   }
                               )
                           };

            var expected = new[]
            {
                new
                {
                    Name ="John Doe",
                    Courses = new[]
                    {
                        new
                        {
                            Id = "CS101",
                            Title = "Intro to programming",
                            Grade = 7.3,
                            Credits = 5
                        },
                        new
                        {
                            Id = "CS102",
                            Title = "Discrete Mathematics",
                            Grade = 6.9,
                            Credits = 4
                        }
                    }
                }
            };

            Assert.AreEqual(System.Text.Json.JsonSerializer.Serialize(expected), System.Text.Json.JsonSerializer.Serialize(students));
        }

        [Test]
        public void WhenJoiningTwoXMLTrees_WeGetStudentClass()
        {
            var students = UniversityXML.Elements("Students").Elements("Student")
                            .Where(student => (string)student.Attribute("ID") == "111")
                            .Select(student => new Student()
                            {
                                Name = (string)student.Element("FirstName") + " " + (string)student.Element("LastName"),
                                Courses = student.Elements("Courses").Elements("Course")
                                    .Join(UniversityXML.Elements("Courses").Elements("Course"),
                                        studentCourse => (string)studentCourse.Attribute("id"),
                                        course => (string)course.Attribute("id"),
                                        (studentCourse, course) => new Course()
                                        {
                                            Id = (string)course.Attribute("id"),
                                            Title = (string)course.Element("Title"),
                                            Grade = (decimal)studentCourse.Element("Grade"),
                                            Credits = (int)course.Element("Credits")
                                        })
                            });

            var expected = new[]
            {
                new Student()
                {
                    Name ="John Doe",
                    Courses = new Course[]
                    {
                        new Course()
                        {
                            Id = "CS101",
                            Title = "Intro to programming",
                            Grade = 7.3M,
                            Credits = 5
                        },
                        new Course()
                        {
                            Id = "CS102",
                            Title = "Discrete Mathematics",
                            Grade = 6.9M,
                            Credits = 4
                        }
                    }
                }
            };

            Assert.AreEqual(System.Text.Json.JsonSerializer.Serialize(expected), System.Text.Json.JsonSerializer.Serialize(students));
        }

        [Test]
        public void WhenJoiningTwoXMLTrees_WeGetXElementObject()
        {
            var expected = @"<Students>
  <Student>
    <Name>John Doe</Name>
    <Courses>
      <Course Id=""CS101"">
        <Title>Intro to programming</Title>
        <Grade>7.3</Grade>
        <Credits>5</Credits>
      </Course>
      <Course Id=""CS102"">
        <Title>Discrete Mathematics</Title>
        <Grade>6.9</Grade>
        <Credits>4</Credits>
      </Course>
    </Courses>
  </Student>
</Students>";

            var newElement = new XElement("Students",
                                    UniversityXML.Elements("Students").Elements("Student")
                                        .Where(student => (string)student.Attribute("ID") == "111")
                                        .Select(student => new XElement("Student",
                                            new XElement("Name", (string)student.Element("FirstName") + " " + (string)student.Element("LastName")),
                                            new XElement("Courses", student.Elements("Courses").Elements("Course")
                                                .Join(UniversityXML.Elements("Courses").Elements("Course"),
                                                        studentCourse => (string)studentCourse.Attribute("id"),
                                                        course => (string)course.Attribute("id"),
                                                        (studentCourse, course) => new XElement("Course",
                                                            new XAttribute("Id", (string)course.Attribute("id")),
                                                            new XElement("Title", (string)course.Element("Title")),
                                                            new XElement("Grade", (decimal)studentCourse.Element("Grade")),
                                                            new XElement("Credits", (int)course.Element("Credits"))
                                                        )
                                                )
                                            )
                                        ))
                                   );

            Assert.AreEqual(expected, newElement.ToString());
        }

        [Test]
        public void WhenJoiningTwoXMLTrees_WeGetSumAndCount()
        {
            var students = UniversityXML.Elements("Students").Elements("Student")
                           .Select(student => new
                           {
                               Name = (string)student.Element("FirstName") + " " + (string)student.Element("LastName"),
                               TotalCredits = student.Elements("Courses").Elements("Course")
                                    .Join(UniversityXML.Elements("Courses").Elements("Course"),
                                        studentCourse => (string)studentCourse.Attribute("id"),
                                        course => (string)course.Attribute("id"),
                                        (studentCourse, course) => (int)course.Element("Credits")
                                    )
                                    .Sum(),
                               CoursesCount = student.Elements("Courses").Elements("Course")
                                    .Join(UniversityXML.Elements("Courses").Elements("Course"),
                                        studentCourse => (string)studentCourse.Attribute("id"),
                                        course => (string)course.Attribute("id"),
                                        (studentCourse, course) => (string)course.Attribute("id")
                                    )
                                    .Count()
                           });


            var expected = new[]
            {
                new
                {
                    Name ="John Doe",
                    TotalCredits = 9,
                    CoursesCount = 2
                },
                new
                {
                    Name ="Jane Doe",
                    TotalCredits = 11,
                    CoursesCount = 2
                },
                new
                {
                    Name ="Jim Doe",
                    TotalCredits = 10,
                    CoursesCount = 2
                }
            };

            Assert.AreEqual(System.Text.Json.JsonSerializer.Serialize(expected), System.Text.Json.JsonSerializer.Serialize(students));
        }

        [Test]
        public void WhenGroupingResults_WeGetStudentsBySemester()
        {
            var students = new XElement("Semesters",
                                UniversityXML.Elements("Students").Elements("Student")
                                .GroupBy(student => (int)student.Element("Semester"))
                                .Select(group => new XElement("Semester",
                                    new XAttribute("Id", (int)group.Key),
                                    group.Select(s =>
                                        new XElement("Student",
                                            new XElement("FirstName", (string)s.Element("FirstName")),
                                            new XElement("LastName", (string)s.Element("LastName"))
                                        )
                                    )
                                )));


            var expected = @"<Semesters>
  <Semester Id=""1"">
    <Student>
      <FirstName>John</FirstName>
      <LastName>Doe</LastName>
    </Student>
    <Student>
      <FirstName>Jane</FirstName>
      <LastName>Doe</LastName>
    </Student>
  </Semester>
  <Semester Id=""2"">
    <Student>
      <FirstName>Jim</FirstName>
      <LastName>Doe</LastName>
    </Student>
  </Semester>
</Semesters>";

            Assert.AreEqual(expected, students.ToString());
        }


    }
}