namespace InventorySales.Core.Models;

public class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string ColorHex { get; set; } = "#FFFFFF";
    public int DisplayOrder { get; set; }
}
