using UsingResultPatternInNETWebAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IContactRepository, InMemoryContactRepository>();

builder.Services.AddScoped<BasicContactService>();
builder.Services.AddScoped<NullCheckingContactService>();
builder.Services.AddScoped<ExceptionsForFlowControlContactService>();
builder.Services.AddScoped<TheResultPatternContactService>();
builder.Services.AddScoped<FluentResultsContactService>();

builder.Services.AddValidation();
builder.Services.AddExceptionHandler<DefaultExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

app.MapBasicContactEndpoints();
app.MapNullCheckingContactEndpoints();
app.MapExceptionsForFlowControlContactEndpoints();
app.MapTheResultPatternContactEndpoints();
app.MapFluentResultsContactEndpoints();

app.Run();
