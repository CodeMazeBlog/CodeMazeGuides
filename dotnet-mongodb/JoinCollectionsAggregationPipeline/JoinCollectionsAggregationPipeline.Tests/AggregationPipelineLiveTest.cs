using JoinCollectionsAggregationPipeline.Models;

namespace JoinCollectionsAggregationPipeline.Tests;

public class AggregationPipelineLiveTest
{
    private readonly UsersDataAccess _sut;

    public AggregationPipelineLiveTest()
    {
        _sut = new UsersDataAccess();
    }

    [Test]
    public async Task
    GivenIHaveUsersAndRolesCollectionsInMongoDB_WhenICallTheGetUserModelsMethod_ThenItMergesTheTwoCollectionsIntoOneResult()
    {
        //Arrange
        var expectedResult = new List<User>
        {
            new()
            {
                Name = "Admin User",
                Email = "admin@example.com",
                Role = new Role
                {
                    Name = "Admin",
                }
            },
            new()
            {
                Name = "Author User",
                Email = "author@example.com",
                Role = new Role
                {
                    Name = "Author"
                }
            },
            new()
            {
                Name = "Editor User",
                Email = "editor@example.com",
                Role = new Role
                {
                    Name = "Editor"
                }
            }
        };

        //Act
        var actualResult = await _sut.GetAllUsers();

        //Assert
        Assert.That(actualResult, Is.Not.Null);
        Assert.That(actualResult, Has.Count.EqualTo(expectedResult.Count));
        Assert.Multiple(() =>
        {
            Assert.That(actualResult[0], Is.EqualTo(expectedResult[0]));
            Assert.That(actualResult[1], Is.EqualTo(expectedResult[1]));
            Assert.That(actualResult[2], Is.EqualTo(expectedResult[2]));
        });
    }
}