using System.ComponentModel;
using ModelContextProtocol.Server;
using Domain.Services;

namespace McpServer.Tools;

public class WeatherTool
{
    private readonly WeatherService _service;

    public WeatherTool(WeatherService service)
    {
        _service = service;
    }
    
    [McpServerTool]
    [Description("Get weather for a specified city.")]
    public WeatherResult GetWeatherForCity([Description("City name")]string city)
        => _service.GetWeather(city);
}
