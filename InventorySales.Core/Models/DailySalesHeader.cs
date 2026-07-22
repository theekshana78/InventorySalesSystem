namespace InventorySales.Core.Models;

public class DailySalesHeader
{
    public int DailySalesHeaderId { get; set; }
    public DateTime SalesDate { get; set; }
    public decimal TotalSale { get; set; }
    public decimal Cash { get; set; }
    public decimal TotalStockValue { get; set; }
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<DailySalesItemDetail> ItemDetails { get; set; } = new();
    public List<DailyLocationFinance> LocationFinances { get; set; } = new();
}
