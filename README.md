# 📦 Enterprise Daily Inventory & Sales Tracking System

[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![Windows Forms](https://img.shields.io/badge/UI-WinForms-0078D4?style=for-the-badge&logo=windows)](https://docs.microsoft.com/en-us/dotnet/desktop/winforms/)
[![SQLite Engine](https://img.shields.io/badge/Database-SQLite-003B57?style=for-the-badge&logo=sqlite)](https://www.sqlite.org/)
[![Dapper ORM](https://img.shields.io/badge/ORM-Dapper-EE3124?style=for-the-badge)](https://github.com/DapperLib/Dapper)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)](LICENSE)

An enterprise-grade, high-performance **Daily Inventory & Financial Tracking Application** built for retail, wholesale, and multi-location distribution businesses. Developed using **C# 13, .NET 9 WinForms, Dapper ORM, and SQLite Embedded Engine**, this application delivers zero-dependency, 100% offline portable operation with dynamic full-screen responsiveness.

---

## ✨ Key Features & Capabilities

### 📦 Page 1: Main Inventory & Daily Sales Tracking
* **57 Master Inventory Items**: Pre-seeded item catalog with instant sorting and category color tags.
* **Automated Stock Engine**:
  $$\text{Main Stock} = \text{Routine Stock} + \text{New Stock}$$
  $$\text{Final Stock} = \text{Main Stock} - \text{Sale Qty} - \text{My Sale Qty}$$
* **Real-time Valuation**: Instant calculation of `Sale Value (Rs.)` and `Final Stock Value (Rs.)`.
* **Automated Day-to-Day Stock Carryover**: Selecting a new day automatically carries forward previous day's **Final Stock** into the new day's **Routine Stock (Opening Stock)**.

### 📍 Page 2: Location Finance & Collection Tracking
* **Multi-Location Accounting**: Track financial collections across locations (`Badulla`, `Bandarawela`, `Attampitiya`, `Welimada`, `Udupussalla`, `Kumara`, `Cheques`, etc.).
* **Financial Metrics**: Track `Bills`, `Cheques`, `Early Credits`, `Returned Amounts`, and `Net Cash Balance`.
* **Cash Handover Reconciliation**: Built-in cash input card with instant net balance calculation.

### 📈 Page 3: Profit & Margin Analysis
* **Cost & Revenue Analysis**: Real-time evaluation of `Cost Price (Rs.)`, `Selling Price (Rs.)`, and `Unit Profit (Rs.)`.
* **Profitability Metrics**:
  $$\text{Net Profit} = \text{Total Revenue} - \text{Total Cost}$$
  $$\text{Profit Margin \%} = \left(\frac{\text{Net Profit}}{\text{Total Revenue}}\right) \times 100$$
* **Summary Cards**: Dynamic summary indicators displaying Total Revenue, Total Cost, Net Profit (Rs.), and Overall Margin %.

### ✏️ Direct Inline Cell Editing
* Edit **Item Names**, **Selling Prices (Rs.)**, **Cost Prices (Rs.)**, and **Location Names** directly inside the table cells.
* All modifications automatically save to the database in real-time and synchronize across all 3 pages.

---

## 🛠️ Architecture & Technology Stack

The project follows a strict **N-Tier Layered Architecture**:

```text
c:\games\shop\
├── InventorySales.Core/           # Domain Models & View Models DTOs
├── InventorySales.DataAccess/     # Repository Pattern, Dapper ORM, SQLite Engine
├── InventorySales.Services/       # Business Logic, Calculation Engine & Validation
└── InventorySales.WinForms/       # Windows Forms UI, Helpers & Dynamic Layout Engine
```

* **Framework**: .NET 9.0 (C# 13)
* **UI**: Windows Forms (Dynamic 100% Full-Screen Layout)
* **Database**: Embedded SQLite (`Microsoft.Data.Sqlite`) - 100% Offline, Zero Installation required.
* **ORM**: Dapper High-Performance Micro-ORM.

---

## 🚀 Getting Started

### Prerequisites
* [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) or higher.
* Windows 10 / 11.

### Running Locally
```powershell
# Clone the repository
git clone https://github.com/YOUR_USERNAME/InventorySalesSystem.git
cd InventorySalesSystem

# Build the solution
dotnet build InventorySales.sln

# Run the WinForms Application
dotnet run --project InventorySales.WinForms
```

---

## 📦 Standalone Portable Deployment (Zero Setup)

Publish a self-contained portable executable that runs on any Windows computer with **zero dependencies or installation**:

```powershell
dotnet publish InventorySales.WinForms\InventorySales.WinForms.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

The output executable will be generated at:
`InventorySales.WinForms\bin\Release\net9.0-windows\win-x64\publish\InventorySales.WinForms.exe`

Simply copy the `publish/` folder onto a USB Pen Drive, double-click `InventorySales.WinForms.exe`, and it runs 100% offline!

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
