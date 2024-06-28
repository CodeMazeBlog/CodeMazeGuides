using Azure;
using Azure.AI.OpenAI;
using OpenAiImageGenerator.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped(sp =>
{
    return new OpenAIClient(
        new Uri(builder.Configuration["AzureOpenAiEndpoint"]),
        new AzureKeyCredential(builder.Configuration["AzureOpenAiApiKey"]));
});

builder.Services.AddScoped<IOpenAIService, OpenAIService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                           builder =>
                           {
                               builder.WithOrigins("http://localhost")
                                   .AllowAnyHeader()
                                   .AllowAnyMethod();
                           });
});

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

app.MapControllers();
app.UseCors();

app.Run();