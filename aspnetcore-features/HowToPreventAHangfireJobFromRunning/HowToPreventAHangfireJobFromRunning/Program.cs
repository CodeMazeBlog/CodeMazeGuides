var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<JobService>();

builder.Services.AddHangfire((provider, config) =>
{
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180);
    config.UseSimpleAssemblyNameTypeSerializer();
    config.UseRecommendedSerializerSettings();
    config.UseInMemoryStorage();

    config.UseFilter(new SkipConcurrentExecutionFilter(
        provider.GetRequiredService<ILogger<SkipConcurrentExecutionFilter>>()));
});
builder.Services.AddHangfireServer();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHangfireDashboard();
app.MapHangfireDashboard("/hangfire");

app.MapControllers();

app.Run();

namespace HowToPreventAHangfireJobFromRunning
{
    public class Program;
}