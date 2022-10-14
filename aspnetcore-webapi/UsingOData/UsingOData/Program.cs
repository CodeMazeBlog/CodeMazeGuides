using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using UsingOData;

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Company>("Companies");
    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddOData(options => options
        .AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(20)
        .Count()
        .Expand()
    );

builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase(databaseName: "CompaniesDB"));

builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AddCompaniesData(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddCompaniesData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<ApiContext>();

    db.Companies.Add(
        new Company()
        {
            ID = 1,
            Name = "Company A",
            Size = 25
        });

    db.Companies.Add(
        new Company()
        {
            ID = 2,
            Name = "Company B",
            Size = 56
        });

    db.Companies.Add(
        new Company()
        {
            ID = 3,
            Name = "Company C",
            Size = 12
        });

    db.Companies.Add(
        new Company()
        {
            ID = 4,
            Name = "Company D",
            Size = 205
        });

    db.Products.Add(
        new Product()
        {
            ID = 1,
            CompanyID = 1,
            Name = "Product A",
            Price = 10
        });

    db.Products.Add(
        new Product()
        {
            ID = 2,
            CompanyID = 1,
            Name = "Product B",
            Price = 35
        });

    db.Products.Add(
        new Product()
        {
            ID = 3,
            CompanyID = 2,
            Name = "Product C",
            Price = 22
        });

    db.Products.Add(
        new Product()
        {
            ID = 4,
            CompanyID = 2,
            Name = "Product D",
            Price = 15
        });

    db.Products.Add(
        new Product()
        {
            ID = 5,
            CompanyID = 3,
            Name = "Product E",
            Price = 103
        });

    db.Products.Add(
        new Product()
        {
            ID = 6,
            CompanyID = 3,
            Name = "Product F",
            Price = 135
        });

    db.Products.Add(
        new Product()
        {
            ID = 7,
            CompanyID = 4,
            Name = "Product G",
            Price = 76
        });

    db.Products.Add(
        new Product()
        {
            ID = 8,
            CompanyID = 4,
            Name = "Product H",
            Price = 33
        });

    db.SaveChanges();

}

// Make the implicit Program class public so test projects can access it
public partial class Program { }


