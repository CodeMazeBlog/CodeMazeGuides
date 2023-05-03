using ReadArraysFromAppSettings;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet(Endpoints.GetUsersEndpointName, Endpoints.GetArrayFromAppSettings);
app.MapGet(Endpoints.GetUsersV2EndpointName, Endpoints.GetArrayFromAppSettingsV2);
app.MapGet(Endpoints.GetGroupMembersEndpointName, Endpoints.GetGroupMembers);

app.Run();

public partial class Program { }