namespace Domain.Services;
using System;

public class WeatherService
{
    public WeatherResult GetWeather(string city)
    {
        // fake data for demo
        return new WeatherResult
        {
            City = city,
            TemperatureC = new Random().Next(-5, 35),
            Condition = "Sunny"
        };
    }
}

public record WeatherResult
{
    public string City { get; init; } = "";
    public int TemperatureC { get; init; }
    public string Condition { get; init; } = "";
}
