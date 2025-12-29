using System.ComponentModel;
using ModelContextProtocol.Server;
using Domain.Services;

namespace McpServer.Tools;

public class CalculatorTool
{
    private readonly CalculatorService _service;

    public CalculatorTool(CalculatorService service)
    {
        _service = service;
    }

    [McpServerTool]
    [Description("Add two numbers")]
    public int Add([Description("First number")]int a, [Description("Second number")]int b) => _service.Add(a, b);
}
