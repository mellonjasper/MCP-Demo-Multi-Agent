namespace Domain.Services;

public class ReportService
{
    private readonly WeatherService _weather;

    public ReportService(WeatherService weather)
    {
        _weather = weather;
    }

    public string GenerateWeatherSummary(string city)
    {
        var weather = _weather.GetWeather(city);

        return $"Weather report for {weather.City}: " +
               $"{weather.TemperatureC}°C and {weather.Condition}.";
    }
}
