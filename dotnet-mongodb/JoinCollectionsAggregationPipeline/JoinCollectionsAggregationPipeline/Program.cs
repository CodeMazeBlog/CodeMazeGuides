using MongoDB.Bson;
using JoinCollectionsAggregationPipeline;

var repository = new StudentRepository();
var users = await repository.GetAllUsers();
foreach (var user in users)
{
    Console.WriteLine(user.ToJson());
}


