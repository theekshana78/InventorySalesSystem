using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using InventorySales.Core.DTOs;
using InventorySales.Core.Models;
using InventorySales.Services;
using InventorySales.WinForms.Helpers;

namespace InventorySales.WinForms;

public partial class MainForm : Form
{
    private readonly IDailySalesService _salesService;
    private readonly IInventoryCalculationService _calculationService;
    private DailySalesViewModel _viewModel = new();
    private BindingList<DailySalesItemDetail> _inventoryBindingList = new();
    private BindingList<DailyLocationFinance> _locationBindingList = new();
    private bool _isCalculating = false;

    // Column Names for Main Inventory Grid
    private const string ColCategory = "CategoryName";
    private const string ColItemName = "ItemName";
    private const string ColPrice = "Price";
    private const string ColRoutineStock = "RoutineStock";
    private const string ColNewStock = "NewStock";
    private const string ColMainStock = "MainStock";
    private const string ColIssueOut = "IssueOut";
    private const string ColReturned = "Returned";
    private const string ColSaleQuantity = "SaleQuantity";
    private const string ColSaleValue = "SaleValue";
    private const string ColFinalStock = "FinalStock";
    private const string ColFinalStockValue = "FinalStockValue";
    private const string ColMySale = "MySale";
    private const string ColMySaleValue = "MySaleValue";

    // Column Names for Location Finance Grid
    private const string ColLocationName = "LocationName";
    private const string ColBills = "Bills";
    private const string ColCheques = "Cheques";
    private const string ColEarlyCredits = "EarlyCredits";
    private const string ColLocReturned = "Returned";
    private const string ColBalance = "Balance";

    public MainForm(IDailySalesService salesService, IInventoryCalculationService calculationService)
    {
        InitializeComponent();
        _salesService = salesService ?? throw new ArgumentNullException(nameof(salesService));
        _calculationService = calculationService ?? throw new ArgumentNullException(nameof(calculationService));
        this.WindowState = FormWindowState.Maximized;
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        SetupGrids();
        await LoadDataForSelectedDateAsync();
    }

    private void SetupGrids()
    {
        // --------------------------------------------------------------------
        // 1. Setup Page 1: Main Inventory DataGridView
        // --------------------------------------------------------------------
        GridStylingHelper.ApplyExcelTheme(dgvInventory);
        dgvInventory.AutoGenerateColumns = false;
        dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvInventory.Columns.Clear();

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColItemName,
            DataPropertyName = nameof(DailySalesItemDetail.ItemName),
            HeaderText = "Item Name",
            FillWeight = 130,
            ReadOnly = false,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 10F, FontStyle.Bold) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColPrice,
            DataPropertyName = nameof(DailySalesItemDetail.Price),
            HeaderText = "Price (Rs.)",
            FillWeight = 65,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColRoutineStock,
            DataPropertyName = nameof(DailySalesItemDetail.RoutineStock),
            HeaderText = "Routine Stock",
            FillWeight = 75,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(255, 255, 255) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColNewStock,
            DataPropertyName = nameof(DailySalesItemDetail.NewStock),
            HeaderText = "New",
            FillWeight = 60,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(255, 255, 255) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColMainStock,
            DataPropertyName = nameof(DailySalesItemDetail.MainStock),
            HeaderText = "Main Stock",
            FillWeight = 75,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(241, 245, 249), Font = new Font("Segoe UI", 10F, FontStyle.Bold) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColIssueOut,
            DataPropertyName = nameof(DailySalesItemDetail.IssueOut),
            HeaderText = "Issue Out",
            FillWeight = 65,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(255, 255, 255) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColReturned,
            DataPropertyName = nameof(DailySalesItemDetail.Returned),
            HeaderText = "Returned",
            FillWeight = 65,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(255, 255, 255) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColSaleQuantity,
            DataPropertyName = nameof(DailySalesItemDetail.SaleQuantity),
            HeaderText = "Sale Qty",
            FillWeight = 70,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(241, 245, 249), Font = new Font("Segoe UI", 10F, FontStyle.Bold) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColSaleValue,
            DataPropertyName = nameof(DailySalesItemDetail.SaleValue),
            HeaderText = "Sale Value (Rs.)",
            FillWeight = 100,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(236, 253, 245), Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(4, 120, 87) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColMySale,
            DataPropertyName = nameof(DailySalesItemDetail.MySale),
            HeaderText = "My Sale Qty",
            FillWeight = 85,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(255, 255, 255) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColMySaleValue,
            DataPropertyName = nameof(DailySalesItemDetail.MySaleValue),
            HeaderText = "My Sale Value (Rs.)",
            FillWeight = 150,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(236, 253, 245), Font = new Font("Segoe UI", 10.5F, FontStyle.Bold), ForeColor = Color.FromArgb(4, 120, 87) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColFinalStock,
            DataPropertyName = nameof(DailySalesItemDetail.FinalStock),
            HeaderText = "Final Stock",
            FillWeight = 110,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(241, 245, 249), Font = new Font("Segoe UI", 10.5F, FontStyle.Bold) }
        });

        dgvInventory.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColFinalStockValue,
            DataPropertyName = nameof(DailySalesItemDetail.FinalStockValue),
            HeaderText = "Final Stock Value (Rs.)",
            FillWeight = 190,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(238, 242, 255), Font = new Font("Segoe UI", 10.5F, FontStyle.Bold), ForeColor = Color.FromArgb(67, 56, 202) }
        });

        // Wire Grid Events
        dgvInventory.CellValueChanged += DgvInventory_CellValueChanged;
        dgvInventory.CellFormatting += DgvInventory_CellFormatting;

        // --------------------------------------------------------------------
        // 2. Setup Page 2: Location Finance DataGridView
        // --------------------------------------------------------------------
        GridStylingHelper.ApplyExcelTheme(dgvLocationFinance);
        dgvLocationFinance.AutoGenerateColumns = false;
        dgvLocationFinance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvLocationFinance.Columns.Clear();

        dgvLocationFinance.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColLocationName,
            DataPropertyName = nameof(DailyLocationFinance.LocationName),
            HeaderText = "Location / Collection Area",
            FillWeight = 160,
            ReadOnly = false,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) }
        });

        dgvLocationFinance.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColBills,
            DataPropertyName = nameof(DailyLocationFinance.Bills),
            HeaderText = "Bills (Rs.)",
            FillWeight = 110,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvLocationFinance.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColCheques,
            DataPropertyName = nameof(DailyLocationFinance.Cheques),
            HeaderText = "Cheques (Rs.)",
            FillWeight = 110,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvLocationFinance.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColEarlyCredits,
            DataPropertyName = nameof(DailyLocationFinance.EarlyCredits),
            HeaderText = "Early Credits (Rs.)",
            FillWeight = 110,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvLocationFinance.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColLocReturned,
            DataPropertyName = nameof(DailyLocationFinance.Returned),
            HeaderText = "Returned (Rs.)",
            FillWeight = 110,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvLocationFinance.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = ColBalance,
            DataPropertyName = nameof(DailyLocationFinance.Balance),
            HeaderText = "Balance (Rs.)",
            FillWeight = 130,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), BackColor = Color.FromArgb(241, 245, 249) }
        });

        // Wire Location Finance Events
        dgvLocationFinance.CellValueChanged += DgvLocationFinance_CellValueChanged;
        dgvLocationFinance.CellFormatting += DgvLocationFinance_CellFormatting;

        // Wire Cash Input
        txtCashInput.TextChanged += TxtCashInput_TextChanged;

        // --------------------------------------------------------------------
        // 3. Setup Page 3: Profit & Margin Analysis DataGridView
        // --------------------------------------------------------------------
        GridStylingHelper.ApplyExcelTheme(dgvProfit);
        dgvProfit.AutoGenerateColumns = false;
        dgvProfit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProfit.Columns.Clear();

        dgvProfit.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "ProfItemName",
            DataPropertyName = nameof(DailySalesItemDetail.ItemName),
            HeaderText = "Item Name",
            FillWeight = 160,
            ReadOnly = false,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) }
        });

        dgvProfit.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "ProfPrice",
            DataPropertyName = nameof(DailySalesItemDetail.Price),
            HeaderText = "Selling Price (Rs.)",
            FillWeight = 100,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvProfit.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "ProfCostPrice",
            DataPropertyName = nameof(DailySalesItemDetail.CostPrice),
            HeaderText = "Cost Price (Rs.)",
            FillWeight = 100,
            ReadOnly = false,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(255, 255, 255) }
        });

        dgvProfit.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "ProfUnitProfit",
            DataPropertyName = nameof(DailySalesItemDetail.UnitProfit),
            HeaderText = "Unit Profit (Rs.)",
            FillWeight = 100,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), ForeColor = Color.FromArgb(4, 120, 87) }
        });

        dgvProfit.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "ProfTotalQtySold",
            DataPropertyName = nameof(DailySalesItemDetail.TotalQtySold),
            HeaderText = "Qty Sold",
            FillWeight = 85,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(241, 245, 249) }
        });

        dgvProfit.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "ProfTotalCost",
            DataPropertyName = nameof(DailySalesItemDetail.TotalCost),
            HeaderText = "Total Cost (Rs.)",
            FillWeight = 110,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, ForeColor = Color.FromArgb(239, 68, 68) }
        });

        dgvProfit.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "ProfTotalRevenue",
            DataPropertyName = nameof(DailySalesItemDetail.TotalRevenue),
            HeaderText = "Total Revenue (Rs.)",
            FillWeight = 120,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvProfit.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "ProfNetProfit",
            DataPropertyName = nameof(DailySalesItemDetail.NetProfit),
            HeaderText = "Net Profit (Rs.)",
            FillWeight = 120,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(236, 253, 245), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), ForeColor = Color.FromArgb(4, 120, 87) }
        });

        dgvProfit.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "ProfMarginPercentage",
            DataPropertyName = nameof(DailySalesItemDetail.ProfitMarginPercentage),
            HeaderText = "Profit Margin %",
            FillWeight = 100,
            ReadOnly = true,
            DefaultCellStyle = { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), ForeColor = Color.FromArgb(67, 56, 202) }
        });

        dgvProfit.CellValueChanged += DgvProfit_CellValueChanged;
    }

    private async Task LoadDataForSelectedDateAsync()
    {
        try
        {
            lblStatusMessage.Text = $"Loading daily tracking data for {dtpSalesDate.Value:yyyy-MM-dd}...";
            _viewModel = await _salesService.LoadDailySalesAsync(dtpSalesDate.Value);

            _inventoryBindingList = new BindingList<DailySalesItemDetail>(_viewModel.ItemDetails);
            dgvInventory.DataSource = _inventoryBindingList;
            dgvProfit.DataSource = _inventoryBindingList;

            _locationBindingList = new BindingList<DailyLocationFinance>(_viewModel.LocationFinances);
            dgvLocationFinance.DataSource = _locationBindingList;

            txtCashInput.Text = _viewModel.Header.Cash.ToString("N2");
            UpdateSummaryCardLabels();

            lblStatusMessage.Text = $"Data loaded successfully. ({_viewModel.ItemDetails.Count} active inventory items)";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading daily sales: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatusMessage.Text = "Error loading data from SQL Server.";
        }
    }

    // ------------------------------------------------------------------------
    // PAGE 1: Item Management (Add & Delete Items)
    // ------------------------------------------------------------------------
    private void btnAddItem_Click(object sender, EventArgs e)
    {
        using var addForm = new AddItemForm(_salesService);
        if (addForm.ShowDialog(this) == DialogResult.OK && addForm.CreatedItem != null)
        {
            var newItem = addForm.CreatedItem;

            var newDetailRow = new DailySalesItemDetail
            {
                ItemId = newItem.ItemId,
                ItemName = newItem.ItemName,
                Price = newItem.Price,
                CategoryName = newItem.Category?.CategoryName ?? "General",
                CategoryColorHex = newItem.Category?.ColorHex ?? "#FFFFFF",
                RoutineStock = 0,
                NewStock = 0,
                MainStock = 0,
                IssueOut = 0,
                Returned = 0,
                SaleQuantity = 0,
                SaleValue = 0,
                FinalStock = 0,
                FinalStockValue = 0,
                MySale = 0
            };

            _inventoryBindingList.Add(newDetailRow);
            UpdateSummaryCardLabels();

            // Highlight newly added row
            int newRowIdx = _inventoryBindingList.Count - 1;
            dgvInventory.ClearSelection();
            if (newRowIdx >= 0 && newRowIdx < dgvInventory.Rows.Count)
            {
                dgvInventory.Rows[newRowIdx].Selected = true;
                dgvInventory.FirstDisplayedScrollingRowIndex = newRowIdx;
            }

            lblStatusMessage.Text = $"✅ New item '{newItem.ItemName}' added successfully!";
        }
    }

    private async void btnDeleteItem_Click(object sender, EventArgs e)
    {
        if (dgvInventory.CurrentRow == null || dgvInventory.CurrentRow.Index < 0 || dgvInventory.CurrentRow.Index >= _inventoryBindingList.Count)
        {
            MessageBox.Show("Please select an item row to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var selectedDetail = _inventoryBindingList[dgvInventory.CurrentRow.Index];

        var result = MessageBox.Show(
            $"Are you sure you want to delete '{selectedDetail.ItemName}'?\n\nThis will remove the item from the master catalog and current daily tracking sheet.",
            "Confirm Delete Item",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (result == DialogResult.Yes)
        {
            try
            {
                lblStatusMessage.Text = $"Deleting '{selectedDetail.ItemName}'...";
                bool deleted = await _salesService.DeleteItemAsync(selectedDetail.ItemId);

                if (deleted)
                {
                    _inventoryBindingList.Remove(selectedDetail);
                    UpdateSummaryCardLabels();
                    lblStatusMessage.Text = $"✅ Item '{selectedDetail.ItemName}' deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete item: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatusMessage.Text = "Error deleting item.";
            }
        }
    }

    // ------------------------------------------------------------------------
    // Real-Time Inventory Auto-Calculation Engine (CellValueChanged)
    // ------------------------------------------------------------------------
    private async void DgvInventory_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (_isCalculating || e.RowIndex < 0 || e.RowIndex >= _inventoryBindingList.Count) return;

        var editedCol = dgvInventory.Columns[e.ColumnIndex].Name;
        var item = _inventoryBindingList[e.RowIndex];

        _isCalculating = true;
        try
        {
            if (editedCol == ColItemName || editedCol == ColPrice)
            {
                await _salesService.UpdateItemMasterAsync(item.ItemId, item.ItemName, item.Price, item.CostPrice);
            }

            if (editedCol == ColRoutineStock || editedCol == ColNewStock ||
                editedCol == ColIssueOut || editedCol == ColReturned || editedCol == ColPrice || editedCol == ColMySale || editedCol == ColItemName)
            {
                _calculationService.CalculateItemRow(item);
                dgvInventory.InvalidateRow(e.RowIndex);
                dgvProfit.Refresh();
                UpdateSummaryCardLabels();
            }
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = $"Error updating item: {ex.Message}";
        }
        finally
        {
            _isCalculating = false;
        }
    }

    private void DgvInventory_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= _inventoryBindingList.Count) return;

        var item = _inventoryBindingList[e.RowIndex];
        var categoryColor = GridStylingHelper.HexToColor(item.CategoryColorHex, Color.White);

        if (dgvInventory.Columns[e.ColumnIndex].Name == ColCategory ||
            dgvInventory.Columns[e.ColumnIndex].Name == ColItemName)
        {
            e.CellStyle!.BackColor = categoryColor;
        }
    }

    // ------------------------------------------------------------------------
    // Location Finance Auto-Calculation Engine (Page 2)
    // ------------------------------------------------------------------------
    private async void DgvLocationFinance_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (_isCalculating || e.RowIndex < 0 || e.RowIndex >= _locationBindingList.Count) return;

        var item = _locationBindingList[e.RowIndex];
        if (item.LocationName.Equals("TOTAL", StringComparison.OrdinalIgnoreCase)) return;

        var editedCol = dgvLocationFinance.Columns[e.ColumnIndex].Name;

        _isCalculating = true;
        try
        {
            if (editedCol == ColLocationName && item.FinanceId > 0)
            {
                await _salesService.UpdateLocationNameAsync(item.FinanceId, item.LocationName);
            }

            _calculationService.CalculateLocationRow(item);
            _calculationService.RecalculateLocationTotals(_viewModel.LocationFinances);
            dgvLocationFinance.Refresh();
            UpdateSummaryCardLabels();
        }
        catch (Exception ex)
        {
            lblStatusMessage.Text = $"Error updating location: {ex.Message}";
        }
        finally
        {
            _isCalculating = false;
        }
    }

    private void DgvLocationFinance_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= _locationBindingList.Count) return;

        var loc = _locationBindingList[e.RowIndex];

        if (loc.LocationName.Equals("TOTAL", StringComparison.OrdinalIgnoreCase))
        {
            e.CellStyle!.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            e.CellStyle.BackColor = Color.FromArgb(30, 41, 59);
            e.CellStyle.ForeColor = Color.White;
        }
    }

    private void TxtCashInput_TextChanged(object? sender, EventArgs e)
    {
        if (decimal.TryParse(txtCashInput.Text, out decimal cashVal))
        {
            _viewModel.Header.Cash = cashVal;
        }
    }

    private async void DgvProfit_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (_isCalculating || e.RowIndex < 0 || e.RowIndex >= _inventoryBindingList.Count) return;

        var editedCol = dgvProfit.Columns[e.ColumnIndex].Name;
        var item = _inventoryBindingList[e.RowIndex];

        if (editedCol == "ProfCostPrice" || editedCol == "ProfItemName" || editedCol == "ProfPrice")
        {
            _isCalculating = true;
            try
            {
                await _salesService.UpdateItemMasterAsync(item.ItemId, item.ItemName, item.Price, item.CostPrice);
                _calculationService.CalculateItemRow(item);
                dgvInventory.Refresh();
                dgvProfit.InvalidateRow(e.RowIndex);
                UpdateSummaryCardLabels();
            }
            catch (Exception ex)
            {
                lblStatusMessage.Text = $"Error updating profit item: {ex.Message}";
            }
            finally
            {
                _isCalculating = false;
            }
        }
    }

    private void UpdateSummaryCardLabels()
    {
        // Page 1 Metrics
        var (totalSale, totalStockVal, totalMySaleVal) = _calculationService.CalculateSummaryTotals(_inventoryBindingList);
        _viewModel.Header.TotalSale = totalSale;
        _viewModel.Header.TotalStockValue = totalStockVal;

        lblTotalSaleValue.Text = $"Rs. {totalSale:N2}";
        lblTotalMySaleValue.Text = $"Rs. {totalMySaleVal:N2}";
        lblTotalStockValue.Text = $"Rs. {totalStockVal:N2}";
        lblItemCountValue.Text = $"{_inventoryBindingList.Count} Items";

        // Page 2 Metrics
        var totalRow = _locationBindingList.FirstOrDefault(l => l.LocationName.Equals("TOTAL", StringComparison.OrdinalIgnoreCase));
        if (totalRow != null)
        {
            lblTotalBillsVal.Text = $"Rs. {totalRow.Bills:N2}";
            lblTotalChequesVal.Text = $"Rs. {totalRow.Cheques:N2}";
            lblTotalBalanceVal.Text = $"Rs. {totalRow.Balance:N2}";
        }

        // Page 3 Profit Metrics
        decimal totalRevenue = _inventoryBindingList.Sum(i => i.TotalRevenue);
        decimal totalCost = _inventoryBindingList.Sum(i => i.TotalCost);
        decimal totalNetProfit = totalRevenue - totalCost;
        decimal overallMargin = totalCost > 0 ? (totalNetProfit / totalCost) * 100m : 0m;

        lblTotalRevenueVal.Text = $"Rs. {totalRevenue:N2}";
        lblTotalCostVal.Text = $"Rs. {totalCost:N2}";
        lblTotalNetProfitVal.Text = $"Rs. {totalNetProfit:N2}";
        lblOverallMarginVal.Text = $"{overallMargin:N2}%";
    }

    private async void btnSaveAll_Click(object sender, EventArgs e)
    {
        try
        {
            btnSaveAll.Enabled = false;
            lblStatusMessage.Text = "Saving system data (Page 1 Inventory & Page 2 Location Finance)...";

            bool success = await _salesService.SaveDailySalesAsync(_viewModel);
            if (success)
            {
                lblStatusMessage.Text = $"✅ System records saved successfully for date {_viewModel.Header.SalesDate:yyyy-MM-dd} at {DateTime.Now:HH:mm:ss}.";
                MessageBox.Show("All daily inventory and location finance records saved successfully to SQL Server DB!", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to save daily records: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatusMessage.Text = "Error saving data.";
        }
        finally
        {
            btnSaveAll.Enabled = true;
        }
    }

    private async void btnRefresh_Click(object sender, EventArgs e)
    {
        await LoadDataForSelectedDateAsync();
    }

    private async void dtpSalesDate_ValueChanged(object sender, EventArgs e)
    {
        await LoadDataForSelectedDateAsync();
    }
}
