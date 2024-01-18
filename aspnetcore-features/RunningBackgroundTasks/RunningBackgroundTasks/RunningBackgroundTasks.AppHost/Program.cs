var builder = DistributedApplication.CreateBuilder(args);

var database = builder.AddSqlServer("sqlServer")
    .AddDatabase("clientsDb");

builder.AddProject<Projects.RunningBackgroundTasks_ApiService>("api")
    .WithReference(database);

builder.Build().Run();
