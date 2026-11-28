using ReportApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/report/slow", (int orders = 10_000) => ReportBuilder.BuildWithConcatenation(orders));
app.MapGet("/report/fast", (int orders = 10_000) => ReportBuilder.BuildWithStringBuilder(orders));

app.Run();
