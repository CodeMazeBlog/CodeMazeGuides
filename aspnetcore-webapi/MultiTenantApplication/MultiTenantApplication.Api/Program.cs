var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = JwtHelper.GetTokenParameters();
    });

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<ITenantRegistry, TenantRegistry>();
builder.Services.AddScoped<ITenantResolver, TenantResolver>();
builder.Services.AddTransient<IGoodsRepository, GoodsRepository>();
builder.Services.AddDbContext<InventoryDbContext>(o =>
{
    o.UseSqlServer(options => options.MigrationsAssembly(typeof(InventoryDbContext).Assembly.FullName));
});

DatabaseHelper.EnsureLatestDatabase(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }