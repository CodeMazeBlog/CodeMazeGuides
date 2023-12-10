using Microsoft.Extensions.Configuration;
using ReturnInsertedIdentityWithDapper;

var connectionString = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build().GetConnectionString("Connection");

SetUp.CreateTable(connectionString);

var newStudent = new Student() { Firstname = "Emily", Surname = "Smith" };

int insertedIdentity;

insertedIdentity = Methods.UseOfScopeIdentity(connectionString, newStudent);
Console.WriteLine($"Inserted Identity: {insertedIdentity}");

insertedIdentity = Methods.UseOfOutputInserted(connectionString, newStudent);
Console.WriteLine($"Inserted Identity: {insertedIdentity}");