using MongoDB.Bson;
using JoinCollectionsAggregationPipeline;
using MongoDB.Driver;
using Testcontainers.MongoDb;

var mongoDbContainer =
        new MongoDbBuilder().Build();

await mongoDbContainer.StartAsync();
var mongoClient = new MongoClient(mongoDbContainer.GetConnectionString());
var repository = new StudentRepository(mongoClient);

//Seed Data
var database = mongoClient.GetDatabase(DatabaseConfiguration.DatabaseName);
var courseCollection = database.GetCollection<BsonDocument>("Courses");
var studentCollection = database.GetCollection<BsonDocument>("Students");
courseCollection.InsertMany(new List<BsonDocument>
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

studentCollection.InsertMany(new List<BsonDocument>
{
    new()
    {
        { "FirstName", "John" },
        { "LastName", "Doe" },
        { "Major", "Electrical Engineering" },
        { "Courses", new BsonArray {
            new ObjectId("655e134180c300fcdd067d24"),
            new ObjectId("655e134180c300fcdd067d25")
        } }
    }
});


var users = await repository.GetAllUsers();
foreach (var user in users)
{
    Console.WriteLine(user.ToJson());
}

await mongoDbContainer.StopAsync();