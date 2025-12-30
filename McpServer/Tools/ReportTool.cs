using System.ComponentModel;
using ModelContextProtocol.Server;
using Domain.Services;

namespace McpServer.Tools;

public class ReportTool
{
    private readonly ReportService _service;

    public ReportTool(ReportService service)
    {
        _service = service;
    }

    [McpServerTool]
    [Description("Generate a weather summary report for a specified city.")]
    public string GenerateWeatherSummary([Description("City name")]string city)
        => _service.GenerateWeatherSummary(city);
}
