using FastEndpoints;

var bld = WebApplication.CreateBuilder();
bld.Services.AddFastEndpoints();

var app = bld.Build();
app.UseFastEndpoints();
app.Run();