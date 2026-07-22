-- ============================================================================
-- Enterprise Daily Inventory and Sales Tracking System Database Schema
-- RDBMS: SQL Server 2016+ / Azure SQL
-- Author: Expert .NET Software Architect
-- Description: Complete schema, indexes, constraints, and seed data for 57 custom items
-- ============================================================================

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'InventorySalesDb')
BEGIN
    CREATE DATABASE [InventorySalesDb];
END
GO

USE [InventorySalesDb];
GO

-- ----------------------------------------------------------------------------
-- Table: Categories
-- ----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Categories', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Categories (
        CategoryId INT IDENTITY(1,1) NOT NULL,
        CategoryName NVARCHAR(100) NOT NULL,
        ColorHex VARCHAR(10) NOT NULL CONSTRAINT DF_Categories_ColorHex DEFAULT '#FFFFFF',
        DisplayOrder INT NOT NULL CONSTRAINT DF_Categories_DisplayOrder DEFAULT 0,
        CONSTRAINT PK_Categories PRIMARY KEY CLUSTERED (CategoryId ASC)
    );
END
GO

-- ----------------------------------------------------------------------------
-- Table: Items (57 Master Items)
-- ----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.Items', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Items (
        ItemId INT IDENTITY(1,1) NOT NULL,
        CategoryId INT NOT NULL,
        ItemName NVARCHAR(150) NOT NULL,
        Price DECIMAL(18,2) NOT NULL CONSTRAINT DF_Items_Price DEFAULT 0.00,
        CostPrice DECIMAL(18,2) NOT NULL CONSTRAINT DF_Items_CostPrice DEFAULT 0.00,
        DisplayOrder INT NOT NULL CONSTRAINT DF_Items_DisplayOrder DEFAULT 0,
        IsActive BIT NOT NULL CONSTRAINT DF_Items_IsActive DEFAULT 1,
        CONSTRAINT PK_Items PRIMARY KEY CLUSTERED (ItemId ASC),
        CONSTRAINT FK_Items_Categories FOREIGN KEY (CategoryId) REFERENCES dbo.Categories(CategoryId)
    );
END
ELSE
BEGIN
    IF NOT EXISTS (SELECT 1 FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Items') AND name = 'CostPrice')
    BEGIN
        ALTER TABLE dbo.Items ADD CostPrice DECIMAL(18,2) NOT NULL CONSTRAINT DF_Items_CostPrice DEFAULT 0.00;
    END
END
GO

-- ----------------------------------------------------------------------------
-- Table: DailySalesHeaders (Daily Tracking Master Record)
-- ----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.DailySalesHeaders', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DailySalesHeaders (
        DailySalesHeaderId INT IDENTITY(1,1) NOT NULL,
        SalesDate DATE NOT NULL,
        TotalSale DECIMAL(18,2) NOT NULL CONSTRAINT DF_DailySalesHeaders_TotalSale DEFAULT 0.00,
        Cash DECIMAL(18,2) NOT NULL CONSTRAINT DF_DailySalesHeaders_Cash DEFAULT 0.00,
        TotalStockValue DECIMAL(18,2) NOT NULL CONSTRAINT DF_DailySalesHeaders_TotalStockValue DEFAULT 0.00,
        Notes NVARCHAR(500) NULL,
        CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_DailySalesHeaders_CreatedAt DEFAULT SYSDATETIME(),
        UpdatedAt DATETIME2 NOT NULL CONSTRAINT DF_DailySalesHeaders_UpdatedAt DEFAULT SYSDATETIME(),
        CONSTRAINT PK_DailySalesHeaders PRIMARY KEY CLUSTERED (DailySalesHeaderId ASC),
        CONSTRAINT UQ_DailySalesHeaders_SalesDate UNIQUE (SalesDate)
    );
END
GO

-- ----------------------------------------------------------------------------
-- Table: DailySalesItemDetails (Main Inventory Grid Records)
-- ----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.DailySalesItemDetails', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DailySalesItemDetails (
        DetailId INT IDENTITY(1,1) NOT NULL,
        DailySalesHeaderId INT NOT NULL,
        ItemId INT NOT NULL,
        RoutineStock DECIMAL(18,2) NOT NULL CONSTRAINT DF_ItemDetails_RoutineStock DEFAULT 0.00,
        NewStock DECIMAL(18,2) NOT NULL CONSTRAINT DF_ItemDetails_NewStock DEFAULT 0.00,
        MainStock DECIMAL(18,2) NOT NULL CONSTRAINT DF_ItemDetails_MainStock DEFAULT 0.00,
        IssueOut DECIMAL(18,2) NOT NULL CONSTRAINT DF_ItemDetails_IssueOut DEFAULT 0.00,
        Returned DECIMAL(18,2) NOT NULL CONSTRAINT DF_ItemDetails_Returned DEFAULT 0.00,
        SaleQuantity DECIMAL(18,2) NOT NULL CONSTRAINT DF_ItemDetails_SaleQuantity DEFAULT 0.00,
        SaleValue DECIMAL(18,2) NOT NULL CONSTRAINT DF_ItemDetails_SaleValue DEFAULT 0.00,
        FinalStock DECIMAL(18,2) NOT NULL CONSTRAINT DF_ItemDetails_FinalStock DEFAULT 0.00,
        FinalStockValue DECIMAL(18,2) NOT NULL CONSTRAINT DF_ItemDetails_FinalStockValue DEFAULT 0.00,
        MySale DECIMAL(18,2) NOT NULL CONSTRAINT DF_ItemDetails_MySale DEFAULT 0.00,
        CONSTRAINT PK_DailySalesItemDetails PRIMARY KEY CLUSTERED (DetailId ASC),
        CONSTRAINT FK_ItemDetails_Header FOREIGN KEY (DailySalesHeaderId) REFERENCES dbo.DailySalesHeaders(DailySalesHeaderId) ON DELETE CASCADE,
        CONSTRAINT FK_ItemDetails_Items FOREIGN KEY (ItemId) REFERENCES dbo.Items(ItemId)
    );

    CREATE NONCLUSTERED INDEX IX_DailySalesItemDetails_Header ON dbo.DailySalesItemDetails(DailySalesHeaderId);
END
GO

-- ----------------------------------------------------------------------------
-- Table: DailyLocationFinance (Location Collections Grid Records)
-- ----------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.DailyLocationFinance', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.DailyLocationFinance (
        FinanceId INT IDENTITY(1,1) NOT NULL,
        DailySalesHeaderId INT NOT NULL,
        LocationName NVARCHAR(100) NOT NULL,
        Bills DECIMAL(18,2) NOT NULL CONSTRAINT DF_LocationFinance_Bills DEFAULT 0.00,
        Cheques DECIMAL(18,2) NOT NULL CONSTRAINT DF_LocationFinance_Cheques DEFAULT 0.00,
        EarlyCredits DECIMAL(18,2) NOT NULL CONSTRAINT DF_LocationFinance_EarlyCredits DEFAULT 0.00,
        Returned DECIMAL(18,2) NOT NULL CONSTRAINT DF_LocationFinance_Returned DEFAULT 0.00,
        Balance DECIMAL(18,2) NOT NULL CONSTRAINT DF_LocationFinance_Balance DEFAULT 0.00,
        DisplayOrder INT NOT NULL CONSTRAINT DF_LocationFinance_DisplayOrder DEFAULT 0,
        CONSTRAINT PK_DailyLocationFinance PRIMARY KEY CLUSTERED (FinanceId ASC),
        CONSTRAINT FK_LocationFinance_Header FOREIGN KEY (DailySalesHeaderId) REFERENCES dbo.DailySalesHeaders(DailySalesHeaderId) ON DELETE CASCADE
    );

    CREATE NONCLUSTERED INDEX IX_DailyLocationFinance_Header ON dbo.DailyLocationFinance(DailySalesHeaderId);
END
GO

-- ============================================================================
-- SEED DATA RESET & INSERTION (Single Clean Category & Exact 57 Items)
-- ============================================================================

-- 1. Insert Default Category
SET IDENTITY_INSERT dbo.Categories ON;
GO

MERGE INTO dbo.Categories AS Target
USING (VALUES
    (1, N'General Products', '#FFFFFF', 1)
) AS Source (CategoryId, CategoryName, ColorHex, DisplayOrder)
ON Target.CategoryId = Source.CategoryId
WHEN MATCHED THEN
    UPDATE SET CategoryName = Source.CategoryName, ColorHex = Source.ColorHex, DisplayOrder = Source.DisplayOrder
WHEN NOT MATCHED THEN
    INSERT (CategoryId, CategoryName, ColorHex, DisplayOrder)
    VALUES (Source.CategoryId, Source.CategoryName, Source.ColorHex, Source.DisplayOrder);
GO

SET IDENTITY_INSERT dbo.Categories OFF;
GO

-- 2. Clear previous items & details to maintain clean 1..57 order
TRUNCATE TABLE dbo.DailySalesItemDetails;
GO
DELETE FROM dbo.Items;
GO
DBCC CHECKIDENT ('dbo.Items', RESEED, 0);
GO

-- 3. Insert 57 Items in exact order 1 to 57
INSERT INTO dbo.Items (CategoryId, ItemName, Price, CostPrice, DisplayOrder, IsActive) VALUES
(1, N'7*4 MINI', 92.00, 85.00, 1, 1),
(1, N'7*4 WRP', 113.00, 0.00, 2, 1),
(1, N'7*4 EAG', 115.00, 0.00, 3, 1),
(1, N'7*4 VG', 126.00, 0.00, 4, 1),
(1, N'7*4 D/R', 115.00, 0.00, 5, 1),
(1, N'7*4 D/R', 122.00, 0.00, 6, 1),
(1, N'10*5 WRP', 190.00, 0.00, 7, 1),
(1, N'10*5', 205.00, 0.00, 8, 1),
(1, N'10*5', 215.00, 0.00, 9, 1),
(1, N'10*5 VG', 225.00, 0.00, 10, 1),
(1, N'JUMBO (02)', 600.00, 0.00, 11, 1),
(1, N'11*5 (01)', 360.00, 0.00, 12, 1),
(1, N'11*5 (02)', 340.00, 0.00, 13, 1),
(1, N'11*5', 0.00, 0.00, 14, 1),
(1, N'JUMBO WRP', 470.00, 0.00, 15, 1),
(1, N'KING JUMBO', 1050.00, 0.00, 16, 1),
(1, N'5*8 NO', 195.00, 0.00, 17, 1),
(1, N'7*10 NO', 295.00, 0.00, 18, 1),
(1, N'5*8 VG 400', 230.00, 0.00, 19, 1),
(1, N'5*8,VG 500', 287.00, 0.00, 20, 1),
(1, N'7*10 VG 400', 300.00, 0.00, 21, 1),
(1, N'7*10 VG 500', 375.00, 0.00, 22, 1),
(1, N'CUP', 430.00, 0.00, 23, 1),
(1, N'9*12', 1400.00, 0.00, 24, 1),
(1, N'SEVIET PAPER', 95.00, 0.00, 25, 1),
(1, N'F.C. ROLL (01)', 1200.00, 0.00, 26, 1),
(1, N'L/S 1KG', 330.00, 0.00, 27, 1),
(1, N'TULIP 5/-', 450.00, 0.00, 28, 1),
(1, N'TULIP NORMAL', 950.00, 0.00, 29, 1),
(1, N'TULIP (01)', 1200.00, 0.00, 30, 1),
(1, N'TULIP 50/-', 2300.00, 0.00, 31, 1),
(1, N'TULIP (2)', 0.00, 0.00, 32, 1),
(1, N'WHITE TULIP 9*', 0.00, 0.00, 33, 1),
(1, N'WHITE TULIP 10', 400.00, 0.00, 34, 1),
(1, N'WHITE TULIP 12', 675.00, 0.00, 35, 1),
(1, N'WHITE TULIP 14', 825.00, 0.00, 36, 1),
(1, N'WHITE TULIP 7*', 250.00, 0.00, 37, 1),
(1, N'GARBAGE M', 1050.00, 0.00, 38, 1),
(1, N'GARBAGE L', 1250.00, 0.00, 39, 1),
(1, N'WHITE TULIP 16', 1000.00, 0.00, 40, 1),
(1, N'BROWN (01)', 205.00, 0.00, 41, 1),
(1, N'BROWN (02)', 390.00, 0.00, 42, 1),
(1, N'WHITE PAPERS', 240.00, 0.00, 43, 1),
(1, N'PAPER PLATES 1', 1400.00, 0.00, 44, 1),
(1, N'PAPER PLATES 2', 1500.00, 0.00, 45, 1),
(1, N'LIGHTERS', 1650.00, 0.00, 46, 1),
(1, N'UVA BEST TEA', 10.00, 0.00, 47, 1),
(1, N'AP special7*4', 140.00, 0.00, 48, 1),
(1, N'AP special10*5', 250.00, 0.00, 49, 1),
(1, N'AP special11*5', 375.00, 0.00, 50, 1),
(1, N'BROWN (03)', 145.00, 0.00, 51, 1),
(1, N'7*4 D/R', 110.00, 0.00, 52, 1),
(1, N'Unknown Item 53', 430.00, 0.00, 53, 1),
(1, N'Unknown Item 54', 300.00, 0.00, 54, 1),
(1, N'Unknown Item 55', 105.00, 0.00, 55, 1),
(1, N'Unknown Item 56', 115.00, 0.00, 56, 1),
(1, N'Unknown Item 57', 780.00, 0.00, 57, 1);
GO
