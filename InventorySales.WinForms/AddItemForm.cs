using InventorySales.Core.Models;
using InventorySales.Services;

namespace InventorySales.WinForms;

public partial class AddItemForm : Form
{
    private readonly IDailySalesService _salesService;
    public Item? CreatedItem { get; private set; }

    public AddItemForm(IDailySalesService salesService)
    {
        InitializeComponent();
        _salesService = salesService ?? throw new ArgumentNullException(nameof(salesService));
        LoadCategories();
    }

    private async void LoadCategories()
    {
        try
        {
            var categories = await _salesService.GetCategoriesAsync();
            cmbCategory.DataSource = categories.ToList();
            cmbCategory.DisplayMember = nameof(Category.CategoryName);
            cmbCategory.ValueMember = nameof(Category.CategoryId);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to load categories: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnSave_Click(object sender, EventArgs e)
    {
        if (cmbCategory.SelectedItem is not Category selectedCategory)
        {
            MessageBox.Show("Please select a category.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string name = txtItemName.Text.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("Item Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtItemName.Focus();
            return;
        }

        decimal price = numPrice.Value;
        if (price < 0)
        {
            MessageBox.Show("Price cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            btnSave.Enabled = false;
            var newItem = new Item
            {
                CategoryId = selectedCategory.CategoryId,
                ItemName = name,
                Price = price,
                Category = selectedCategory
            };

            CreatedItem = await _salesService.AddItemAsync(newItem);
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error adding item: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnSave.Enabled = true;
        }
    }
}
