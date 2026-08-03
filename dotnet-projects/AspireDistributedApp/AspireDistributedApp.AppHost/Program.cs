var builder = DistributedApplication.CreateBuilder(args);

var apiservice = builder.AddProject<Projects.AspireDistributedApp_ApiService>("apiservice");

var redisCache = builder.AddRedisContainer("cache");

builder.AddProject<Projects.AspireDistributedApp_Web>("webfrontend")
    .WithReference(apiservice)
    .WithReference(redisCache);

builder.Build().Run();
