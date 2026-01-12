///an mcp tool to manage bank accounts. 
/// it uses the BankService from Domain/Services to perform operations.
/// In the reposnse add also text around the domain call to explain the result of the operation.
/// wrap eventually the response of each tool in a json object containing status and message.
/// this tool behaves as the other tools present in this folder.

using System.ComponentModel;
using ModelContextProtocol.Server;
using Domain.Services;

namespace McpServer.Tools;

public class BankTool
{
    private readonly BankService _service;

    public BankTool(BankService service)
    {
        _service = service;
    }
    [McpServerTool]
    [Description("Get the balance of an account")]
    public decimal GetBalance() => _service.GetBalance();

    [McpServerTool]
    [Description("Deposit an amount into an account")]
    public string Deposit([Description("Amount to deposit")]decimal amount)
    {
        _service.Deposit(amount);
        return "Deposit successful";
    }   
    [McpServerTool]
    [Description("Withdraw an amount from an account")]
    public string Withdraw([Description("Amount to withdraw")]decimal amount)
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