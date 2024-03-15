namespace JoinCollectionsAggregationPipeline.Tests;

public class AggregationPipelineLiveTest : IAsyncLifetime
{
    private readonly MongoDbContainer _mongoDbContainer =
        new MongoDbBuilder().Build();

    [Fact]
    public async Task GivenIHaveUsersAndRolesCollectionsInMongoDB_WhenICallTheGetUserModelsMethod_ThenItMergesTheTwoCollectionsIntoOneResult()
    {
        //Arrange
        var mongoClient = new MongoClient(_mongoDbContainer.GetConnectionString());
        var sut = new StudentRepository(mongoClient);
        var expectedResult = new List<Student>
        {
            new()
            {
                FirstName = "John",
                LastName = "Doe",
                Major = "Electrical Engineering",
                StudentCourses = new List<Course>
                {
                   new() { Name="Networks", Code = "ECEN 474" },
                   new() { Name="Power Systems", Code = "ECEN 485" }
                }
            }
        };

        var database = mongoClient.GetDatabase(DatabaseConfiguration.DatabaseName);
        await MongoHelper.AddSeedData(database);
        
        //Act
        var actualResult = await sut.GetAllUsers();

        //Assert
        Assert.NotNull(actualResult);
        Assert.Equal(expectedResult.Count, actualResult.Count);
        Assert.True(actualResult[0].Equals(expectedResult[0]));
    }

    public async Task InitializeAsync()
        => await _mongoDbContainer.StartAsync();
    public async Task DisposeAsync()
        => await _mongoDbContainer.DisposeAsync();
}