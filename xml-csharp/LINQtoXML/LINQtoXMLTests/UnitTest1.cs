using NUnit.Framework;
using System;
using System.Linq;
using System.Xml.Linq;

namespace LINQtoXMLUnitTests
{
    public class Tests1
    {
        XElement StudentsXML;
        string xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Students>
 <Student ID = ""111"">
   <FirstName>John</FirstName>
   <LastName>Doe</LastName>
   <DateOfBirth>2000 - 10 - 2</DateOfBirth>
   <Semester>2</Semester>
   <Major>Computer Science</Major>
   <Courses>
     <Course id = ""CS103"">
       <Grade>7.3</Grade>
     </Course>
     <Course id=""CS202"">
       <Grade>6.9</Grade>
     </Course>
   </Courses>
 </Student>
 <Student ID = ""222"">
   <FirstName>Jane</FirstName>
   <LastName>Doe</LastName>
   <DateOfBirth>2001 - 2 - 22</DateOfBirth>
   <Semester>1</Semester>
   <Major>Electrical Engineering</Major>
   <Courses>
     <Course id = ""EE111"">
       <Grade>5.6</Grade>
     </Course>
     <Course id=""EE303"">
       <Grade>8.8</Grade>
     </Course>
   </Courses>
 </Student>
 <Student ID = ""333"">
   <FirstName>Jim</FirstName>
   <LastName>Doe</LastName>
   <DateOfBirth>2000 - 3 - 12</DateOfBirth>
   <Semester>2</Semester>
   <Major>Computer Science</Major>
   <Courses>
     <Course id = ""CS103"">
       <Grade>7.6</Grade>
     </Course>
     <Course id=""CS202"">
       <Grade>8.2</Grade>
     </Course>
   </Courses>
 </Student>
</Students>";

        [SetUp]
        public void Setup()
        {
            StudentsXML = XElement.Parse(xml);
        }

        [Test]
        public void WhenUsingQuerySyntax_WeGetAllStudents()
        {
            var students = from student in StudentsXML.Elements("Student")
                           select student.Element("FirstName").Value + " " + student.Element("LastName").Value;

            var expected = new string[] { "John Doe", "Jane Doe", "Jim Doe" };
            Assert.AreEqual(expected, students.ToArray());
        }

        [Test]
        public void WhenUsingMethodSyntax_WeGetAllStudents()
        {
            var students = StudentsXML.Elements("Student")
                .Select(student => student.Element("FirstName").Value + " " + student.Element("LastName").Value);

            var expected = new string[] { "John Doe", "Jane Doe", "Jim Doe" };
            Assert.AreEqual(expected, students.ToArray());
        }

        [Test]
        public void WhenCastingElementsToString_WeGetAllStudents()
        {
            var students = StudentsXML.Elements("Student")
                            .Select(student => (string)student.Element("FirstName") + " " + (string)student.Element("LastName"));

            var expected = new string[] { "John Doe", "Jane Doe", "Jim Doe" };
            Assert.AreEqual(expected, students.ToArray());
        }

        [Test]
        public void WhenFilteringForDate_WeGetStudentsFrom2000()
        {
            var students = StudentsXML.Elements("Student")
                            .Where(student => ((DateTime)student.Element("DateOfBirth")).Year == 2000)
                            .Select(student => (string)student.Element("FirstName")
                                                    + " " + (string)student.Element("LastName")
                                                    + " (" + ((DateTime)student.Element("DateOfBirth")).ToShortDateString() + ")");

            var expected = new string[] { "John Doe (10/2/2000)", "Jim Doe (3/12/2000)" };
            Assert.AreEqual(expected, students.ToArray());
        }

        [Test]
        public void WhenFilteringForId_WeGetStudentWithId222()
        {
            var expected = @"<Student ID=""222"">
  <FirstName>Jane</FirstName>
  <LastName>Doe</LastName>
  <DateOfBirth>2001 - 2 - 22</DateOfBirth>
  <Semester>1</Semester>
  <Major>Electrical Engineering</Major>
  <Courses>
    <Course id=""EE111"">
      <Grade>5.6</Grade>
    </Course>
    <Course id=""EE303"">
      <Grade>8.8</Grade>
    </Course>
  </Courses>
</Student>";
            var student = StudentsXML.Elements("Student")
                            .Where(student => (int)student.Attribute("ID") == 222)
                            .FirstOrDefault();

            Assert.AreEqual(expected, student.ToString());
        }

        [Test]
        public void WhenFilteringForClassId_WeGetTwoStudents()
        {
            var expected1 = @"<Student ID=""111"">
  <FirstName>John</FirstName>
  <LastName>Doe</LastName>
  <DateOfBirth>2000 - 10 - 2</DateOfBirth>
  <Semester>2</Semester>
  <Major>Computer Science</Major>
  <Courses>
    <Course id=""CS103"">
      <Grade>7.3</Grade>
    </Course>
    <Course id=""CS202"">
      <Grade>6.9</Grade>
    </Course>
  </Courses>
</Student>";

            var expected2 = @"<Student ID=""333"">
  <FirstName>Jim</FirstName>
  <LastName>Doe</LastName>
  <DateOfBirth>2000 - 3 - 12</DateOfBirth>
  <Semester>2</Semester>
  <Major>Computer Science</Major>
  <Courses>
    <Course id=""CS103"">
      <Grade>7.6</Grade>
    </Course>
    <Course id=""CS202"">
      <Grade>8.2</Grade>
    </Course>
  </Courses>
</Student>";

            var students = StudentsXML.Elements("Student")
                            .Where(student => student.Elements("Courses").Elements("Course")
                                                    .Any(course => (string)course.Attribute("id") == "CS103"));

            Assert.AreEqual(expected1, students.ElementAt(0).ToString());
            Assert.AreEqual(expected2, students.ElementAt(1).ToString());
        }

        [Test]
        public void WhenFilteringForClassIdWithQuerySyntax_WeGetTwoStudents()
        {
            var expected1 = @"<Student ID=""111"">
  <FirstName>John</FirstName>
  <LastName>Doe</LastName>
  <DateOfBirth>2000 - 10 - 2</DateOfBirth>
  <Semester>2</Semester>
  <Major>Computer Science</Major>
  <Courses>
    <Course id=""CS103"">
      <Grade>7.3</Grade>
    </Course>
    <Course id=""CS202"">
      <Grade>6.9</Grade>
    </Course>
  </Courses>
</Student>";

            var expected2 = @"<Student ID=""333"">
  <FirstName>Jim</FirstName>
  <LastName>Doe</LastName>
  <DateOfBirth>2000 - 3 - 12</DateOfBirth>
  <Semester>2</Semester>
  <Major>Computer Science</Major>
  <Courses>
    <Course id=""CS103"">
      <Grade>7.6</Grade>
    </Course>
    <Course id=""CS202"">
      <Grade>8.2</Grade>
    </Course>
  </Courses>
</Student>";

            var students = from student in StudentsXML.Elements("Student")
                           where
                           (
                               from course in student.Elements("Courses").Elements("Course")
                               where (string)course.Attribute("id") == "CS103"
                               select course
                           )
                           .Any()
                           select student;

            Assert.AreEqual(expected1, students.ElementAt(0).ToString());
            Assert.AreEqual(expected2, students.ElementAt(1).ToString());
        }

        [Test]
        public void WhenUpdatingStudentName_WeGetCorrectStudent()
        {
            var expected = @"<Student ID=""333"">
  <FirstName>Jimmy</FirstName>
  <LastName>Doe</LastName>
  <DateOfBirth>2000 - 3 - 12</DateOfBirth>
  <Semester>2</Semester>
  <Major>Computer Science</Major>
  <Courses>
    <Course id=""CS103"">
      <Grade>7.6</Grade>
    </Course>
    <Course id=""CS202"">
      <Grade>8.2</Grade>
    </Course>
  </Courses>
</Student>";
            var student = StudentsXML.Elements("Student")
                            .Where(student => (int)student.Attribute("ID") == 333)
                            .FirstOrDefault();

            student.Element("FirstName").Value = "Jimmy";

            Assert.AreEqual(expected, student.ToString());
        }

        [Test]
        public void WhenUpdatingMajor_WeGetCorrectStudent()
        {
            var expected1 = @"<Student ID=""111"">
  <FirstName>John</FirstName>
  <LastName>Doe</LastName>
  <DateOfBirth>2000 - 10 - 2</DateOfBirth>
  <Semester>2</Semester>
  <Major>Computer Science</Major>
  <Courses>
    <Course id=""CS103"">
      <Grade>7.3</Grade>
    </Course>
    <Course id=""CS202"">
      <Grade>6.9</Grade>
    </Course>
    <Course id=""CS204"">
      <Grade />
    </Course>
  </Courses>
</Student>";

            var expected2 = @"<Student ID=""333"">
  <FirstName>Jim</FirstName>
  <LastName>Doe</LastName>
  <DateOfBirth>2000 - 3 - 12</DateOfBirth>
  <Semester>2</Semester>
  <Major>Computer Science</Major>
  <Courses>
    <Course id=""CS103"">
      <Grade>7.6</Grade>
    </Course>
    <Course id=""CS202"">
      <Grade>8.2</Grade>
    </Course>
    <Course id=""CS204"">
      <Grade />
    </Course>
  </Courses>
</Student>";

            var students = StudentsXML.Elements("Student")
                            .Where(student => (int)student.Element("Semester") == 2
                                    && (string)student.Element("Major") == "Computer Science");

            foreach (var item in students)
            {
                item.Element("Courses").Add(new XElement("Course", new XAttribute("id", "CS204"), new XElement("Grade")));
            }

            Assert.AreEqual(expected1, students.ElementAt(0).ToString());
            Assert.AreEqual(expected2, students.ElementAt(1).ToString());
        }

        [Test]
        public void WhenDeletingStudent_WeGetCorrectRemainingStudent()
        {
            string expected = @"<Students>
  <Student ID=""111"">
    <FirstName>John</FirstName>
    <LastName>Doe</LastName>
    <DateOfBirth>2000 - 10 - 2</DateOfBirth>
    <Semester>2</Semester>
    <Major>Computer Science</Major>
    <Courses>
      <Course id=""CS103"">
        <Grade>7.3</Grade>
      </Course>
      <Course id=""CS202"">
        <Grade>6.9</Grade>
      </Course>
    </Courses>
  </Student>
  <Student ID=""222"">
    <FirstName>Jane</FirstName>
    <LastName>Doe</LastName>
    <DateOfBirth>2001 - 2 - 22</DateOfBirth>
    <Semester>1</Semester>
    <Major>Electrical Engineering</Major>
    <Courses>
      <Course id=""EE111"">
        <Grade>5.6</Grade>
      </Course>
      <Course id=""EE303"">
        <Grade>8.8</Grade>
      </Course>
    </Courses>
  </Student>
</Students>";

            StudentsXML.Elements("Student")
                        .Where(student => (int)student.Attribute("ID") == 333)
                        .Remove();


            Assert.AreEqual(expected, StudentsXML.ToString());
        }

        [Test]
        public void WhenCreatingNewStudent_WeGetCorrectStudent()
        {
            string expected = @"<Students>
  <Student ID=""111"">
    <FirstName>John</FirstName>
    <LastName>Doe</LastName>
    <DateOfBirth>2000-10-2</DateOfBirth>
    <Semester>2</Semester>
    <Major>Computer Science</Major>
    <Courses>
      <Course id=""CS103"">
        <Grade>7.3</Grade>
      </Course>
      <Course id=""CS202"">
        <Grade>6.9</Grade>
      </Course>
    </Courses>
  </Student>
</Students>";

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
                                new XAttribute("id", "CS103"),
                                new XElement("Grade", "7.3")
                            ),
                            new XElement("Course",
                                new XAttribute("id", "CS202"),
                                new XElement("Grade", "6.9")
                            )
                        )
                    )
                );

            Assert.AreEqual(expected, students.ToString());
        }

        [Test]
        public void WhenCreatingNewStudentWithDefaultNamespace_WeGetCorrectStudent()
        {
            string expected = @"<Students xmlns=""http://www.testuni.edu/def"">
  <Student ID=""111"">
    <FirstName>John</FirstName>
    <LastName>Doe</LastName>
    <DateOfBirth>2000-10-2</DateOfBirth>
    <Semester>2</Semester>
    <Major>Computer Science</Major>
    <Courses>
      <Course id=""CS103"">
        <Grade>7.3</Grade>
      </Course>
      <Course id=""CS202"">
        <Grade>6.9</Grade>
      </Course>
    </Courses>
  </Student>
</Students>";

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
                                new XAttribute("id", "CS103"),
                                new XElement(st + "Grade", "7.3")
                            ),
                            new XElement(st + "Course",
                                new XAttribute("id", "CS202"),
                                new XElement(st + "Grade", "6.9")
                            )
                        )
                    )
                );

            Assert.AreEqual(expected, students.ToString());
        }

        [Test]
        public void WhenCreatingNewStudentWithPrefixedNamespace_WeGetCorrectStudent()
        {
            string expected = @"<st:Students xmlns:st=""http://www.testuni.edu/def"">
  <st:Student ID=""111"">
    <st:FirstName>John</st:FirstName>
    <st:LastName>Doe</st:LastName>
    <st:DateOfBirth>2000-10-2</st:DateOfBirth>
    <st:Semester>2</st:Semester>
    <st:Major>Computer Science</st:Major>
    <st:Courses>
      <st:Course id=""CS103"">
        <st:Grade>7.3</st:Grade>
      </st:Course>
      <st:Course id=""CS202"">
        <st:Grade>6.9</st:Grade>
      </st:Course>
    </st:Courses>
  </st:Student>
</st:Students>";

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
                                new XAttribute("id", "CS103"),
                                new XElement(st + "Grade", "7.3")
                            ),
                            new XElement(st + "Course",
                                new XAttribute("id", "CS202"),
                                new XElement(st + "Grade", "6.9")
                            )
                        )
                    )
                );

            Assert.AreEqual(expected, students.ToString());
        }
    }
}