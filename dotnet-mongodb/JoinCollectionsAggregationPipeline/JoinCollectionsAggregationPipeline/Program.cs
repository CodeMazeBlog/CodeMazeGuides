using MongoDB.Bson;
using JoinCollectionsAggregationPipeline;

var dataAccess = new UsersDataAccess();
var users = await dataAccess.GetAllUsers();
foreach (var user in users)
{
    Console.WriteLine(user.ToJson());
}


