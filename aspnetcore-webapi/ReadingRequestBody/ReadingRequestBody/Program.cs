using ReadingRequestBody.OpenApiUtils;
using ReadingRequestBody.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ReadRequestBodyActionFilter>();
});

builder.Services.AddOpenApi(options =>
{
    options.AddOperationTransformer<RawTextRequestOperationTransformer>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<RequestBodyMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
