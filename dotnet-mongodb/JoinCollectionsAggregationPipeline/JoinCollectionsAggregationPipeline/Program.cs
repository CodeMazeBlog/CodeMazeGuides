using MongoDB.Bson;
using JoinCollectionsAggregationPipeline;

var userModels = await DataPersistenceService.GetUserModels();

foreach (var userModel in userModels)
{
    Console.WriteLine(userModel.ToJson());
}


