namespace JoinCollectionsAggregationPipeline.Tests;

public class AggregationPipelineLiveTest
{
    private readonly StudentRepository _sut;

    public AggregationPipelineLiveTest()
    {
        _sut = new StudentRepository();
    }

    [Test]
    public async Task
    GivenIHaveUsersAndRolesCollectionsInMongoDB_WhenICallTheGetUserModelsMethod_ThenItMergesTheTwoCollectionsIntoOneResult()
    {
        //Arrange
        var expectedResult = new List<Student>
        {
            new()
            {
                FirstName = "John",
                LastName = "Doe",
                Major = "Electrical Engineering",
                StudentCourses = new List<Course>
                {
                   new() {Name="Networks", Code = "ECEN 474"},
                   new() {Name="Power Systems", Code = "ECEN 485"}
                }
            }
        };

        //Act
        var actualResult = await _sut.GetAllUsers();

        //Assert
        Assert.That(actualResult, Is.Not.Null);
        Assert.That(actualResult, Has.Count.EqualTo(expectedResult.Count));
        Assert.That(actualResult[0].Equals(expectedResult[0]));
    }
}