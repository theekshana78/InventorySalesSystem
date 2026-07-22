namespace InventorySales.Core.Models;

public class Item
{
    public int ItemId { get; set; }
    public int CategoryId { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal CostPrice { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;

    // Navigation / Join Property
    public Category? Category { get; set; }
}
