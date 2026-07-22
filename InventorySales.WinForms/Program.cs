using System.IO;
using System.Text.Json;
using Microsoft.Data.Sqlite;
using InventorySales.DataAccess;
using InventorySales.Services;

namespace InventorySales.WinForms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // 1. Default SQLite Connection String
        string connectionString = "Data Source=InventorySales.db";

        // 2. Read dynamic connection string from appsettings.json if present
        string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
        if (File.Exists(configPath))
        {
            try
            {
                string json = File.ReadAllText(configPath);
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("ConnectionString", out var connProp) && !string.IsNullOrWhiteSpace(connProp.GetString()))
                {
                    connectionString = connProp.GetString()!;
                }
            }
            catch { }
        }

        // 3. Auto-Create SQLite Database & Tables if missing
        EnsureSqliteDatabaseCreated(connectionString);

        // 4. Instantiate N-Tier Architecture Dependencies with SqliteConnectionFactory
        IDbConnectionFactory connectionFactory = new SqliteConnectionFactory(connectionString);
        IDailySalesRepository repository = new DailySalesRepository(connectionFactory);
        IInventoryCalculationService calculationService = new InventoryCalculationService();
        IDailySalesService salesService = new DailySalesService(repository, calculationService);

        // 5. Launch Main WinForms Application Form
        Application.Run(new MainForm(salesService, calculationService));
    }

    private static void EnsureSqliteDatabaseCreated(string connectionString)
    {
        try
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                // Enable PRAGMA foreign_keys = ON;
                using var pragmaCmd = new SqliteCommand("PRAGMA foreign_keys = ON;", conn);
                pragmaCmd.ExecuteNonQuery();

                // Check if Items table exists
                using var checkCmd = new SqliteCommand("SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='Items';", conn);
                int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (count == 0)
                {
                    string schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sqlite_schema.sql");
                    if (!File.Exists(schemaPath))
                    {
                        schemaPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "schema.sql");
                    }

                    if (File.Exists(schemaPath))
                    {
                        string script = File.ReadAllText(schemaPath);
                        using var scriptCmd = new SqliteCommand(script, conn);
                        scriptCmd.ExecuteNonQuery();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"SQLite Auto-Init Notice: {ex.Message}");
        }
    }
}