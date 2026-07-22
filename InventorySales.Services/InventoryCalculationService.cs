using InventorySales.Core.Models;

namespace InventorySales.Services;

public interface IInventoryCalculationService
{
    void CalculateItemRow(DailySalesItemDetail item);
    void CalculateLocationRow(DailyLocationFinance location);
    void RecalculateLocationTotals(List<DailyLocationFinance> locations);
    (decimal TotalSale, decimal TotalStockValue, decimal TotalMySaleValue) CalculateSummaryTotals(IEnumerable<DailySalesItemDetail> items);
}

public class InventoryCalculationService : IInventoryCalculationService
{
    public void CalculateItemRow(DailySalesItemDetail item)
    {
        if (item == null) return;

        // Formula 1: Main Stock = Routine Stock + New
        item.MainStock = item.RoutineStock + item.NewStock;

        // Formula 2: Sale Quantity = Issue Out - Returned
        item.SaleQuantity = item.IssueOut - item.Returned;

        // Formula 3: Sale Value = Sale Quantity * Price
        item.SaleValue = item.SaleQuantity * item.Price;

        // Formula 4: Final Stock = Main Stock - Sale Quantity - My Sale Qty
        item.FinalStock = item.MainStock - item.SaleQuantity - item.MySale;

        // Formula 5: Final Stock Value = Final Stock * Price
        item.FinalStockValue = item.FinalStock * item.Price;

        // Formula 6: My Sale Value = My Sale * Price
        item.MySaleValue = item.MySale * item.Price;
    }

    public void CalculateLocationRow(DailyLocationFinance location)
    {
        if (location == null) return;

        // Formula: Balance = (Bills + Cheques + Early Credits) - Returned
        location.Balance = (location.Bills + location.Cheques + location.EarlyCredits) - location.Returned;
    }

    public void RecalculateLocationTotals(List<DailyLocationFinance> locations)
    {
        if (locations == null || !locations.Any()) return;

        var totalRow = locations.FirstOrDefault(l => l.LocationName.Equals("TOTAL", StringComparison.OrdinalIgnoreCase));
        if (totalRow == null) return;

        var otherRows = locations.Where(l => !l.LocationName.Equals("TOTAL", StringComparison.OrdinalIgnoreCase)).ToList();

        totalRow.Bills = otherRows.Sum(l => l.Bills);
        totalRow.Cheques = otherRows.Sum(l => l.Cheques);
        totalRow.EarlyCredits = otherRows.Sum(l => l.EarlyCredits);
        totalRow.Returned = otherRows.Sum(l => l.Returned);
        totalRow.Balance = (totalRow.Bills + totalRow.Cheques + totalRow.EarlyCredits) - totalRow.Returned;
    }

    public (decimal TotalSale, decimal TotalStockValue, decimal TotalMySaleValue) CalculateSummaryTotals(IEnumerable<DailySalesItemDetail> items)
    {
        if (items == null) return (0, 0, 0);

        decimal totalSale = items.Sum(i => i.SaleValue);
        decimal totalStockValue = items.Sum(i => i.FinalStockValue);
        decimal totalMySaleValue = items.Sum(i => i.MySaleValue);

        return (totalSale, totalStockValue, totalMySaleValue);
    }
}
