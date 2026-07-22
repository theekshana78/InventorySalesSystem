namespace InventorySales.WinForms;

partial class MainForm
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
        this.pnlTopHeader = new System.Windows.Forms.Panel();
        this.lblAppTitle = new System.Windows.Forms.Label();
        this.dtpSalesDate = new System.Windows.Forms.DateTimePicker();
        this.btnSaveAll = new System.Windows.Forms.Button();
        this.btnRefresh = new System.Windows.Forms.Button();

        this.tabControlMain = new System.Windows.Forms.TabControl();
        this.tabInventory = new System.Windows.Forms.TabPage();
        this.tabLocationFinance = new System.Windows.Forms.TabPage();
        this.tabProfit = new System.Windows.Forms.TabPage();

        // --- Page 1 Components ---
        this.pnlSummaryCardsPage1 = new System.Windows.Forms.TableLayoutPanel();
        this.pnlCardTotalSale = new System.Windows.Forms.Panel();
        this.lblTotalSaleValue = new System.Windows.Forms.Label();
        this.lblTotalSaleTitle = new System.Windows.Forms.Label();
        
        this.pnlCardMySaleVal = new System.Windows.Forms.Panel();
        this.lblTotalMySaleValue = new System.Windows.Forms.Label();
        this.lblMySaleTitle = new System.Windows.Forms.Label();

        this.pnlCardStockVal = new System.Windows.Forms.Panel();
        this.lblTotalStockValue = new System.Windows.Forms.Label();
        this.lblTotalStockTitle = new System.Windows.Forms.Label();

        this.pnlCardItemCount = new System.Windows.Forms.Panel();
        this.lblItemCountValue = new System.Windows.Forms.Label();
        this.lblItemCountTitle = new System.Windows.Forms.Label();

        this.btnAddItem = new System.Windows.Forms.Button();
        this.btnDeleteItem = new System.Windows.Forms.Button();
        this.dgvInventory = new System.Windows.Forms.DataGridView();

        // --- Page 2 Components ---
        this.pnlSummaryCardsPage2 = new System.Windows.Forms.TableLayoutPanel();
        this.pnlCardBills = new System.Windows.Forms.Panel();
        this.lblTotalBillsVal = new System.Windows.Forms.Label();
        this.lblBillsTitle = new System.Windows.Forms.Label();

        this.pnlCardCheques = new System.Windows.Forms.Panel();
        this.lblTotalChequesVal = new System.Windows.Forms.Label();
        this.lblChequesTitle = new System.Windows.Forms.Label();

        this.pnlCardCash = new System.Windows.Forms.Panel();
        this.txtCashInput = new System.Windows.Forms.TextBox();
        this.lblCashTitle = new System.Windows.Forms.Label();

        this.pnlCardBalance = new System.Windows.Forms.Panel();
        this.lblTotalBalanceVal = new System.Windows.Forms.Label();
        this.lblBalanceTitle = new System.Windows.Forms.Label();

        this.dgvLocationFinance = new System.Windows.Forms.DataGridView();

        // --- Page 3 Components ---
        this.pnlSummaryCardsPage3 = new System.Windows.Forms.TableLayoutPanel();
        this.pnlCardRevenue = new System.Windows.Forms.Panel();
        this.lblTotalRevenueVal = new System.Windows.Forms.Label();
        this.lblRevenueTitle = new System.Windows.Forms.Label();

        this.pnlCardCost = new System.Windows.Forms.Panel();
        this.lblTotalCostVal = new System.Windows.Forms.Label();
        this.lblCostTitle = new System.Windows.Forms.Label();

        this.pnlCardNetProfit = new System.Windows.Forms.Panel();
        this.lblTotalNetProfitVal = new System.Windows.Forms.Label();
        this.lblNetProfitTitle = new System.Windows.Forms.Label();

        this.pnlCardMargin = new System.Windows.Forms.Panel();
        this.lblOverallMarginVal = new System.Windows.Forms.Label();
        this.lblMarginTitle = new System.Windows.Forms.Label();

        this.dgvProfit = new System.Windows.Forms.DataGridView();

        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.lblStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();

        this.pnlTopHeader.SuspendLayout();
        this.tabControlMain.SuspendLayout();
        this.tabInventory.SuspendLayout();
        this.pnlSummaryCardsPage1.SuspendLayout();
        this.pnlCardTotalSale.SuspendLayout();
        this.pnlCardMySaleVal.SuspendLayout();
        this.pnlCardStockVal.SuspendLayout();
        this.pnlCardItemCount.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();

        this.tabLocationFinance.SuspendLayout();
        this.pnlSummaryCardsPage2.SuspendLayout();
        this.pnlCardBills.SuspendLayout();
        this.pnlCardCheques.SuspendLayout();
        this.pnlCardCash.SuspendLayout();
        this.pnlCardBalance.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvLocationFinance)).BeginInit();

        this.tabProfit.SuspendLayout();
        this.pnlSummaryCardsPage3.SuspendLayout();
        this.pnlCardRevenue.SuspendLayout();
        this.pnlCardCost.SuspendLayout();
        this.pnlCardNetProfit.SuspendLayout();
        this.pnlCardMargin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvProfit)).BeginInit();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();

        // 
        // pnlTopHeader
        // 
        this.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
        this.pnlTopHeader.Controls.Add(this.lblAppTitle);
        this.pnlTopHeader.Controls.Add(this.btnAddItem);
        this.pnlTopHeader.Controls.Add(this.btnDeleteItem);
        this.pnlTopHeader.Controls.Add(this.dtpSalesDate);
        this.pnlTopHeader.Controls.Add(this.btnSaveAll);
        this.pnlTopHeader.Controls.Add(this.btnRefresh);
        this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlTopHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlTopHeader.Name = "pnlTopHeader";
        this.pnlTopHeader.Size = new System.Drawing.Size(1280, 65);
        this.pnlTopHeader.TabIndex = 0;

        // 
        // lblAppTitle
        // 
        this.lblAppTitle.AutoSize = true;
        this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
        this.lblAppTitle.ForeColor = System.Drawing.Color.White;
        this.lblAppTitle.Location = new System.Drawing.Point(16, 18);
        this.lblAppTitle.Name = "lblAppTitle";
        this.lblAppTitle.Size = new System.Drawing.Size(370, 30);
        this.lblAppTitle.TabIndex = 0;
        this.lblAppTitle.Text = "DAILY INVENTORY & SALES TRACKING";

        // 
        // btnAddItem
        // 
        this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnAddItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(165)))), ((int)(((byte)(233)))));
        this.btnAddItem.FlatAppearance.BorderSize = 0;
        this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnAddItem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnAddItem.ForeColor = System.Drawing.Color.White;
        this.btnAddItem.Location = new System.Drawing.Point(540, 16);
        this.btnAddItem.Name = "btnAddItem";
        this.btnAddItem.Size = new System.Drawing.Size(130, 34);
        this.btnAddItem.TabIndex = 4;
        this.btnAddItem.Text = "➕ Add Item";
        this.btnAddItem.UseVisualStyleBackColor = false;
        this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);

        // 
        // btnDeleteItem
        // 
        this.btnDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnDeleteItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
        this.btnDeleteItem.FlatAppearance.BorderSize = 0;
        this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDeleteItem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnDeleteItem.ForeColor = System.Drawing.Color.White;
        this.btnDeleteItem.Location = new System.Drawing.Point(680, 16);
        this.btnDeleteItem.Name = "btnDeleteItem";
        this.btnDeleteItem.Size = new System.Drawing.Size(130, 34);
        this.btnDeleteItem.TabIndex = 5;
        this.btnDeleteItem.Text = "🗑️ Delete Item";
        this.btnDeleteItem.UseVisualStyleBackColor = false;
        this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);

        // 
        // dtpSalesDate
        // 
        this.dtpSalesDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.dtpSalesDate.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.dtpSalesDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.dtpSalesDate.Location = new System.Drawing.Point(820, 18);
        this.dtpSalesDate.Name = "dtpSalesDate";
        this.dtpSalesDate.Size = new System.Drawing.Size(140, 30);
        this.dtpSalesDate.TabIndex = 1;
        this.dtpSalesDate.ValueChanged += new System.EventHandler(this.dtpSalesDate_ValueChanged);

        // 
        // btnRefresh
        // 
        this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
        this.btnRefresh.FlatAppearance.BorderSize = 0;
        this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnRefresh.ForeColor = System.Drawing.Color.White;
        this.btnRefresh.Location = new System.Drawing.Point(970, 16);
        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.Size = new System.Drawing.Size(100, 34);
        this.btnRefresh.TabIndex = 2;
        this.btnRefresh.Text = "Reload";
        this.btnRefresh.UseVisualStyleBackColor = false;
        this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

        // 
        // btnSaveAll
        // 
        this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnSaveAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
        this.btnSaveAll.FlatAppearance.BorderSize = 0;
        this.btnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSaveAll.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnSaveAll.ForeColor = System.Drawing.Color.White;
        this.btnSaveAll.Location = new System.Drawing.Point(1080, 16);
        this.btnSaveAll.Name = "btnSaveAll";
        this.btnSaveAll.Size = new System.Drawing.Size(180, 34);
        this.btnSaveAll.TabIndex = 3;
        this.btnSaveAll.Text = "💾 Save System Data";
        this.btnSaveAll.UseVisualStyleBackColor = false;
        this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);

        // 
        // tabControlMain
        // 
        this.tabControlMain.Controls.Add(this.tabInventory);
        this.tabControlMain.Controls.Add(this.tabLocationFinance);
        this.tabControlMain.Controls.Add(this.tabProfit);
        this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.tabControlMain.Location = new System.Drawing.Point(0, 65);
        this.tabControlMain.Name = "tabControlMain";
        this.tabControlMain.SelectedIndex = 0;
        this.tabControlMain.Size = new System.Drawing.Size(1280, 645);
        this.tabControlMain.TabIndex = 1;

        // 
        // tabInventory (PAGE 1)
        // 
        this.tabInventory.Controls.Add(this.dgvInventory);
        this.tabInventory.Controls.Add(this.pnlSummaryCardsPage1);
        this.tabInventory.Location = new System.Drawing.Point(4, 32);
        this.tabInventory.Name = "tabInventory";
        this.tabInventory.Padding = new System.Windows.Forms.Padding(4);
        this.tabInventory.Size = new System.Drawing.Size(1272, 609);
        this.tabInventory.TabIndex = 0;
        this.tabInventory.Text = "📦 PAGE 1: MAIN INVENTORY & SALES";
        this.tabInventory.UseVisualStyleBackColor = true;

        // 
        // pnlSummaryCardsPage1
        // 
        this.pnlSummaryCardsPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
        this.pnlSummaryCardsPage1.ColumnCount = 4;
        this.pnlSummaryCardsPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage1.Controls.Add(this.pnlCardTotalSale, 0, 0);
        this.pnlSummaryCardsPage1.Controls.Add(this.pnlCardMySaleVal, 1, 0);
        this.pnlSummaryCardsPage1.Controls.Add(this.pnlCardStockVal, 2, 0);
        this.pnlSummaryCardsPage1.Controls.Add(this.pnlCardItemCount, 3, 0);
        this.pnlSummaryCardsPage1.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlSummaryCardsPage1.Location = new System.Drawing.Point(4, 4);
        this.pnlSummaryCardsPage1.Name = "pnlSummaryCardsPage1";
        this.pnlSummaryCardsPage1.RowCount = 1;
        this.pnlSummaryCardsPage1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.pnlSummaryCardsPage1.Size = new System.Drawing.Size(1264, 68);
        this.pnlSummaryCardsPage1.TabIndex = 0;

        // pnlCardTotalSale
        this.pnlCardTotalSale.BackColor = System.Drawing.Color.White;
        this.pnlCardTotalSale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardTotalSale.Controls.Add(this.lblTotalSaleValue);
        this.pnlCardTotalSale.Controls.Add(this.lblTotalSaleTitle);
        this.pnlCardTotalSale.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardTotalSale.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardTotalSale.Name = "pnlCardTotalSale";
        this.pnlCardTotalSale.TabIndex = 0;

        this.lblTotalSaleTitle.AutoSize = true;
        this.lblTotalSaleTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalSaleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblTotalSaleTitle.Location = new System.Drawing.Point(8, 4);
        this.lblTotalSaleTitle.Name = "lblTotalSaleTitle";
        this.lblTotalSaleTitle.Size = new System.Drawing.Size(84, 19);
        this.lblTotalSaleTitle.Text = "TOTAL SALE";

        this.lblTotalSaleValue.AutoSize = true;
        this.lblTotalSaleValue.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalSaleValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
        this.lblTotalSaleValue.Location = new System.Drawing.Point(8, 22);
        this.lblTotalSaleValue.Name = "lblTotalSaleValue";
        this.lblTotalSaleValue.Size = new System.Drawing.Size(95, 30);
        this.lblTotalSaleValue.Text = "Rs. 0.00";

        // pnlCardMySaleVal
        this.pnlCardMySaleVal.BackColor = System.Drawing.Color.White;
        this.pnlCardMySaleVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardMySaleVal.Controls.Add(this.lblTotalMySaleValue);
        this.pnlCardMySaleVal.Controls.Add(this.lblMySaleTitle);
        this.pnlCardMySaleVal.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardMySaleVal.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardMySaleVal.Name = "pnlCardMySaleVal";
        this.pnlCardMySaleVal.TabIndex = 1;

        this.lblMySaleTitle.AutoSize = true;
        this.lblMySaleTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblMySaleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblMySaleTitle.Location = new System.Drawing.Point(8, 4);
        this.lblMySaleTitle.Name = "lblMySaleTitle";
        this.lblMySaleTitle.Size = new System.Drawing.Size(160, 19);
        this.lblMySaleTitle.Text = "TOTAL MY SALE VALUE";

        this.lblTotalMySaleValue.AutoSize = true;
        this.lblTotalMySaleValue.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalMySaleValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
        this.lblTotalMySaleValue.Location = new System.Drawing.Point(8, 22);
        this.lblTotalMySaleValue.Name = "lblTotalMySaleValue";
        this.lblTotalMySaleValue.Size = new System.Drawing.Size(95, 30);
        this.lblTotalMySaleValue.Text = "Rs. 0.00";

        // pnlCardStockVal
        this.pnlCardStockVal.BackColor = System.Drawing.Color.White;
        this.pnlCardStockVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardStockVal.Controls.Add(this.lblTotalStockValue);
        this.pnlCardStockVal.Controls.Add(this.lblTotalStockTitle);
        this.pnlCardStockVal.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardStockVal.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardStockVal.Name = "pnlCardStockVal";
        this.pnlCardStockVal.TabIndex = 2;

        this.lblTotalStockTitle.AutoSize = true;
        this.lblTotalStockTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblTotalStockTitle.Location = new System.Drawing.Point(8, 4);
        this.lblTotalStockTitle.Name = "lblTotalStockTitle";
        this.lblTotalStockTitle.Size = new System.Drawing.Size(147, 19);
        this.lblTotalStockTitle.Text = "TOTAL STOCK VALUE";

        this.lblTotalStockValue.AutoSize = true;
        this.lblTotalStockValue.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalStockValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
        this.lblTotalStockValue.Location = new System.Drawing.Point(8, 22);
        this.lblTotalStockValue.Name = "lblTotalStockValue";
        this.lblTotalStockValue.Size = new System.Drawing.Size(95, 30);
        this.lblTotalStockValue.Text = "Rs. 0.00";

        // pnlCardItemCount
        this.pnlCardItemCount.BackColor = System.Drawing.Color.White;
        this.pnlCardItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardItemCount.Controls.Add(this.lblItemCountValue);
        this.pnlCardItemCount.Controls.Add(this.lblItemCountTitle);
        this.pnlCardItemCount.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardItemCount.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardItemCount.Name = "pnlCardItemCount";
        this.pnlCardItemCount.TabIndex = 3;

        this.lblItemCountTitle.AutoSize = true;
        this.lblItemCountTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblItemCountTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblItemCountTitle.Location = new System.Drawing.Point(8, 4);
        this.lblItemCountTitle.Name = "lblItemCountTitle";
        this.lblItemCountTitle.Size = new System.Drawing.Size(102, 19);
        this.lblItemCountTitle.Text = "TOTAL ITEMS";

        this.lblItemCountValue.AutoSize = true;
        this.lblItemCountValue.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
        this.lblItemCountValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
        this.lblItemCountValue.Location = new System.Drawing.Point(8, 22);
        this.lblItemCountValue.Name = "lblItemCountValue";
        this.lblItemCountValue.Size = new System.Drawing.Size(95, 30);
        this.lblItemCountValue.Text = "57 Items";

        // dgvInventory
        this.dgvInventory.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvInventory.Location = new System.Drawing.Point(4, 72);
        this.dgvInventory.Name = "dgvInventory";
        this.dgvInventory.Size = new System.Drawing.Size(1264, 533);
        this.dgvInventory.TabIndex = 1;

        // 
        // tabLocationFinance (PAGE 2)
        // 
        this.tabLocationFinance.Controls.Add(this.dgvLocationFinance);
        this.tabLocationFinance.Controls.Add(this.pnlSummaryCardsPage2);
        this.tabLocationFinance.Location = new System.Drawing.Point(4, 32);
        this.tabLocationFinance.Name = "tabLocationFinance";
        this.tabLocationFinance.Padding = new System.Windows.Forms.Padding(4);
        this.tabLocationFinance.Size = new System.Drawing.Size(1272, 609);
        this.tabLocationFinance.TabIndex = 1;
        this.tabLocationFinance.Text = "📍 PAGE 2: LOCATION FINANCE TRACKING";
        this.tabLocationFinance.UseVisualStyleBackColor = true;

        // 
        // pnlSummaryCardsPage2
        // 
        this.pnlSummaryCardsPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
        this.pnlSummaryCardsPage2.ColumnCount = 4;
        this.pnlSummaryCardsPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage2.Controls.Add(this.pnlCardBills, 0, 0);
        this.pnlSummaryCardsPage2.Controls.Add(this.pnlCardCheques, 1, 0);
        this.pnlSummaryCardsPage2.Controls.Add(this.pnlCardCash, 2, 0);
        this.pnlSummaryCardsPage2.Controls.Add(this.pnlCardBalance, 3, 0);
        this.pnlSummaryCardsPage2.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlSummaryCardsPage2.Location = new System.Drawing.Point(4, 4);
        this.pnlSummaryCardsPage2.Name = "pnlSummaryCardsPage2";
        this.pnlSummaryCardsPage2.RowCount = 1;
        this.pnlSummaryCardsPage2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.pnlSummaryCardsPage2.Size = new System.Drawing.Size(1264, 68);
        this.pnlSummaryCardsPage2.TabIndex = 0;

        // pnlCardBills
        this.pnlCardBills.BackColor = System.Drawing.Color.White;
        this.pnlCardBills.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardBills.Controls.Add(this.lblTotalBillsVal);
        this.pnlCardBills.Controls.Add(this.lblBillsTitle);
        this.pnlCardBills.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardBills.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardBills.Name = "pnlCardBills";
        this.pnlCardBills.TabIndex = 0;

        this.lblBillsTitle.AutoSize = true;
        this.lblBillsTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblBillsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblBillsTitle.Location = new System.Drawing.Point(8, 4);
        this.lblBillsTitle.Name = "lblBillsTitle";
        this.lblBillsTitle.Size = new System.Drawing.Size(89, 19);
        this.lblBillsTitle.Text = "TOTAL BILLS";

        this.lblTotalBillsVal.AutoSize = true;
        this.lblTotalBillsVal.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalBillsVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
        this.lblTotalBillsVal.Location = new System.Drawing.Point(8, 22);
        this.lblTotalBillsVal.Name = "lblTotalBillsVal";
        this.lblTotalBillsVal.Size = new System.Drawing.Size(95, 30);
        this.lblTotalBillsVal.Text = "Rs. 0.00";

        // pnlCardCheques
        this.pnlCardCheques.BackColor = System.Drawing.Color.White;
        this.pnlCardCheques.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardCheques.Controls.Add(this.lblTotalChequesVal);
        this.pnlCardCheques.Controls.Add(this.lblChequesTitle);
        this.pnlCardCheques.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardCheques.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardCheques.Name = "pnlCardCheques";
        this.pnlCardCheques.TabIndex = 1;

        this.lblChequesTitle.AutoSize = true;
        this.lblChequesTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblChequesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblChequesTitle.Location = new System.Drawing.Point(8, 4);
        this.lblChequesTitle.Name = "lblChequesTitle";
        this.lblChequesTitle.Size = new System.Drawing.Size(117, 19);
        this.lblChequesTitle.Text = "TOTAL CHEQUES";

        this.lblTotalChequesVal.AutoSize = true;
        this.lblTotalChequesVal.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalChequesVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(85)))), ((int)(((byte)(247)))));
        this.lblTotalChequesVal.Location = new System.Drawing.Point(8, 22);
        this.lblTotalChequesVal.Name = "lblTotalChequesVal";
        this.lblTotalChequesVal.Size = new System.Drawing.Size(95, 30);
        this.lblTotalChequesVal.Text = "Rs. 0.00";

        // pnlCardCash
        this.pnlCardCash.BackColor = System.Drawing.Color.White;
        this.pnlCardCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardCash.Controls.Add(this.txtCashInput);
        this.pnlCardCash.Controls.Add(this.lblCashTitle);
        this.pnlCardCash.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardCash.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardCash.Name = "pnlCardCash";
        this.pnlCardCash.TabIndex = 2;

        this.lblCashTitle.AutoSize = true;
        this.lblCashTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblCashTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblCashTitle.Location = new System.Drawing.Point(8, 4);
        this.lblCashTitle.Name = "lblCashTitle";
        this.lblCashTitle.Size = new System.Drawing.Size(127, 19);
        this.lblCashTitle.Text = "CASH COLLECTED";

        this.txtCashInput.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.txtCashInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
        this.txtCashInput.Location = new System.Drawing.Point(8, 22);
        this.txtCashInput.Name = "txtCashInput";
        this.txtCashInput.Size = new System.Drawing.Size(255, 29);
        this.txtCashInput.TabIndex = 1;
        this.txtCashInput.Text = "0.00";

        // pnlCardBalance
        this.pnlCardBalance.BackColor = System.Drawing.Color.White;
        this.pnlCardBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardBalance.Controls.Add(this.lblTotalBalanceVal);
        this.pnlCardBalance.Controls.Add(this.lblBalanceTitle);
        this.pnlCardBalance.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardBalance.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardBalance.Name = "pnlCardBalance";
        this.pnlCardBalance.TabIndex = 3;

        this.lblBalanceTitle.AutoSize = true;
        this.lblBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblBalanceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblBalanceTitle.Location = new System.Drawing.Point(8, 4);
        this.lblBalanceTitle.Name = "lblBalanceTitle";
        this.lblBalanceTitle.Size = new System.Drawing.Size(100, 19);
        this.lblBalanceTitle.Text = "NET BALANCE";

        this.lblTotalBalanceVal.AutoSize = true;
        this.lblTotalBalanceVal.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalBalanceVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
        this.lblTotalBalanceVal.Location = new System.Drawing.Point(8, 22);
        this.lblTotalBalanceVal.Name = "lblTotalBalanceVal";
        this.lblTotalBalanceVal.Size = new System.Drawing.Size(95, 30);
        this.lblTotalBalanceVal.Text = "Rs. 0.00";

        // dgvLocationFinance
        this.dgvLocationFinance.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvLocationFinance.Location = new System.Drawing.Point(4, 72);
        this.dgvLocationFinance.Name = "dgvLocationFinance";
        this.dgvLocationFinance.Size = new System.Drawing.Size(1264, 533);
        this.dgvLocationFinance.TabIndex = 1;

        // 
        // tabProfit (PAGE 3)
        // 
        this.tabProfit.Controls.Add(this.dgvProfit);
        this.tabProfit.Controls.Add(this.pnlSummaryCardsPage3);
        this.tabProfit.Location = new System.Drawing.Point(4, 32);
        this.tabProfit.Name = "tabProfit";
        this.tabProfit.Padding = new System.Windows.Forms.Padding(4);
        this.tabProfit.Size = new System.Drawing.Size(1272, 609);
        this.tabProfit.TabIndex = 2;
        this.tabProfit.Text = "📈 PAGE 3: PROFIT & MARGIN ANALYSIS";
        this.tabProfit.UseVisualStyleBackColor = true;

        // 
        // pnlSummaryCardsPage3
        // 
        this.pnlSummaryCardsPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
        this.pnlSummaryCardsPage3.ColumnCount = 4;
        this.pnlSummaryCardsPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
        this.pnlSummaryCardsPage3.Controls.Add(this.pnlCardRevenue, 0, 0);
        this.pnlSummaryCardsPage3.Controls.Add(this.pnlCardCost, 1, 0);
        this.pnlSummaryCardsPage3.Controls.Add(this.pnlCardNetProfit, 2, 0);
        this.pnlSummaryCardsPage3.Controls.Add(this.pnlCardMargin, 3, 0);
        this.pnlSummaryCardsPage3.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlSummaryCardsPage3.Location = new System.Drawing.Point(4, 4);
        this.pnlSummaryCardsPage3.Name = "pnlSummaryCardsPage3";
        this.pnlSummaryCardsPage3.RowCount = 1;
        this.pnlSummaryCardsPage3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.pnlSummaryCardsPage3.Size = new System.Drawing.Size(1264, 68);
        this.pnlSummaryCardsPage3.TabIndex = 0;

        // pnlCardRevenue
        this.pnlCardRevenue.BackColor = System.Drawing.Color.White;
        this.pnlCardRevenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardRevenue.Controls.Add(this.lblTotalRevenueVal);
        this.pnlCardRevenue.Controls.Add(this.lblRevenueTitle);
        this.pnlCardRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardRevenue.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardRevenue.Name = "pnlCardRevenue";
        this.pnlCardRevenue.TabIndex = 0;

        this.lblRevenueTitle.AutoSize = true;
        this.lblRevenueTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblRevenueTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblRevenueTitle.Location = new System.Drawing.Point(8, 4);
        this.lblRevenueTitle.Name = "lblRevenueTitle";
        this.lblRevenueTitle.Size = new System.Drawing.Size(120, 19);
        this.lblRevenueTitle.Text = "TOTAL REVENUE";

        this.lblTotalRevenueVal.AutoSize = true;
        this.lblTotalRevenueVal.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalRevenueVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(116)))), ((int)(((byte)(144)))));
        this.lblTotalRevenueVal.Location = new System.Drawing.Point(8, 22);
        this.lblTotalRevenueVal.Name = "lblTotalRevenueVal";
        this.lblTotalRevenueVal.Size = new System.Drawing.Size(95, 30);
        this.lblTotalRevenueVal.Text = "Rs. 0.00";

        // pnlCardCost
        this.pnlCardCost.BackColor = System.Drawing.Color.White;
        this.pnlCardCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardCost.Controls.Add(this.lblTotalCostVal);
        this.pnlCardCost.Controls.Add(this.lblCostTitle);
        this.pnlCardCost.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardCost.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardCost.Name = "pnlCardCost";
        this.pnlCardCost.TabIndex = 1;

        this.lblCostTitle.AutoSize = true;
        this.lblCostTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblCostTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblCostTitle.Location = new System.Drawing.Point(8, 4);
        this.lblCostTitle.Name = "lblCostTitle";
        this.lblCostTitle.Size = new System.Drawing.Size(94, 19);
        this.lblCostTitle.Text = "TOTAL COST";

        this.lblTotalCostVal.AutoSize = true;
        this.lblTotalCostVal.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalCostVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
        this.lblTotalCostVal.Location = new System.Drawing.Point(8, 22);
        this.lblTotalCostVal.Name = "lblTotalCostVal";
        this.lblTotalCostVal.Size = new System.Drawing.Size(95, 30);
        this.lblTotalCostVal.Text = "Rs. 0.00";

        // pnlCardNetProfit
        this.pnlCardNetProfit.BackColor = System.Drawing.Color.White;
        this.pnlCardNetProfit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardNetProfit.Controls.Add(this.lblTotalNetProfitVal);
        this.pnlCardNetProfit.Controls.Add(this.lblNetProfitTitle);
        this.pnlCardNetProfit.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardNetProfit.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardNetProfit.Name = "pnlCardNetProfit";
        this.pnlCardNetProfit.TabIndex = 2;

        this.lblNetProfitTitle.AutoSize = true;
        this.lblNetProfitTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblNetProfitTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblNetProfitTitle.Location = new System.Drawing.Point(8, 4);
        this.lblNetProfitTitle.Name = "lblNetProfitTitle";
        this.lblNetProfitTitle.Size = new System.Drawing.Size(160, 19);
        this.lblNetProfitTitle.Text = "TOTAL NET PROFIT (Rs.)";

        this.lblTotalNetProfitVal.AutoSize = true;
        this.lblTotalNetProfitVal.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
        this.lblTotalNetProfitVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
        this.lblTotalNetProfitVal.Location = new System.Drawing.Point(8, 22);
        this.lblTotalNetProfitVal.Name = "lblTotalNetProfitVal";
        this.lblTotalNetProfitVal.Size = new System.Drawing.Size(95, 30);
        this.lblTotalNetProfitVal.Text = "Rs. 0.00";

        // pnlCardMargin
        this.pnlCardMargin.BackColor = System.Drawing.Color.White;
        this.pnlCardMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardMargin.Controls.Add(this.lblOverallMarginVal);
        this.pnlCardMargin.Controls.Add(this.lblMarginTitle);
        this.pnlCardMargin.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardMargin.Margin = new System.Windows.Forms.Padding(4);
        this.pnlCardMargin.Name = "pnlCardMargin";
        this.pnlCardMargin.TabIndex = 3;

        this.lblMarginTitle.AutoSize = true;
        this.lblMarginTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblMarginTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
        this.lblMarginTitle.Location = new System.Drawing.Point(8, 4);
        this.lblMarginTitle.Name = "lblMarginTitle";
        this.lblMarginTitle.Size = new System.Drawing.Size(155, 19);
        this.lblMarginTitle.Text = "OVERALL MARGIN %";

        this.lblOverallMarginVal.AutoSize = true;
        this.lblOverallMarginVal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
        this.lblOverallMarginVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
        this.lblOverallMarginVal.Location = new System.Drawing.Point(10, 24);
        this.lblOverallMarginVal.Name = "lblOverallMarginVal";
        this.lblOverallMarginVal.Size = new System.Drawing.Size(75, 30);
        this.lblOverallMarginVal.Text = "0.00%";

        // dgvProfit
        this.dgvProfit.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvProfit.Location = new System.Drawing.Point(8, 83);
        this.dgvProfit.Name = "dgvProfit";
        this.dgvProfit.Size = new System.Drawing.Size(1256, 508);
        this.dgvProfit.TabIndex = 1;

        // statusStrip
        this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.lblStatusMessage});
        this.statusStrip.Location = new System.Drawing.Point(0, 710);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new System.Drawing.Size(1280, 26);
        this.statusStrip.TabIndex = 2;

        // lblStatusMessage
        this.lblStatusMessage.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblStatusMessage.Name = "lblStatusMessage";
        this.lblStatusMessage.Size = new System.Drawing.Size(150, 20);
        this.lblStatusMessage.Text = "Ready.";

        // MainForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1280, 736);
        this.Controls.Add(this.tabControlMain);
        this.Controls.Add(this.statusStrip);
        this.Controls.Add(this.pnlTopHeader);
        this.Name = "MainForm";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Daily Inventory and Sales Tracking System";
        this.Load += new System.EventHandler(this.MainForm_Load);
        this.pnlCardTotalSale.ResumeLayout(false);
        this.pnlCardTotalSale.PerformLayout();
        this.pnlCardMySaleVal.ResumeLayout(false);
        this.pnlCardMySaleVal.PerformLayout();
        this.pnlCardStockVal.ResumeLayout(false);
        this.pnlCardStockVal.PerformLayout();
        this.pnlCardItemCount.ResumeLayout(false);
        this.pnlCardItemCount.PerformLayout();
        this.pnlSummaryCardsPage1.ResumeLayout(false);
        this.tabInventory.ResumeLayout(false);

        this.pnlCardBills.ResumeLayout(false);
        this.pnlCardBills.PerformLayout();
        this.pnlCardCheques.ResumeLayout(false);
        this.pnlCardCheques.PerformLayout();
        this.pnlCardCash.ResumeLayout(false);
        this.pnlCardCash.PerformLayout();
        this.pnlCardBalance.ResumeLayout(false);
        this.pnlCardBalance.PerformLayout();
        this.pnlSummaryCardsPage2.ResumeLayout(false);
        this.tabLocationFinance.ResumeLayout(false);

        this.pnlCardRevenue.ResumeLayout(false);
        this.pnlCardRevenue.PerformLayout();
        this.pnlCardCost.ResumeLayout(false);
        this.pnlCardCost.PerformLayout();
        this.pnlCardNetProfit.ResumeLayout(false);
        this.pnlCardNetProfit.PerformLayout();
        this.pnlCardMargin.ResumeLayout(false);
        this.pnlCardMargin.PerformLayout();
        this.pnlSummaryCardsPage3.ResumeLayout(false);
        this.tabProfit.ResumeLayout(false);

        this.tabControlMain.ResumeLayout(false);
        this.pnlTopHeader.ResumeLayout(false);
        this.pnlTopHeader.PerformLayout();
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Panel pnlTopHeader;
    private System.Windows.Forms.Label lblAppTitle;
    private System.Windows.Forms.DateTimePicker dtpSalesDate;
    private System.Windows.Forms.Button btnSaveAll;
    private System.Windows.Forms.Button btnRefresh;

    private System.Windows.Forms.TabControl tabControlMain;
    private System.Windows.Forms.TabPage tabInventory;
    private System.Windows.Forms.TabPage tabLocationFinance;
    private System.Windows.Forms.TabPage tabProfit;

    // Page 1 Elements
    private System.Windows.Forms.TableLayoutPanel pnlSummaryCardsPage1;
    private System.Windows.Forms.Panel pnlCardTotalSale;
    private System.Windows.Forms.Label lblTotalSaleTitle;
    private System.Windows.Forms.Label lblTotalSaleValue;
    private System.Windows.Forms.Panel pnlCardMySaleVal;
    private System.Windows.Forms.Label lblMySaleTitle;
    private System.Windows.Forms.Label lblTotalMySaleValue;
    private System.Windows.Forms.Panel pnlCardStockVal;
    private System.Windows.Forms.Label lblTotalStockTitle;
    private System.Windows.Forms.Label lblTotalStockValue;
    private System.Windows.Forms.Panel pnlCardItemCount;
    private System.Windows.Forms.Label lblItemCountTitle;
    private System.Windows.Forms.Label lblItemCountValue;
    private System.Windows.Forms.Button btnAddItem;
    private System.Windows.Forms.Button btnDeleteItem;
    private System.Windows.Forms.DataGridView dgvInventory;

    // Page 2 Elements
    private System.Windows.Forms.TableLayoutPanel pnlSummaryCardsPage2;
    private System.Windows.Forms.Panel pnlCardBills;
    private System.Windows.Forms.Label lblBillsTitle;
    private System.Windows.Forms.Label lblTotalBillsVal;
    private System.Windows.Forms.Panel pnlCardCheques;
    private System.Windows.Forms.Label lblChequesTitle;
    private System.Windows.Forms.Label lblTotalChequesVal;
    private System.Windows.Forms.Panel pnlCardCash;
    private System.Windows.Forms.Label lblCashTitle;
    private System.Windows.Forms.TextBox txtCashInput;
    private System.Windows.Forms.Panel pnlCardBalance;
    private System.Windows.Forms.Label lblBalanceTitle;
    private System.Windows.Forms.Label lblTotalBalanceVal;
    private System.Windows.Forms.DataGridView dgvLocationFinance;

    // Page 3 Elements
    private System.Windows.Forms.TableLayoutPanel pnlSummaryCardsPage3;
    private System.Windows.Forms.Panel pnlCardRevenue;
    private System.Windows.Forms.Label lblRevenueTitle;
    private System.Windows.Forms.Label lblTotalRevenueVal;
    private System.Windows.Forms.Panel pnlCardCost;
    private System.Windows.Forms.Label lblCostTitle;
    private System.Windows.Forms.Label lblTotalCostVal;
    private System.Windows.Forms.Panel pnlCardNetProfit;
    private System.Windows.Forms.Label lblNetProfitTitle;
    private System.Windows.Forms.Label lblTotalNetProfitVal;
    private System.Windows.Forms.Panel pnlCardMargin;
    private System.Windows.Forms.Label lblMarginTitle;
    private System.Windows.Forms.Label lblOverallMarginVal;
    private System.Windows.Forms.DataGridView dgvProfit;

    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel lblStatusMessage;
}
