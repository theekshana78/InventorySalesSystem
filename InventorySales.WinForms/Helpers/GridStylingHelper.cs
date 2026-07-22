using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace InventorySales.WinForms.Helpers;

public static class GridStylingHelper
{
    public static void EnableDoubleBuffering(this DataGridView grid)
    {
        typeof(DataGridView)
            .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)?
            .SetValue(grid, true, null);
    }

    public static void EnableSmoothScrolling(this DataGridView grid, int rowsPerScroll = 3)
    {
        grid.EnableDoubleBuffering();
        grid.MouseWheel += (sender, e) =>
        {
            if (e.Delta != 0 && grid.RowCount > 0)
            {
                try
                {
                    int currentIndex = grid.FirstDisplayedScrollingRowIndex;
                    if (currentIndex >= 0)
                    {
                        int scrollAmount = e.Delta > 0 ? -rowsPerScroll : rowsPerScroll;
                        int newIndex = Math.Max(0, Math.Min(grid.RowCount - 1, currentIndex + scrollAmount));
                        grid.FirstDisplayedScrollingRowIndex = newIndex;
                    }
                }
                catch { }
            }
        };
    }

    public static void ApplyExcelTheme(DataGridView grid)
    {
        grid.EnableDoubleBuffering();
        grid.EnableSmoothScrolling(3);
        grid.BackgroundColor = Color.FromArgb(248, 249, 250);
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.GridColor = Color.FromArgb(226, 232, 240);

        // Header Styling
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        grid.ColumnHeadersHeight = 42;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59); // Slate Dark
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        // Rows Styling
        grid.RowTemplate.Height = 38;
        grid.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
        grid.DefaultCellStyle.ForeColor = Color.FromArgb(15, 23, 42);
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(199, 210, 254);
        grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 23, 42);

        grid.RowHeadersVisible = false;
        grid.RowHeadersWidth = 42;
        grid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.SelectionMode = DataGridViewSelectionMode.CellSelect;
    }

    public static Color HexToColor(string hexColor, Color fallback)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(hexColor)) return fallback;
            if (!hexColor.StartsWith("#")) hexColor = "#" + hexColor;
            return ColorTranslator.FromHtml(hexColor);
        }
        catch
        {
            return fallback;
        }
    }
}
