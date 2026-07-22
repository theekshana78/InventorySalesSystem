using InventorySales.Core.DTOs;
using InventorySales.Core.Models;
using InventorySales.DataAccess;

namespace InventorySales.Services;

public interface IDailySalesService
{
    Task<DailySalesViewModel> LoadDailySalesAsync(DateTime date);
    Task<bool> SaveDailySalesAsync(DailySalesViewModel vm);
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Item> AddItemAsync(Item item);
    Task<bool> DeleteItemAsync(int itemId);
    Task<bool> UpdateItemCostPriceAsync(int itemId, decimal costPrice);
    Task<bool> UpdateItemMasterAsync(int itemId, string itemName, decimal price, decimal costPrice);
    Task<bool> UpdateLocationNameAsync(int financeId, string newLocationName);
}

public class DailySalesService : IDailySalesService
{
    private readonly IDailySalesRepository _repository;
    private readonly IInventoryCalculationService _calculationService;

    public DailySalesService(IDailySalesRepository repository, IInventoryCalculationService calculationService)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _calculationService = calculationService ?? throw new ArgumentNullException(nameof(calculationService));
    }

    public async Task<DailySalesViewModel> LoadDailySalesAsync(DateTime date)
    {
        var vm = await _repository.GetByDateAsync(date);

        // Recalculate all item rows & location totals on load to ensure consistency
        foreach (var item in vm.ItemDetails)
        {
            _calculationService.CalculateItemRow(item);
        }

        foreach (var loc in vm.LocationFinances)
        {
            if (!loc.LocationName.Equals("TOTAL", StringComparison.OrdinalIgnoreCase))
            {
                _calculationService.CalculateLocationRow(loc);
            }
        }
        _calculationService.RecalculateLocationTotals(vm.LocationFinances);

        var (totalSale, totalStockVal, _) = _calculationService.CalculateSummaryTotals(vm.ItemDetails);
        vm.Header.TotalSale = totalSale;
        vm.Header.TotalStockValue = totalStockVal;

        return vm;
    }

    public async Task<bool> SaveDailySalesAsync(DailySalesViewModel vm)
    {
        if (vm == null) throw new ArgumentNullException(nameof(vm));

        // Re-evaluate calculations before persisting
        foreach (var item in vm.ItemDetails)
        {
            _calculationService.CalculateItemRow(item);
        }

        foreach (var loc in vm.LocationFinances)
        {
            if (!loc.LocationName.Equals("TOTAL", StringComparison.OrdinalIgnoreCase))
            {
                _calculationService.CalculateLocationRow(loc);
            }
        }
        _calculationService.RecalculateLocationTotals(vm.LocationFinances);

        var (totalSale, totalStockVal, _) = _calculationService.CalculateSummaryTotals(vm.ItemDetails);
        vm.Header.TotalSale = totalSale;
        vm.Header.TotalStockValue = totalStockVal;

        return await _repository.SaveDailySalesAsync(vm.Header, vm.ItemDetails, vm.LocationFinances);
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _repository.GetCategoriesAsync();
    }

    public async Task<Item> AddItemAsync(Item item)
    {
        if (item == null || string.IsNullOrWhiteSpace(item.ItemName))
        {
            throw new ArgumentException("Item name cannot be empty.", nameof(item));
        }

        return await _repository.AddItemAsync(item);
    }

    public async Task<bool> DeleteItemAsync(int itemId)
    {
        if (itemId <= 0) return false;
        return await _repository.DeleteItemAsync(itemId);
    }

    public async Task<bool> UpdateItemCostPriceAsync(int itemId, decimal costPrice)
    {
        if (itemId <= 0 || costPrice < 0) return false;
        return await _repository.UpdateItemCostPriceAsync(itemId, costPrice);
    }

    public async Task<bool> UpdateItemMasterAsync(int itemId, string itemName, decimal price, decimal costPrice)
    {
        if (itemId <= 0 || string.IsNullOrWhiteSpace(itemName) || price < 0 || costPrice < 0) return false;
        return await _repository.UpdateItemMasterAsync(itemId, itemName, price, costPrice);
    }

    public async Task<bool> UpdateLocationNameAsync(int financeId, string newLocationName)
    {
        if (financeId <= 0 || string.IsNullOrWhiteSpace(newLocationName)) return false;
        return await _repository.UpdateLocationNameAsync(financeId, newLocationName);
    }
}
