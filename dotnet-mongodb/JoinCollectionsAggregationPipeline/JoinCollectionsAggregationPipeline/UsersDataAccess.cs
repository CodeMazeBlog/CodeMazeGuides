using MongoDB.Bson;
using MongoDB.Driver;
using JoinCollectionsAggregationPipeline.Models;

namespace JoinCollectionsAggregationPipeline;

public class UsersDataAccess
{
    private readonly IMongoCollection<User> _userCollection;

    public UsersDataAccess()
    {
        var client = new MongoClient(DatabaseConfiguration.ConnectionString);
        var database = client.GetDatabase(DatabaseConfiguration.DatabaseName);
        _userCollection = database.GetCollection<User>("users");
    }

    public async Task<List<User>> GetAllUsers()
    {
        //Empty Pipeline
        var emptyPipeline = _userCollection.Aggregate();

        //Lookup
        var pipelineStageOne = emptyPipeline.Lookup("roles", "roleId", "_id", "role");

        //Unwind
        var pipelineStageTwo = pipelineStageOne.Unwind("role");

        //Project
        var projection = Builders<BsonDocument>.Projection
            .Exclude("roleId");
        var pipelineStageThree = pipelineStageTwo.Project(projection);
        
        //Cast
        var users = await pipelineStageThree.As<User>().ToListAsync();

        return users;
    }
}