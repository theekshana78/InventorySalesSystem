namespace InventorySales.Core.Models;

public class DailyLocationFinance
{
    public int FinanceId { get; set; }
    public int DailySalesHeaderId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public decimal Bills { get; set; }
    public decimal Cheques { get; set; }
    public decimal EarlyCredits { get; set; }
    public decimal Returned { get; set; }
    public decimal Balance { get; set; }
    public int DisplayOrder { get; set; }
}
