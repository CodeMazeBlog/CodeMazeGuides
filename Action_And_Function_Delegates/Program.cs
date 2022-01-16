var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
//Action_Delegates.Action_Delegate_Class.Main();
//Func_Delegates.Func_Delegate_Class.Main();

Func<int, int, decimal> Get_Percentage = Func_Delegates.Func_Delegate_Class.Percentage_Calculation;

decimal MarksPercent = Get_Percentage(320, 500);

Console.WriteLine($"{MarksPercent }");