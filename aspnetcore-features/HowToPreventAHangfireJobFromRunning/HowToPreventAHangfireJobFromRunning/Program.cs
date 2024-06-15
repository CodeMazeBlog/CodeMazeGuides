using HowToPreventAHangfireJobFromRunning.Configurations.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<JobService>();

builder.Services.AddHangfire((provider, config) =>
{
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_180);
    config.UseSimpleAssemblyNameTypeSerializer();
    config.UseRecommendedSerializerSettings();
    config.UseInMemoryStorage();
    config.UseColouredConsoleLogProvider();
    
    config.UseFilter(new DisableQueueingFilter(provider.GetRequiredService<ILogger<DisableQueueingFilter>>()));
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard();
app.MapHangfireDashboard("/hangfire");

app.MapControllers();

app.Run();
