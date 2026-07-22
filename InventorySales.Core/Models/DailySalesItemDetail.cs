namespace InventorySales.Core.Models;

public class DailySalesItemDetail
{
    public int DetailId { get; set; }
    public int DailySalesHeaderId { get; set; }
    public int ItemId { get; set; }

    // Formula Inputs & Calculated Fields
    public decimal RoutineStock { get; set; }
    public decimal NewStock { get; set; }
    public decimal MainStock { get; set; }
    public decimal IssueOut { get; set; }
    public decimal Returned { get; set; }
    public decimal SaleQuantity { get; set; }
    public decimal SaleValue { get; set; }
    public decimal FinalStock { get; set; }
    public decimal FinalStockValue { get; set; }
    public decimal MySale { get; set; }
    public decimal MySaleValue { get; set; }

    // Joined Item metadata for Grid Display
    public string ItemName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal CostPrice { get; set; }

    // Calculated Profit Metrics (Page 3)
    public decimal UnitProfit => Price - CostPrice;
    public decimal TotalQtySold => SaleQuantity + MySale;
    public decimal TotalCost => TotalQtySold * CostPrice;
    public decimal TotalRevenue => TotalQtySold * Price;
    public decimal NetProfit => TotalRevenue - TotalCost;
    public decimal ProfitMarginPercentage => TotalCost > 0 ? (NetProfit / TotalCost) * 100m : 0m;

    public string CategoryName { get; set; } = string.Empty;
    public string CategoryColorHex { get; set; } = "#FFFFFF";
    public int CategoryDisplayOrder { get; set; }
    public int ItemDisplayOrder { get; set; }
}
