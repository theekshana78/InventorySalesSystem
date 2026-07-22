namespace InventorySales.WinForms;

partial class AddItemForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.lblHeader = new System.Windows.Forms.Label();
        this.lblCategory = new System.Windows.Forms.Label();
        this.cmbCategory = new System.Windows.Forms.ComboBox();
        this.lblItemName = new System.Windows.Forms.Label();
        this.txtItemName = new System.Windows.Forms.TextBox();
        this.lblPrice = new System.Windows.Forms.Label();
        this.numPrice = new System.Windows.Forms.NumericUpDown();
        this.btnSave = new System.Windows.Forms.Button();
        this.btnCancel = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
        this.SuspendLayout();
        // 
        // lblHeader
        // 
        this.lblHeader.AutoSize = true;
        this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
        this.lblHeader.Location = new System.Drawing.Point(24, 20);
        this.lblHeader.Name = "lblHeader";
        this.lblHeader.Size = new System.Drawing.Size(200, 28);
        this.lblHeader.TabIndex = 0;
        this.lblHeader.Text = "➕ Add New Inventory Item";
        // 
        // lblCategory
        // 
        this.lblCategory.AutoSize = true;
        this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblCategory.Location = new System.Drawing.Point(24, 70);
        this.lblCategory.Name = "lblCategory";
        this.lblCategory.Size = new System.Drawing.Size(77, 20);
        this.lblCategory.TabIndex = 1;
        this.lblCategory.Text = "Category:";
        // 
        // cmbCategory
        // 
        this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cmbCategory.FormattingEnabled = true;
        this.cmbCategory.Location = new System.Drawing.Point(28, 95);
        this.cmbCategory.Name = "cmbCategory";
        this.cmbCategory.Size = new System.Drawing.Size(340, 29);
        this.cmbCategory.TabIndex = 2;
        // 
        // lblItemName
        // 
        this.lblItemName.AutoSize = true;
        this.lblItemName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblItemName.Location = new System.Drawing.Point(24, 140);
        this.lblItemName.Name = "lblItemName";
        this.lblItemName.Size = new System.Drawing.Size(91, 20);
        this.lblItemName.TabIndex = 3;
        this.lblItemName.Text = "Item Name:";
        // 
        // txtItemName
        // 
        this.txtItemName.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtItemName.Location = new System.Drawing.Point(28, 165);
        this.txtItemName.Name = "txtItemName";
        this.txtItemName.Size = new System.Drawing.Size(340, 30);
        this.txtItemName.TabIndex = 4;
        // 
        // lblPrice
        // 
        this.lblPrice.AutoSize = true;
        this.lblPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblPrice.Location = new System.Drawing.Point(24, 210);
        this.lblPrice.Name = "lblPrice";
        this.lblPrice.Size = new System.Drawing.Size(120, 20);
        this.lblPrice.TabIndex = 5;
        this.lblPrice.Text = "Unit Price (Rs.):";
        // 
        // numPrice
        // 
        this.numPrice.DecimalPlaces = 2;
        this.numPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.numPrice.Location = new System.Drawing.Point(28, 235);
        this.numPrice.Maximum = new decimal(new int[] {
        100000,
        0,
        0,
        0});
        this.numPrice.Name = "numPrice";
        this.numPrice.Size = new System.Drawing.Size(340, 30);
        this.numPrice.TabIndex = 6;
        // 
        // btnSave
        // 
        this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
        this.btnSave.FlatAppearance.BorderSize = 0;
        this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnSave.ForeColor = System.Drawing.Color.White;
        this.btnSave.Location = new System.Drawing.Point(238, 295);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(130, 36);
        this.btnSave.TabIndex = 7;
        this.btnSave.Text = "Add Item";
        this.btnSave.UseVisualStyleBackColor = false;
        this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
        // 
        // btnCancel
        // 
        this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.btnCancel.FlatAppearance.BorderSize = 0;
        this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnCancel.ForeColor = System.Drawing.Color.White;
        this.btnCancel.Location = new System.Drawing.Point(122, 295);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(105, 36);
        this.btnCancel.TabIndex = 8;
        this.btnCancel.Text = "Cancel";
        this.btnCancel.UseVisualStyleBackColor = false;
        // 
        // AddItemForm
        // 
        this.AcceptButton = this.btnSave;
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.CancelButton = this.btnCancel;
        this.ClientSize = new System.Drawing.Size(395, 355);
        this.Controls.Add(this.btnCancel);
        this.Controls.Add(this.btnSave);
        this.Controls.Add(this.numPrice);
        this.Controls.Add(this.lblPrice);
        this.Controls.Add(this.txtItemName);
        this.Controls.Add(this.lblItemName);
        this.Controls.Add(this.cmbCategory);
        this.Controls.Add(this.lblCategory);
        this.Controls.Add(this.lblHeader);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "AddItemForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Add New Item";
        ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblHeader;
    private System.Windows.Forms.Label lblCategory;
    private System.Windows.Forms.ComboBox cmbCategory;
    private System.Windows.Forms.Label lblItemName;
    private System.Windows.Forms.TextBox txtItemName;
    private System.Windows.Forms.Label lblPrice;
    private System.Windows.Forms.NumericUpDown numPrice;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
}
