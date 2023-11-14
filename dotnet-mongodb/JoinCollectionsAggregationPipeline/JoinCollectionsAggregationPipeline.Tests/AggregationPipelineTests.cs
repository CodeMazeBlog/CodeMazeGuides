using JoinCollectionsAggregationPipeline.Models;

namespace JoinCollectionsAggregationPipeline.Tests;

public class AggregationPipelineTests
{
    [Test]
    public async Task
    GivenIHaveUsersAndRolesCollectionsInMongoDB_WhenICallTheGetUserModelsMethod_ThenItMergesTheTwoCollectionsIntoOneResult()
    {
        //Arrange
        var expectedResult = new List<UserModel>
        {
            new()
            {
                Id = "65535ad6f8bae505193fdf6f",
                Name = "Admin User",
                Email = "admin@example.com",
                Role = new RoleModel
                {
                    Id = "65535aa28ae1579f7ea4c46f",
                    Name = "Admin"
                }
            },
            new()
            {
                Id = "65535ade30d1ddb6043e7502",
                Name = "Author User",
                Email = "author@example.com",
                Role = new RoleModel
                {
                    Id = "65535ab1290a29bb6205f716",
                    Name = "Author"
                }
            },
            new()
            {
                Id = "65535ae5aaa6a08b7c3c8e9d",
                Name = "Editor User",
                Email = "editor@example.com",
                Role = new RoleModel
                {
                    Id = "65535abb9d62d7565949d8ac",
                    Name = "Editor"
                }
            }
        };

        //Act
        var actualResult = await DataPersistenceService.GetUserModels();

        //Assert
        Assert.That(actualResult, Is.Not.Null);
        Assert.That(actualResult.Count, Is.EqualTo(expectedResult.Count));
        Assert.That(actualResult[0].Equals(expectedResult[0]), Is.True);
        Assert.That(actualResult[1].Equals(expectedResult[1]), Is.True);
        Assert.That(actualResult[2].Equals(expectedResult[2]), Is.True);
    }
}