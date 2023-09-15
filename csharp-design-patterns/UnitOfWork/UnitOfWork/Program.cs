
using Microsoft.Extensions.DependencyInjection;
using UnitOfWork.DataAccess;
using UnitOfWork.DataAccess.Dapper;
using UnitOfWork.DataAccess.EntityFramework;
using UnitOfWork.Repositories;

var services = new ServiceCollection();

services.AddScoped<IUnitOfWork, UnitOfWork.DataAccess.UnitOfWork>();
services.AddScoped<IOrderRepository, OrderRepository>();

services.AddScoped<IDatabase, AppDbContext>();
//OR
services.AddScoped<IDatabase, DapperContext>();

var serviceProvider = services.BuildServiceProvider();