using MongoDB.Bson;
using JoinCollectionsAggregationPipeline;
using MongoDB.Driver;
using Testcontainers.MongoDb;
using JoinCollectionsAggregationPipeline.Models;

await using var mongoDbContainer = new MongoDbBuilder("mongo:8.0").Build();

await mongoDbContainer.StartAsync();
var mongoClient = new MongoClient(mongoDbContainer.GetConnectionString());
var repository = new StudentRepository(mongoClient);

//Seed Data
var database = mongoClient.GetDatabase(DatabaseConfiguration.DatabaseName);
await MongoHelper.AddSeedData(database);

var students = await repository.GetAllStudentsAsync();
foreach (var student in students)
{
    Console.WriteLine(student.ToJson());
}

await mongoDbContainer.StopAsync();