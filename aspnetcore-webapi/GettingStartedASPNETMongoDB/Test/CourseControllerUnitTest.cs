using Microsoft.AspNetCore.Mvc;
using Moq;
using GettingStartedASPNETMongoDB.Controllers;
using GettingStartedASPNETMongoDB.Interfaces;
using GettingStartedASPNETMongoDB.Models;

namespace Test;

public class CourseControllerUnitTest
{        
    private Mock<ICourseService> _courseService;

    private CourseController _courseController;

    private Course _course;

    public CourseControllerUnitTest()
    {
        Setup();
    }

    [Fact]
    public async Task GivenCreate_WhenSentCorrectData_ThenReturnCreatedStatus()
    {
        //Act
        var result = await _courseController.Create(_course);

        //Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }

    [Fact]
    public async Task GivenGetById_WhenSentCorrectId_ThenReturnStudentWithOkStatus()
    {
        //Arrange
        var id = "1";

        //Act
        var result = await _courseController.GetById(id);

        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);

        Assert.IsType<Course>(okResult.Value);
    }

    private void Setup()
    {
        var id = "1";

        _course = new() { Id = id, Code = "BCH 422", Name = "Tissue Biochemistry" };

        _courseService = new Mock<ICourseService>();

        _courseService.Setup(x => x.GetById(id)).ReturnsAsync(_course);

        _courseService.Setup(x => x.Create(It.IsAny<Course>())).ReturnsAsync(_course);

        _courseController = new(_courseService.Object);
    }
}