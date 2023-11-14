namespace JoinCollectionsAggregationPipeline.Helpers;

public static class UserProperties
{
    public const string RoleId = "roleId";
    public const string Role = "role";
}

public static class RoleProperties
{
    public const string Id = "_id";
}

public static class CollectionNames
{
    public const string Users = "users";
    public const string Roles = "roles";
}

public static class DatabaseConfiguration
{
    public const string ConnectionString = "mongodb://localhost:27017";
    public const string DatabaseName = "sampledatabase";
}