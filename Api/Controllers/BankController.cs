///Simple api controller to interacti with my bank service in Domain/services

using Microsoft.AspNetCore.Mvc;
using Domain.Services;

[ApiController]
[Route("bank")]
public class BankController : ControllerBase
{
    private readonly BankService _service;

    public BankController(BankService service)
    {
        _service = service;
    }

    [HttpGet]
    public decimal GetBalance() => _service.GetBalance();

    [HttpPost("deposit")]
    public void Deposit(decimal amount) => _service.Deposit(amount);
    [HttpPost("withdraw")]
    public string Withdraw(decimal amount)
    {
        try{
            _service.Withdraw(amount);
            return "Withdrawal successful";
        }
        catch(InvalidOperationException ex)
        {
            return $"Withdrawal failed: {ex.Message}";
        }
        catch(Exception ex)
        {
            return $"Withdrawal failed: {ex.Message}";
        }
    
    }
}