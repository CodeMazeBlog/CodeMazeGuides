using MongoDB.Bson;
using JoinCollectionsAggregationPipeline;
using MongoDB.Driver;
using Testcontainers.MongoDb;
using JoinCollectionsAggregationPipeline.Models;

await using var mongoDbContainer = new MongoDbBuilder().Build();

await mongoDbContainer.StartAsync();
var mongoClient = new MongoClient(mongoDbContainer.GetConnectionString());
var repository = new StudentRepository(mongoClient);

//Seed Data
var database = mongoClient.GetDatabase(DatabaseConfiguration.DatabaseName);
await MongoHelper.AddSeedData(database);

var users = await repository.GetAllUsers();
foreach (var user in users)
{
    Console.WriteLine(user.ToJson());
}

await mongoDbContainer.StopAsync();