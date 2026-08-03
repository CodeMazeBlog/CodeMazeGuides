var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    try
    {
        options.AddPolicy("BadPolicy", policyBuilder => policyBuilder
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

    options.AddPolicy("GoodPolicy", policyBuilder => policyBuilder
        .SetIsOriginAllowed(origin => true) // allow any origin
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
    );

    options.AddPolicy("BestPolicy", policyBuilder =>
    {
        var origins = new List<string>();
        builder.Configuration.Bind("Cors:Origins", origins);

        if (origins.Any())
        {
            policyBuilder
                .WithOrigins(origins.ToArray())
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
        }
    });

    options.DefaultPolicyName = "BestPolicy";
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


public partial class Program;
