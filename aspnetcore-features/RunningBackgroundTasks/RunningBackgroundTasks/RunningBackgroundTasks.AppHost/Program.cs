var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddSqlServer("sqlServer")
    .AddDatabase("clientsDb");

var apiService = builder.AddProject<Projects.RunningBackgroundTasks_ApiService>("api")
    .WithReference(database);

builder.AddProject<Projects.RunningBackgroundTasks_Web>("frontend")
    .WithReference(apiService);

builder.Build().Run();
