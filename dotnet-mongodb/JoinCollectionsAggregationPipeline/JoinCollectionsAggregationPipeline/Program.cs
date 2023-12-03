using MongoDB.Bson;
using JoinCollectionsAggregationPipeline;
using MongoDB.Driver;

var repository = new StudentRepository(new MongoClient(DatabaseConfiguration.ConnectionString));
var users = await repository.GetAllUsers();
foreach (var user in users)
{
    Console.WriteLine(user.ToJson());
}