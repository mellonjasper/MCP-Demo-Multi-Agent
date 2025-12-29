namespace Api.Controllers;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("calculator")]
public class CalculatorController : ControllerBase
{
    private readonly CalculatorService _service;

    public CalculatorController(CalculatorService service)
    {
        _service = service;
    }

    [HttpGet("add")]
    public int Add(int a, int b) => _service.Add(a, b);
}