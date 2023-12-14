using MongoDB.Bson;
using MongoDB.Driver;

namespace JoinCollectionsAggregationPipeline.Models;

public static class MongoHelper
{
    public static async Task AddSeedData(IMongoDatabase database)
    {
        var courseCollection = database.GetCollection<BsonDocument>("Courses");
        var studentCollection = database.GetCollection<BsonDocument>("Students");
        await courseCollection.InsertManyAsync(new List<BsonDocument>
        {
            new()
            {
                { "_id", new ObjectId("655e134180c300fcdd067d24") } ,
                { "Name", "Networks" },
                { "Code", "ECEN 474" }
            },
            new()
            {
                { "_id", new ObjectId("655e134180c300fcdd067d25") } ,
                { "Name", "Power Systems" },
                { "Code", "ECEN 485" }
            }
        });

        await studentCollection.InsertManyAsync(new List<BsonDocument>
        {
            new()
            {
                { "_id", new ObjectId("656623db682962fa62ad75ba") } ,
                { "FirstName", "John" },
                { "LastName", "Doe" },
                { "Major", "Electrical Engineering" },
                { "Courses", new BsonArray {
                    new ObjectId("655e134180c300fcdd067d24"),
                    new ObjectId("655e134180c300fcdd067d25")
                } }
            }
        });
    }
}
