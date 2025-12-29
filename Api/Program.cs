using Api.Controllers;
using Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(System.Net.IPAddress.Any, 5000); // Listen on all network interfaces on port 5000
});

builder.Services.AddControllers();

builder.Services.AddSingleton<CalculatorService>();
builder.Services.AddSingleton<WeatherService>();
builder.Services.AddSingleton<ReportService>();

var app = builder.Build();

app.MapControllers();
app.MapGet("/health", () => "OK");

app.Run();
