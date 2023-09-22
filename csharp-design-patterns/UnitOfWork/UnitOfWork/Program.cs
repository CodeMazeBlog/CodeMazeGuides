
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork.DataAccess;
using UnitOfWork.DataAccess.Dapper;
using UnitOfWork.DataAccess.EntityFramework;
using UnitOfWork.Entities;
using UnitOfWork.Repositories;

var services = new ServiceCollection();

services.AddScoped<UnitOfWork.DataAccess.IUnitOfWork, UnitOfWork.DataAccess.UnitOfWork>();
services.AddScoped<IOrderRepository, OrderRepository>();

services.AddScoped<AppDbContext>();
services.AddScoped<IDatabase, AppDbContext>(sp => sp.GetRequiredService<AppDbContext>());
services.AddScoped<UnitOfWork.DataAccess.EntityFramework.IUnitOfWork, AppDbContext>(sp => sp.GetRequiredService<AppDbContext>());
//OR
services.AddScoped<IDatabase, DapperContext>();

var serviceProvider = services.BuildServiceProvider();

var db = serviceProvider.GetRequiredService<IDatabase>();
var unitOfWork = serviceProvider.GetRequiredService<UnitOfWork.DataAccess.EntityFramework.IUnitOfWork>();

db.AddOrder(new Order());
unitOfWork.SaveChangesAsync();