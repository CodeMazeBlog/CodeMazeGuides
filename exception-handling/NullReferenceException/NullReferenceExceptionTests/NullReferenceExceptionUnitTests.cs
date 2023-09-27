using NullReference;

namespace NullReferenceExceptionTests
{
    [TestClass]
    public class NullReferenceExceptionUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GivenAListObject_WhenNotInstantiated_VerifyThrowsNullReferenceException()
        {
            var studentObj = new ExceptionMethods();

            var studentList = studentObj.StudentList();

            Assert.IsNull(studentList);
        }

        [TestMethod]
        public void GivenAListObject_WhenInstantiatedCorrectly_VerifyReturnsListValues()
        {
            var studentObj = new ExceptionMethods();

            var studentList = studentObj.FixedStudentList();
            var student = "John Doe";

            Assert.IsNotNull(studentList);
            Assert.IsInstanceOfType(studentList, typeof(List<string>));
            CollectionAssert.Contains(studentList, student);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GivenAnArray_WhenNotInstantiated_VerifyThrowsNullReferenceException()
        {
            var arrayObj = new ExceptionMethods();

            var randomNumbers = arrayObj.RandomNumbers();

            Assert.IsNull(randomNumbers);
        }

        [TestMethod]
        public void GivenAnArray_WhenInstantiated_VerifyReturnsResults()
        {
            var arrayObj = new ExceptionMethods();

            var randomNumbers = arrayObj.FixedRandomNumbers();

            Assert.IsNotNull(randomNumbers);
            Assert.IsInstanceOfType(randomNumbers, typeof(int[]));   
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GivenAnArray_WhenSearching_VerifyThrowsNullReferenceException()
        {
            var listObj = new ExceptionMethods();

            var searchPerson = listObj.Teachers("Steve");

            Assert.IsNull(searchPerson);
        }

        [TestMethod]
        public void GivenAnArray_WhenSearching_VerifyReturnsString()
        {
            var listObj = new ExceptionMethods();

            var searchPerson = listObj.FixedTeachers("Steve");

            Assert.IsNotNull(searchPerson);
            Assert.IsInstanceOfType(searchPerson, typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GivenAnArray_WhenSomeElementsNull_VerifyThrowsNullReferenceException()
        {
            var arrayObj = new ExceptionMethods();
            
            var capitalizedNames = arrayObj.CapitalizeNames();
            
            Assert.IsNull(capitalizedNames);
        }

        [TestMethod]
        public void GivenAnArray_WhenSomeElementsNull_VerifyReturnsStringArray()
        {
            var arrayObj = new ExceptionMethods();

            var capitalizedNames = arrayObj.FixedCapitalizeNames();

            Assert.IsNotNull(capitalizedNames);
            CollectionAssert.Contains(capitalizedNames, "JOHN");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GivenAMethod_WhenNullArgumentsPassed_VerifyThrowsNullReferenceException()
        {
            var namesObj = new ExceptionMethods();

            List<string> currentPeople = null;
            var peopleList = namesObj.PopulateList(currentPeople);

            Assert.IsNull(peopleList);
        }

        [TestMethod]
        public void GivenAMethod_WhenNullArgumentsPassed_VerifyPopulatesList()
        {
            var namesObj = new ExceptionMethods();

            List<string> currentPeople = null;
            var peopleList = namesObj.FixedPopulateList(currentPeople);

            Assert.IsNotNull(peopleList);
            CollectionAssert.Contains(peopleList, "Mary");
        }
    }
}