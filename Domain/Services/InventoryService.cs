using System.Collections.Generic;
using System.ComponentModel;
using Domain.Services;

namespace Domain.Services;


/// <summary>
/// An inventory class service later used by my MCP tool.
/// The class exposes two methods check stock and buy item.
/// Also the class contains the inventory data as a dictionary. (for demonstration purposes).
/// No connection to adatabase is implemented here.
/// Class exposes the methods as standard method. No MCP attributes are used here. 
/// </summary>
public class InventoryService
{
    private readonly Dictionary<string, int> _inventory = new()
    {
        { "apple", 10 },
        { "banana", 5 },
        { "orange", 8 }
    };

    /// <summary>
    /// Checks the stock of the specified item.
    /// </summary>
    /// <param name="itemName">The name of the item to check.</param>
    /// <returns>The quantity of the item in stock.</returns>
    public int CheckStock(string itemName)
    {
        return _inventory.TryGetValue(itemName.ToLower(), out var quantity) ? quantity : 0;
    }

    /// <summary>
    /// Buys the specified quantity of the item.
    /// </summary>
    /// <param name="itemName">The name of the item to buy.</param>
    /// <param name="quantity">The quantity to buy.</param>
    /// <returns>True if the purchase was successful; otherwise, false.</returns>
    public bool BuyItem(string itemName, int quantity)
    {
        itemName = itemName.ToLower();
        if (_inventory.TryGetValue(itemName, out var stock) && stock >= quantity)
        {
            _inventory[itemName] -= quantity;
            return true;
        }
        return false;
    }
    
}