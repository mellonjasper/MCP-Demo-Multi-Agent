using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Server;
// 1. Ensure you have this namespace (if available in your IDE options)
using ModelContextProtocol.AspNetCore; 
using Domain.Services;
using McpServer.Tools;

var builder = WebApplication.CreateBuilder(args);

// 2. Register Domain Services
builder.Services.AddSingleton<CalculatorService>();
builder.Services.AddSingleton<WeatherService>();
builder.Services.AddSingleton<ReportService>();

// 3. Register MCP Server
// In 0.5.0-preview, "WithHttpTransport" enables SSE + POST support.
builder.Services.AddMcpServer()
    .WithHttpTransport() // <--- Replaces WithSseServerTransport / AddAspNetCore
    .WithTools<WeatherTool>()
    .WithTools<CalculatorTool>()
    .WithTools<RandomNumberTools>()
    .WithTools<ReportTool>();

var app = builder.Build();

app.UseRouting();

// 4. Map the Endpoints
// In 0.5.0-preview, this single line maps the endpoints (defaults to /mcp)
app.MapMcp(); 

app.Run();