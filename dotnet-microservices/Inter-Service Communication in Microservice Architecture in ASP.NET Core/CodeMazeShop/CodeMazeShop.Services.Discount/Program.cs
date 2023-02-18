using CodeMazeShop.Services.Discount;
using CodeMazeShop.Services.Discount.Entities;
using CodeMazeShop.Services.Discount.Repositories;
using CodeMazeShop.Services.Discount.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICouponRepository, CouponRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<CouponContext>(opt => opt.UseInMemoryDatabase("CouponDb"));
builder.Services.AddGrpc();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetService<CouponContext>();
    await AddTestData(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGrpcService<DiscountService>();

app.Run();

async Task AddTestData(CouponContext? context)
{
    Random _rnd = new();
    var coupons = new List<PromotionCoupon>();
    for (int i = 0; i < 3; i++)
    {
        var couponId = Guid.NewGuid().ToString();
        coupons.Add( new PromotionCoupon
        {
            PromotionCouponId = couponId,
            Code = $"TestCoupon{i + 1}",
            Amount = _rnd.Next(1, 10),
            IsAlreadyUsed = false
        });
    }

    await context?.PromotionCoupons.AddRangeAsync(coupons);

    await context.SaveChangesAsync();
}