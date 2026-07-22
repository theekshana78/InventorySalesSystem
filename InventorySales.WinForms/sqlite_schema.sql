CREATE TABLE IF NOT EXISTS Categories (
    CategoryId INTEGER PRIMARY KEY AUTOINCREMENT,
    CategoryName TEXT NOT NULL,
    ColorHex TEXT NOT NULL DEFAULT '#FFFFFF',
    DisplayOrder INTEGER NOT NULL DEFAULT 0
);

CREATE TABLE IF NOT EXISTS Items (
    ItemId INTEGER PRIMARY KEY AUTOINCREMENT,
    CategoryId INTEGER NOT NULL,
    ItemName TEXT NOT NULL,
    Price REAL NOT NULL DEFAULT 0.00,
    CostPrice REAL NOT NULL DEFAULT 0.00,
    DisplayOrder INTEGER NOT NULL DEFAULT 0,
    IsActive INTEGER NOT NULL DEFAULT 1,
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

CREATE TABLE IF NOT EXISTS DailySalesHeaders (
    DailySalesHeaderId INTEGER PRIMARY KEY AUTOINCREMENT,
    SalesDate TEXT NOT NULL UNIQUE,
    TotalSale REAL NOT NULL DEFAULT 0.00,
    Cash REAL NOT NULL DEFAULT 0.00,
    TotalStockValue REAL NOT NULL DEFAULT 0.00,
    Notes TEXT NULL,
    CreatedAt TEXT NOT NULL DEFAULT (datetime('now')),
    UpdatedAt TEXT NOT NULL DEFAULT (datetime('now'))
);

CREATE TABLE IF NOT EXISTS DailySalesItemDetails (
    DetailId INTEGER PRIMARY KEY AUTOINCREMENT,
    DailySalesHeaderId INTEGER NOT NULL,
    ItemId INTEGER NOT NULL,
    RoutineStock REAL NOT NULL DEFAULT 0.00,
    NewStock REAL NOT NULL DEFAULT 0.00,
    MainStock REAL NOT NULL DEFAULT 0.00,
    IssueOut REAL NOT NULL DEFAULT 0.00,
    Returned REAL NOT NULL DEFAULT 0.00,
    SaleQuantity REAL NOT NULL DEFAULT 0.00,
    SaleValue REAL NOT NULL DEFAULT 0.00,
    FinalStock REAL NOT NULL DEFAULT 0.00,
    FinalStockValue REAL NOT NULL DEFAULT 0.00,
    MySale REAL NOT NULL DEFAULT 0.00,
    FOREIGN KEY (DailySalesHeaderId) REFERENCES DailySalesHeaders(DailySalesHeaderId) ON DELETE CASCADE,
    FOREIGN KEY (ItemId) REFERENCES Items(ItemId)
);

CREATE TABLE IF NOT EXISTS DailyLocationFinance (
    FinanceId INTEGER PRIMARY KEY AUTOINCREMENT,
    DailySalesHeaderId INTEGER NOT NULL,
    LocationName TEXT NOT NULL,
    Bills REAL NOT NULL DEFAULT 0.00,
    Cheques REAL NOT NULL DEFAULT 0.00,
    EarlyCredits REAL NOT NULL DEFAULT 0.00,
    Returned REAL NOT NULL DEFAULT 0.00,
    Balance REAL NOT NULL DEFAULT 0.00,
    DisplayOrder INTEGER NOT NULL DEFAULT 0,
    FOREIGN KEY (DailySalesHeaderId) REFERENCES DailySalesHeaders(DailySalesHeaderId) ON DELETE CASCADE
);

-- Seed Categories
INSERT OR IGNORE INTO Categories (CategoryId, CategoryName, ColorHex, DisplayOrder) VALUES (1, 'General Products', '#FFFFFF', 1);

-- Seed 57 Items
INSERT OR IGNORE INTO Items (ItemId, CategoryId, ItemName, Price, CostPrice, DisplayOrder, IsActive) VALUES
(1, 1, '7*4 MINI', 92.00, 85.00, 1, 1),
(2, 1, '7*4 WRP', 113.00, 0.00, 2, 1),
(3, 1, '7*4 EAG', 115.00, 0.00, 3, 1),
(4, 1, '7*4 VG', 126.00, 0.00, 4, 1),
(5, 1, '7*4 D/R', 115.00, 0.00, 5, 1),
(6, 1, '7*4 D/R', 122.00, 0.00, 6, 1),
(7, 1, '10*5 WRP', 190.00, 0.00, 7, 1),
(8, 1, '10*5', 205.00, 0.00, 8, 1),
(9, 1, '10*5', 215.00, 0.00, 9, 1),
(10, 1, '10*5 VG', 225.00, 0.00, 10, 1),
(11, 1, 'JUMBO (02)', 600.00, 0.00, 11, 1),
(12, 1, '11*5 (01)', 360.00, 0.00, 12, 1),
(13, 1, '11*5 (02)', 340.00, 0.00, 13, 1),
(14, 1, '11*5', 0.00, 0.00, 14, 1),
(15, 1, 'JUMBO WRP', 470.00, 0.00, 15, 1),
(16, 1, 'KING JUMBO', 1050.00, 0.00, 16, 1),
(17, 1, '5*8 NO', 195.00, 0.00, 17, 1),
(18, 1, '7*10 NO', 295.00, 0.00, 18, 1),
(19, 1, '5*8 VG 400', 230.00, 0.00, 19, 1),
(20, 1, '5*8,VG 500', 287.00, 0.00, 20, 1),
(21, 1, '7*10 VG 400', 300.00, 0.00, 21, 1),
(22, 1, '7*10 VG 500', 375.00, 0.00, 22, 1),
(23, 1, 'CUP', 430.00, 0.00, 23, 1),
(24, 1, '9*12', 1400.00, 0.00, 24, 1),
(25, 1, 'SEVIET PAPER', 95.00, 0.00, 25, 1),
(26, 1, 'F.C. ROLL (01)', 1200.00, 0.00, 26, 1),
(27, 1, 'L/S 1KG', 330.00, 0.00, 27, 1),
(28, 1, 'TULIP 5/-', 450.00, 0.00, 28, 1),
(29, 1, 'TULIP NORMAL', 950.00, 0.00, 29, 1),
(30, 1, 'TULIP (01)', 1200.00, 0.00, 30, 1),
(31, 1, 'TULIP 50/-', 2300.00, 0.00, 31, 1),
(32, 1, 'TULIP (2)', 0.00, 0.00, 32, 1),
(33, 1, 'WHITE TULIP 9*', 0.00, 0.00, 33, 1),
(34, 1, 'WHITE TULIP 10', 400.00, 0.00, 34, 1),
(35, 1, 'WHITE TULIP 12', 675.00, 0.00, 35, 1),
(36, 1, 'WHITE TULIP 14', 825.00, 0.00, 36, 1),
(37, 1, 'WHITE TULIP 7*', 250.00, 0.00, 37, 1),
(38, 1, 'GARBAGE M', 1050.00, 0.00, 38, 1),
(39, 1, 'GARBAGE L', 1250.00, 0.00, 39, 1),
(40, 1, 'WHITE TULIP 16', 1000.00, 0.00, 40, 1),
(41, 1, 'BROWN (01)', 205.00, 0.00, 41, 1),
(42, 1, 'BROWN (02)', 390.00, 0.00, 42, 1),
(43, 1, 'WHITE PAPERS', 240.00, 0.00, 43, 1),
(44, 1, 'PAPER PLATES 1', 1400.00, 0.00, 44, 1),
(45, 1, 'PAPER PLATES 2', 1500.00, 0.00, 45, 1),
(46, 1, 'LIGHTERS', 1650.00, 0.00, 46, 1),
(47, 1, 'UVA BEST TEA', 10.00, 0.00, 47, 1),
(48, 1, 'AP special7*4', 140.00, 0.00, 48, 1),
(49, 1, 'AP special10*5', 250.00, 0.00, 49, 1),
(50, 1, 'AP special11*5', 375.00, 0.00, 50, 1),
(51, 1, 'BROWN (03)', 145.00, 0.00, 51, 1),
(52, 1, '7*4 D/R', 110.00, 0.00, 52, 1),
(53, 1, 'Unknown Item 53', 430.00, 0.00, 53, 1),
(54, 1, 'Unknown Item 54', 300.00, 0.00, 54, 1),
(55, 1, 'Unknown Item 55', 105.00, 0.00, 55, 1),
(56, 1, 'Unknown Item 56', 115.00, 0.00, 56, 1),
(57, 1, 'Unknown Item 57', 780.00, 0.00, 57, 1);
