using InventorySales.Core.Models;

namespace InventorySales.Core.DTOs;

public class DailySalesViewModel
{
    public DailySalesHeader Header { get; set; } = new();
    public List<DailySalesItemDetail> ItemDetails { get; set; } = new();
    public List<DailyLocationFinance> LocationFinances { get; set; } = new();
}
