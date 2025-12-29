namespace Api.Controllers;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("weather")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _service;

    public WeatherController(WeatherService service)
    {
        _service = service;
    }

    [HttpGet("{city}")]
    public WeatherResult Get(string city) => _service.GetWeather(city);
}