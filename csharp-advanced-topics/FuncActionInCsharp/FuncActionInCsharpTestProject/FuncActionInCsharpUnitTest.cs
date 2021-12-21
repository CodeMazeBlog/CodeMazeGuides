using FuncActionInCsharp;
using NUnit.Framework;
using System.Linq;

namespace FuncActionInCsharpTestProject
{
    public class FuncActionInCsharpUnitTest
    {
        StudentRegistry registry;

        [SetUp]
        public void Setup()
        {
            registry = new StudentRegistry();
            registry.AddStudent(new Student("John", "Doe", 1997));
            registry.AddStudent(new Student("Jim", "Beam", 2001));
            registry.AddStudent(new Student("Johnny", "Walker", 2000));
            registry.AddStudent(new Student("William", "Lawson", 1999));
        }

        [Test]
        public void WhenFilteringForMilleniumStudents_thenListShouldContain2Entries()
        {
            StudentRegistry newMilleniumStudents = registry.Where((student) => { return (student.YearOfBirth >= 2000); });

            Assert.AreEqual(newMilleniumStudents.Students.Count, 2);
            Assert.That(newMilleniumStudents.Students.Any(st => st.LastName == "Beam"));
            Assert.That(newMilleniumStudents.Students.Any(st => st.LastName == "Walker"));
        }

        public void WhenSendingMessageToAllStudents_thenAllStudentsGetMessageInMessageBox()
        {
            registry.ForEach((student) => { student.MessageBox.Add("hello"); });

            foreach (var student in registry.Students)
            {
                Assert.AreEqual(1, student.MessageBox.Count);
                Assert.Contains("hello", student.MessageBox);
            }
        }

        public void WhenSendingMessageFilteredList_thenAllMilleniumStudentsGetMessageInMessageBox()
        {
            registry
                .Where((student) => { return (student.YearOfBirth < 2000); })
                .ForEach((student) => { student.MessageBox.Add("hello"); });

            foreach (var student in registry.Students)
            {
                Assert.AreEqual(1, student.MessageBox.Count);
                Assert.Contains("hello", student.MessageBox);
            }
        }
    }
}