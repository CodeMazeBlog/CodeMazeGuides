var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    try
    {
        options.AddPolicy("BadPolicy", builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
        );
    }
    catch (InvalidOperationException exception)
    {
        Console.WriteLine(exception.Message);
        Console.WriteLine(exception.StackTrace);
    }

    options.AddPolicy("GoodPolicy", builder => builder
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler();
    app.UseHsts();
    app.UseStatusCodePages();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();

app.Run();


namespace FixCorsProtocolErrorWithAnyOriginAndAllowCredentials.Api 
{
    public partial class Program;
}
