using System.Text.Json;
using MongoDB.Driver;
using JoinCollectionsAggregationPipeline.Entities;

namespace JoinCollectionsAggregationPipeline.Helpers;

public static class MongoHelper
{
    private const string _rolesJsonFile = "Assets/roles.json";
    private const string _usersJsonFile = "Assets/users.json";

    public static async Task SeedDataAsync(this IMongoDatabase database)
    {
        var roleCollection = database.GetCollection<Role>(CollectionNames.Roles);
        var userCollection = database.GetCollection<User>(CollectionNames.Users);
        await roleCollection.SeedRoleDataAsync();
        await userCollection.SeedUserDataAsync();
    }

    private static async Task SeedRoleDataAsync(this IMongoCollection<Role> roleCollection)
    {
        if (await roleCollection.AsQueryable().AnyAsync()) return;
        var rolesJson = await File.ReadAllTextAsync(_rolesJsonFile);
        var roles = JsonSerializer.Deserialize<List<Role>>(rolesJson);
        await roleCollection.InsertManyAsync(roles);
    }

    private static async Task SeedUserDataAsync(this IMongoCollection<User> userCollection)
    {
        if(await userCollection.AsQueryable().AnyAsync()) return;
        var rolesJson = await File.ReadAllTextAsync(_usersJsonFile);
        var roles = JsonSerializer.Deserialize<List<User>>(rolesJson);
        await userCollection.InsertManyAsync(roles);
    }
}