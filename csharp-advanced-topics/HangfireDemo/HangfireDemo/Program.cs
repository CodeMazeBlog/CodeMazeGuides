using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Hangfire
builder.Services.AddHangfire(x => x.UseSqlServerStorage(@"Data Source=DESKTOP-8RL8JOG;Initial Catalog=hangfire;Integrated Security=True;Pooling=False"));
builder.Services.AddHangfireServer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseHangfireDashboard();

app.UseAuthorization();

app.MapControllers();

app.Run();
