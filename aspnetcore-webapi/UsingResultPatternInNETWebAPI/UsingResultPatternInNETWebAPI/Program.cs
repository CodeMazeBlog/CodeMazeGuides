var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IContactsRepository, InMemoryContactsRepository>();

builder.Services.AddScoped<BasicContactsService>();
builder.Services.AddScoped<NullCheckingContactsService>();
builder.Services.AddScoped<ExceptionsForFlowControlContactsService>();
builder.Services.AddScoped<TheResultPatternContactsService>();
builder.Services.AddScoped<FluentResultsContactsService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<DefaultExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler(opt => { });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
    app.UseStatusCodePages();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

namespace UsingResultPatternInNETWebAPI
{
    public class Program;
}