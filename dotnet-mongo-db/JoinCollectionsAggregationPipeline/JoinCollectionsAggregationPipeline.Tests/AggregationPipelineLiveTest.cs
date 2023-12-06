namespace JoinCollectionsAggregationPipeline.Tests;

public class AggregationPipelineLiveTest : IAsyncLifetime
{
    private StudentRepository _sut;
    private readonly MongoDbContainer _mongoDbContainer =
        new MongoDbBuilder().Build();

    [Fact]
    public async Task GivenIHaveUsersAndRolesCollectionsInMongoDB_WhenICallTheGetUserModelsMethod_ThenItMergesTheTwoCollectionsIntoOneResult()
    {
        //Arrange
        var mongoClient = new MongoClient(_mongoDbContainer.GetConnectionString());
        _sut = new StudentRepository(mongoClient);
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

        var database = mongoClient.GetDatabase(DatabaseConfiguration.DatabaseName);
        await MongoHelper.AddSeedData(database);
        

        //Act
        var actualResult = await _sut.GetAllUsers();

        //Assert
        Assert.NotNull(actualResult);
        Assert.Equal(expectedResult.Count, actualResult.Count);
        Assert.True(actualResult[0].Equals(expectedResult[0]));
    }

    public Task InitializeAsync()
        => _mongoDbContainer.StartAsync();
    public Task DisposeAsync()
        => _mongoDbContainer.DisposeAsync().AsTask();
}