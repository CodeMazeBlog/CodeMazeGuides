using Microsoft.AspNetCore.Mvc;
using Moq;
using GettingStartedASPNETMongoDB.Controllers;
using GettingStartedASPNETMongoDB.Interfaces;
using GettingStartedASPNETMongoDB.Models;

namespace Test
{
    public class StudentControllerUnitTest
    {
        const string id = "123456789054354";

        private Mock<IStudentService> _studentService;

        private Mock<ICourseService> _courseService;

        private StudentsController _studentController;

        private Student _student;

        public StudentControllerUnitTest()
        {            
            SetUp();
        }

        [Fact]
        public async Task GivenCreate_WhenSentCorrectData_ThenReturnCreatedStatus()
        {  
            //Act
            var result = await _studentController.Create(_student);

            //Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task GivenGetById_WhenSentCorrectId_ThenReturnStudentWithOkStatus()
        {
            //Act
            var result = await _studentController.GetById(id);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.IsType<Student>(okResult.Value);            
        }

        [Fact]
        public async Task GivenGetAll_WhenSentCorrectId_ThenReturnStudentsWithOKStatus()
        {  
            //Arrange
            var students = new List<Student> 
            { 
                new Student 
                { 
                    Id = "1", 
                    FirstName = "John", 
                    LastName = "Doe" 
                }, 
                new Student 
                { 
                    Id = "2", 
                    FirstName = "Jane", 
                    LastName = "Doe" 
                } 
            };            

            _studentService.Setup(x => x.GetAll()).ReturnsAsync(students);

            _studentController = new StudentsController(_studentService.Object, _courseService.Object);

            //Act
            var result = await _studentController.GetAll();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var model = Assert.IsAssignableFrom<IEnumerable<Student>>(okResult.Value);

            Assert.Equal(students.Count, model.Count());
            Assert.Equal(students, model);
        }

        [Fact]
        public async Task GivenUpdateStudent_WhenSentWithCorrectId_ThenReturnNoContent()
        {
            //Act
            var result = await _studentController.Update(id, _student);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GivenDelete_WhenSentCorrectId_ThenReturnNoContent()
        {
            //Act
            var result = await _studentController.Delete(id);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        private void SetUp()
        {    
            _student = new()
            {
                Id = id,
                FirstName = "Mary",
                LastName = "Que"
            };

            //Services
            _studentService = new Mock<IStudentService>();

            _courseService = new Mock<ICourseService>();

            _studentService.Setup(x => x.Create(_student)).ReturnsAsync(_student);

            _studentService.Setup(x => x.GetById(id)).ReturnsAsync(_student);

            _studentService.Setup(x => x.Delete(id)).Returns(Task.CompletedTask);

            _studentService.Setup(x => x.Update(id, _student)).Returns(Task.CompletedTask);

            //Controller
            _studentController = new StudentsController(_studentService.Object, _courseService.Object);
        }
    }
}