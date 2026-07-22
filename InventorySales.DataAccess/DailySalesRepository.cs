using System.Data;
using Dapper;
using InventorySales.Core.DTOs;
using InventorySales.Core.Models;

namespace InventorySales.DataAccess;

public interface IDailySalesRepository
{
    Task<DailySalesViewModel> GetByDateAsync(DateTime salesDate);
    Task<bool> SaveDailySalesAsync(DailySalesHeader header, IEnumerable<DailySalesItemDetail> details, IEnumerable<DailyLocationFinance> locations);
    Task<IEnumerable<Category>> GetCategoriesAsync();
    Task<Item> AddItemAsync(Item item);
    Task<bool> DeleteItemAsync(int itemId);
    Task<bool> UpdateItemCostPriceAsync(int itemId, decimal costPrice);
    Task<bool> UpdateItemMasterAsync(int itemId, string itemName, decimal price, decimal costPrice);
    Task<bool> UpdateLocationNameAsync(int financeId, string newLocationName);
}

public class DailySalesRepository : IDailySalesRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DailySalesRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
    }

    public async Task<DailySalesViewModel> GetByDateAsync(DateTime salesDate)
    {
        using var connection = _connectionFactory.CreateConnection();
        string dateStr = salesDate.ToString("yyyy-MM-dd");

        var viewModel = new DailySalesViewModel();

        // 1. Fetch Master Items
        const string masterItemsSql = @"
            SELECT 
                i.ItemId, i.ItemName, i.Price, i.CostPrice,
                c.CategoryName, c.ColorHex AS CategoryColorHex,
                c.DisplayOrder AS CategoryDisplayOrder, i.DisplayOrder AS ItemDisplayOrder
            FROM Items i
            INNER JOIN Categories c ON i.CategoryId = c.CategoryId
            WHERE i.IsActive = 1
            ORDER BY i.DisplayOrder ASC, i.ItemId ASC;";

        var masterItems = (await connection.QueryAsync<DailySalesItemDetail>(masterItemsSql)).ToList();

        // 2. Fetch Header if it exists
        const string headerSql = @"
            SELECT DailySalesHeaderId, SalesDate, TotalSale, Cash, TotalStockValue, Notes, CreatedAt, UpdatedAt
            FROM DailySalesHeaders
            WHERE SalesDate = @SalesDate;";

        var header = await connection.QueryFirstOrDefaultAsync<DailySalesHeader>(headerSql, new { SalesDate = dateStr });

        if (header != null)
        {
            viewModel.Header = header;

            // 3. Fetch existing saved details
            const string detailsSql = @"
                SELECT 
                    DetailId, DailySalesHeaderId, ItemId,
                    RoutineStock, NewStock, MainStock, IssueOut, Returned,
                    SaleQuantity, SaleValue, FinalStock, FinalStockValue, MySale
                FROM DailySalesItemDetails
                WHERE DailySalesHeaderId = @HeaderId;";

            var existingDetails = (await connection.QueryAsync<DailySalesItemDetail>(detailsSql, new { HeaderId = header.DailySalesHeaderId }))
                .ToDictionary(d => d.ItemId);

            viewModel.ItemDetails = masterItems.Select(m =>
            {
                if (existingDetails.TryGetValue(m.ItemId, out var saved))
                {
                    m.DetailId = saved.DetailId;
                    m.DailySalesHeaderId = saved.DailySalesHeaderId;
                    m.RoutineStock = saved.RoutineStock;
                    m.NewStock = saved.NewStock;
                    m.MainStock = saved.MainStock;
                    m.IssueOut = saved.IssueOut;
                    m.Returned = saved.Returned;
                    m.SaleQuantity = saved.SaleQuantity;
                    m.SaleValue = saved.SaleValue;
                    m.FinalStock = saved.FinalStock;
                    m.FinalStockValue = saved.FinalStockValue;
                    m.MySale = saved.MySale;
                }
                return m;
            }).ToList();

            // 4. Fetch existing location finance records
            const string locationSql = @"
                SELECT FinanceId, DailySalesHeaderId, LocationName, Bills, Cheques, EarlyCredits, Returned, Balance, DisplayOrder
                FROM DailyLocationFinance
                WHERE DailySalesHeaderId = @HeaderId
                ORDER BY DisplayOrder ASC;";

            var locations = await connection.QueryAsync<DailyLocationFinance>(locationSql, new { HeaderId = header.DailySalesHeaderId });
            viewModel.LocationFinances = locations.ToList();
        }
        else
        {
            viewModel.Header = new DailySalesHeader
            {
                SalesDate = salesDate.Date,
                TotalSale = 0,
                Cash = 0,
                TotalStockValue = 0
            };

            // Fetch previous day's final stocks if available
            const string prevDaySql = @"
                SELECT DailySalesHeaderId
                FROM DailySalesHeaders
                WHERE SalesDate < @SalesDate
                ORDER BY SalesDate DESC LIMIT 1;";

            var prevHeaderId = await connection.QueryFirstOrDefaultAsync<int?>(prevDaySql, new { SalesDate = dateStr });
            var prevFinalStocks = new Dictionary<int, decimal>();

            if (prevHeaderId.HasValue)
            {
                const string prevStocksSql = @"
                    SELECT ItemId, FinalStock
                    FROM DailySalesItemDetails
                    WHERE DailySalesHeaderId = @HeaderId;";

                var prevDetails = await connection.QueryAsync(prevStocksSql, new { HeaderId = prevHeaderId.Value });
                prevFinalStocks = prevDetails.ToDictionary(d => (int)d.ItemId, d => (decimal)d.FinalStock);
            }

            viewModel.ItemDetails = masterItems.Select(m =>
            {
                decimal routine = prevFinalStocks.TryGetValue(m.ItemId, out var stock) ? stock : 0;
                return new DailySalesItemDetail
                {
                    ItemId = m.ItemId,
                    ItemName = m.ItemName,
                    Price = m.Price,
                    CostPrice = m.CostPrice,
                    CategoryName = m.CategoryName,
                    CategoryColorHex = m.CategoryColorHex,
                    CategoryDisplayOrder = m.CategoryDisplayOrder,
                    ItemDisplayOrder = m.ItemDisplayOrder,
                    RoutineStock = routine,
                    NewStock = 0,
                    MainStock = routine,
                    IssueOut = 0,
                    Returned = 0,
                    SaleQuantity = 0,
                    SaleValue = 0,
                    FinalStock = routine,
                    FinalStockValue = routine * m.Price,
                    MySale = 0
                };
            }).ToList();

            viewModel.LocationFinances = GetDefaultLocations();
        }

        return viewModel;
    }

    public async Task<bool> SaveDailySalesAsync(
        DailySalesHeader header, 
        IEnumerable<DailySalesItemDetail> details, 
        IEnumerable<DailyLocationFinance> locations)
    {
        using var connection = _connectionFactory.CreateConnection();
        if (connection.State != ConnectionState.Open)
        {
            connection.Open();
        }

        using var transaction = connection.BeginTransaction();
        try
        {
            string dateStr = header.SalesDate.ToString("yyyy-MM-dd");

            // 1. Check if Header Exists
            const string checkHeaderSql = "SELECT DailySalesHeaderId FROM DailySalesHeaders WHERE SalesDate = @SalesDate;";
            int? existingId = await connection.QueryFirstOrDefaultAsync<int?>(checkHeaderSql, new { SalesDate = dateStr }, transaction);

            int headerId;
            if (existingId.HasValue)
            {
                headerId = existingId.Value;
                const string updateHeaderSql = @"
                    UPDATE DailySalesHeaders
                    SET TotalSale = @TotalSale,
                        Cash = @Cash,
                        TotalStockValue = @TotalStockValue,
                        Notes = @Notes,
                        UpdatedAt = datetime('now')
                    WHERE DailySalesHeaderId = @HeaderId;";

                await connection.ExecuteAsync(updateHeaderSql, new
                {
                    HeaderId = headerId,
                    header.TotalSale,
                    header.Cash,
                    header.TotalStockValue,
                    header.Notes
                }, transaction);
            }
            else
            {
                const string insertHeaderSql = @"
                    INSERT INTO DailySalesHeaders (SalesDate, TotalSale, Cash, TotalStockValue, Notes, CreatedAt, UpdatedAt)
                    VALUES (@SalesDate, @TotalSale, @Cash, @TotalStockValue, @Notes, datetime('now'), datetime('now'));
                    SELECT last_insert_rowid();";

                headerId = await connection.ExecuteScalarAsync<int>(insertHeaderSql, new
                {
                    SalesDate = dateStr,
                    header.TotalSale,
                    header.Cash,
                    header.TotalStockValue,
                    header.Notes
                }, transaction);
            }

            header.DailySalesHeaderId = headerId;

            // 2. Clear & Bulk Re-insert Item Details
            const string deleteDetailsSql = "DELETE FROM DailySalesItemDetails WHERE DailySalesHeaderId = @HeaderId;";
            await connection.ExecuteAsync(deleteDetailsSql, new { HeaderId = headerId }, transaction);

            const string insertDetailSql = @"
                INSERT INTO DailySalesItemDetails (
                    DailySalesHeaderId, ItemId, RoutineStock, NewStock, MainStock, 
                    IssueOut, Returned, SaleQuantity, SaleValue, FinalStock, FinalStockValue, MySale
                ) VALUES (
                    @DailySalesHeaderId, @ItemId, @RoutineStock, @NewStock, @MainStock,
                    @IssueOut, @Returned, @SaleQuantity, @SaleValue, @FinalStock, @FinalStockValue, @MySale
                );";

            var detailParams = details.Select(d => new
            {
                DailySalesHeaderId = headerId,
                d.ItemId,
                d.RoutineStock,
                d.NewStock,
                d.MainStock,
                d.IssueOut,
                d.Returned,
                d.SaleQuantity,
                d.SaleValue,
                d.FinalStock,
                d.FinalStockValue,
                d.MySale
            });

            await connection.ExecuteAsync(insertDetailSql, detailParams, transaction);

            // 3. Clear & Bulk Re-insert Location Finances
            const string deleteLocationsSql = "DELETE FROM DailyLocationFinance WHERE DailySalesHeaderId = @HeaderId;";
            await connection.ExecuteAsync(deleteLocationsSql, new { HeaderId = headerId }, transaction);

            const string insertLocationSql = @"
                INSERT INTO DailyLocationFinance (
                    DailySalesHeaderId, LocationName, Bills, Cheques, EarlyCredits, Returned, Balance, DisplayOrder
                ) VALUES (
                    @DailySalesHeaderId, @LocationName, @Bills, @Cheques, @EarlyCredits, @Returned, @Balance, @DisplayOrder
                );";

            int order = 1;
            var locationParams = locations.Select(l => new
            {
                DailySalesHeaderId = headerId,
                l.LocationName,
                l.Bills,
                l.Cheques,
                l.EarlyCredits,
                l.Returned,
                l.Balance,
                DisplayOrder = order++
            });

            await connection.ExecuteAsync(insertLocationSql, locationParams, transaction);

            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "SELECT CategoryId, CategoryName, ColorHex, DisplayOrder FROM Categories ORDER BY DisplayOrder ASC;";
        return await connection.QueryAsync<Category>(sql);
    }

    public async Task<Item> AddItemAsync(Item item)
    {
        using var connection = _connectionFactory.CreateConnection();

        if (item.DisplayOrder == 0)
        {
            int maxOrder = await connection.ExecuteScalarAsync<int>("SELECT IFNULL(MAX(DisplayOrder), 0) FROM Items WHERE CategoryId = @CategoryId;", new { item.CategoryId });
            item.DisplayOrder = maxOrder + 1;
        }

        const string sql = @"
            INSERT INTO Items (CategoryId, ItemName, Price, CostPrice, DisplayOrder, IsActive)
            VALUES (@CategoryId, @ItemName, @Price, @CostPrice, @DisplayOrder, 1);
            SELECT last_insert_rowid();";

        int newItemId = await connection.ExecuteScalarAsync<int>(sql, new
        {
            item.CategoryId,
            item.ItemName,
            item.Price,
            item.CostPrice,
            item.DisplayOrder
        });

        item.ItemId = newItemId;
        return item;
    }

    public async Task<bool> DeleteItemAsync(int itemId)
    {
        using var connection = _connectionFactory.CreateConnection();
        if (connection.State != ConnectionState.Open) connection.Open();
        using var transaction = connection.BeginTransaction();

        try
        {
            const string deleteDetailsSql = "DELETE FROM DailySalesItemDetails WHERE ItemId = @ItemId;";
            await connection.ExecuteAsync(deleteDetailsSql, new { ItemId = itemId }, transaction);

            const string deleteItemSql = "DELETE FROM Items WHERE ItemId = @ItemId;";
            int rows = await connection.ExecuteAsync(deleteItemSql, new { ItemId = itemId }, transaction);

            transaction.Commit();
            return rows > 0;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public async Task<bool> UpdateItemCostPriceAsync(int itemId, decimal costPrice)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = "UPDATE Items SET CostPrice = @CostPrice WHERE ItemId = @ItemId;";
        int rows = await connection.ExecuteAsync(sql, new { ItemId = itemId, CostPrice = costPrice });
        return rows > 0;
    }

    public async Task<bool> UpdateItemMasterAsync(int itemId, string itemName, decimal price, decimal costPrice)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            UPDATE Items 
            SET ItemName = @ItemName, Price = @Price, CostPrice = @CostPrice 
            WHERE ItemId = @ItemId;";
        int rows = await connection.ExecuteAsync(sql, new { ItemId = itemId, ItemName = itemName, Price = price, CostPrice = costPrice });
        return rows > 0;
    }

    public async Task<bool> UpdateLocationNameAsync(int financeId, string newLocationName)
    {
        using var connection = _connectionFactory.CreateConnection();
        const string sql = @"
            UPDATE DailyLocationFinance 
            SET LocationName = @LocationName 
            WHERE FinanceId = @FinanceId;";
        int rows = await connection.ExecuteAsync(sql, new { FinanceId = financeId, LocationName = newLocationName });
        return rows > 0;
    }

    private static List<DailyLocationFinance> GetDefaultLocations()
    {
        var fixedLocations = new string[]
        {
            "Badulla", "Bandarawela", "Attampitiya", "Welimada",
            "Udupussalla", "Kumara", "Cheques", "TOTAL"
        };

        return fixedLocations.Select((loc, index) => new DailyLocationFinance
        {
            LocationName = loc,
            Bills = 0,
            Cheques = 0,
            EarlyCredits = 0,
            Returned = 0,
            Balance = 0,
            DisplayOrder = index + 1
        }).ToList();
    }
}
