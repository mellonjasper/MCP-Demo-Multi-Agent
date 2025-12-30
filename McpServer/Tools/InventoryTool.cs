using Domain.Services;
using System.ComponentModel;
using ModelContextProtocol.Server;
namespace McpServer.Tools;
public class InventoryTool
{
    private readonly InventoryService _service;

    public InventoryTool(InventoryService service)
    {
        _service = service;
    }

    [McpServerTool]
    [Description("Check stock of an item")]
    public int CheckStock([Description("Name of the item to check")]string itemName) => _service.CheckStock(itemName);

    [McpServerTool]
    [Description("Buy an item")]
    public bool BuyItem([Description("Name of the item to buy")]string itemName, [Description("Quantity to buy")]int quantity) => _service.BuyItem(itemName, quantity);
}