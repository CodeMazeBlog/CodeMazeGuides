using MongoDB.Bson;
using MongoDB.Driver;
using JoinCollectionsAggregationPipeline.Entities;
using JoinCollectionsAggregationPipeline.Helpers;
using JoinCollectionsAggregationPipeline.Models;

namespace JoinCollectionsAggregationPipeline;

public static class DataPersistenceService
{
    public static async Task<List<UserModel>> GetUserModels()
    {
        //Initialize mongo client
        var client = new MongoClient(DatabaseConfiguration.ConnectionString);

        //Initialize mongo database
        var database = client.GetDatabase(DatabaseConfiguration.DatabaseName);

        //Insert seed data
        await database.SeedDataAsync();

        //Initialize users mongo collection
        var userCollection = database.GetCollection<User>(CollectionNames.Users);

        //build projection
        var projection = Builders<BsonDocument>.Projection
            .Exclude(UserProperties.RoleId);

        //Apply aggregate pipeline and return result
        return await userCollection.Aggregate()
            .Lookup(CollectionNames.Roles, UserProperties.RoleId,
                RoleProperties.Id, UserProperties.Role)
            .Unwind(UserProperties.Role)
            .Project(projection)
            .As<UserModel>()
            .ToListAsync();
    }
}