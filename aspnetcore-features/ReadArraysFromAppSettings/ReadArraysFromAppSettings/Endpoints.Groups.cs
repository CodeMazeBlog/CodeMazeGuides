namespace ReadArraysFromAppSettings;

public partial class Endpoints
{
    public const string GetGroupMembersEndpointName = "api/config/groups/members";

    public static IEnumerable<Member>? GetGroupMembers(IConfiguration configuration)
    {
        AppSettings? appSettings = configuration.GetSection("AppSettings")?.Get<AppSettings>();

        return appSettings?.Groups?.SelectMany(x => x.Members).Distinct();
    }
}
