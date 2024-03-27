var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IContactRepository, InMemoryContactRepository>();

builder.Services.AddScoped<BasicContactService>();
builder.Services.AddScoped<NullCheckingContactService>();
builder.Services.AddScoped<ExceptionsForFlowControlContactService>();
builder.Services.AddScoped<TheResultPatternContactService>();
builder.Services.AddScoped<FluentResultsContactService>();

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
