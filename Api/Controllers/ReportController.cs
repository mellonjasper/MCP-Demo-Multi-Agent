namespace Api.Controllers;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("report")]
public class ReportController : ControllerBase
{
    private readonly ReportService _service;

    public ReportController(ReportService service)
    {
        _service = service;
    }

    [HttpPost("weather-summary")]
    public string Generate(string city)
        => _service.GenerateWeatherSummary(city);
}