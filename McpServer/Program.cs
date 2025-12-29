using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ModelContextProtocol.Server;
using Domain.Services;
using McpServer.Tools;

var builder = Host.CreateApplicationBuilder(args);

// Configure all logs to go to stderr (stdout is used for the MCP protocol messages).
builder.Logging.AddConsole(o => o.LogToStandardErrorThreshold = LogLevel.Trace);

// Add the MCP services: the transport to use (stdio) and the tools to register.

builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<WeatherTool>()
    .WithTools<CalculatorTool>()
    .WithTools<RandomNumberTools>()
    .WithTools<ReportTool>();

    
builder.Services.AddSingleton<CalculatorService>();
builder.Services.AddSingleton<WeatherService>();
builder.Services.AddSingleton<ReportService>();


await builder.Build().RunAsync();