using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using ResolvingDependencyInjection;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Adding Localization to the controllers
builder.Services.AddLocalization();

builder.Services.AddControllers(options =>
{
    LocalizerManager.SetLocalizationOptions(options);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("ja") };
app.UseRequestLocalization(new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture(new CultureInfo("en")),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

using (var serviceScope = app.Services.CreateScope())
{
    var services = serviceScope.ServiceProvider;

    var localizer = services.GetRequiredService<IStringLocalizerFactory>()
                    .Create(typeof(SharedResource));

    LocalizerManager.SetLocalizer(localizer);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
