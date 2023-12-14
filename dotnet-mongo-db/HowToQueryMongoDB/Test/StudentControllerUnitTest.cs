using HowToQueryMongoDB.Controllers;
using HowToQueryMongoDB.Interfaces;
using HowToQueryMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Moq;

namespace Test;

public class StudentControllerUnitTest
{
    const string id = "123456789054354";

    private Mock<IStudentService> _studentService;

    private Mock<ICourseService> _courseService;

    private StudentsController _studentController;

    private Student _student;

    public StudentControllerUnitTest()
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

        _studentService.Setup(x => x.GetByIdUsingBuilder(id)).ReturnsAsync(_student);

        _studentService.Setup(x => x.Delete(id)).Verifiable();

        _studentService.Setup(x => x.Update(id, _student)).Verifiable();

        //Controller
        _studentController = new StudentsController(_studentService.Object, _courseService.Object);
    }

    [Fact]
    public async Task GivenCorrectData_WhenCreatingAStudent_ThenReturnCreatedStatus()
    {
        //Act
        var result = await _studentController.Create(_student);

        //Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }

    [Fact]
    public async Task GivenExistingId_WhenGettingAStudentById_ThenReturnStudentWithOkStatus()
    {
        //Act
        var result = await _studentController.GetById(id);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        Assert.IsType<Student>(okResult.Value);
    }

    [Fact]
    public async Task WhenGettingAllStudents_ThenReturnStudentsWithOKStatus()
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
    public async Task GivenExistingId_WhenUpdatingAStudent_ThenReturnNoContent()
    {
        //Act
        var result = await _studentController.Update(id, _student);

        //Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task GivenExistingId_WhenDeletingAStudent_ThenReturnNoContent()
    {
        //Act
        var result = await _studentController.Delete(id);

        //Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task GivenExistingId_WhenGettingAStudentUsingBuilder_ThenReturnStudent()
    {
        //Act
        var result = await _studentController.GetAStudentUsingBuilder(id);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        Assert.IsAssignableFrom<Student>(okResult.Value);
    }

    [Fact]
    public void GivenValidId_WhenGettingRange_ThenReturnListOfStudent()
    {
        //Act
        var andResult = _studentController.GetRangeUsingAnd(id, id);
        var orResult = _studentController.GetRangeUsingOr(id, id);

        //Assert
        var andOkResult = Assert.IsType<OkObjectResult>(andResult.Result);

        var orOkResult = Assert.IsType<OkObjectResult>(orResult.Result);

        Assert.IsAssignableFrom<IEnumerable<Student>>(andOkResult.Value);

        Assert.IsAssignableFrom<IEnumerable<Student>>(orOkResult.Value);
    }

    [Fact]
    public void GivenValidIds_WhenGettingFromList_ThenReturnListOfStudent()
    {
        //Act
        var result = _studentController.GetInList(id);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        Assert.IsAssignableFrom<IEnumerable<Student>>(okResult.Value);
    }
}