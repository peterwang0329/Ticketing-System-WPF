# 🎟️ 訂票系統 (Ticketing System)

基於 **WPF (Windows Presentation Foundation)** 的桌面應用程式電影/活動訂票系統，提供完整的選位、訂票流程。

## 📌 專案說明

本專案為使用 C# 與 WPF 框架開發的桌面訂票應用程式，提供使用者友善的圖形化介面，支援座位選擇、訂單確認等完整訂票流程。

## 🛠️ 技術棧

- **語言**：C# (.NET)
- **框架**：WPF (Windows Presentation Foundation)
- **IDE**：Visual Studio 2022
- **UI 架構**：XAML + Code-Behind

## 🌟 功能特色

- 🏠 **首頁選單**：活動/場次瀏覽介面
- 💺 **座位選擇**：互動式座位圖（Page1）
- 🎭 **詳細座位配置**：多區域座位顯示（Page2）
- ✅ **訂票確認**：完成訂票流程（Fin）
- 🎬 **自訂應用程式圖示**：電影放映機主題圖示

## 📂 檔案結構

```
Ticketing system/
├── WpfApp5-2.sln              # Visual Studio 解決方案檔
└── WpfApp5-2/
    ├── App.xaml               # 應用程式入口
    ├── MainWindow.xaml        # 主視窗
    ├── Menu.xaml              # 選單頁面
    ├── Page1.xaml             # 座位選擇頁面
    ├── Page2.xaml             # 詳細座位配置頁面
    ├── Fin.xaml               # 訂票完成頁面
    └── Image/                 # 圖片資源目錄
```

## 🚀 使用方式

### 方法一：使用 Visual Studio
1. 開啟 `WpfApp5-2.sln`
2. 按 **F5** 或點選「執行」建置並啟動

### 方法二：執行建置結果
```
找到 WpfApp5-2/bin/Debug/ 目錄下的執行檔並直接執行
```

## 💻 系統需求

- Windows 10 / 11
- .NET Framework 或 .NET 6+
- Visual Studio 2022（若需要修改原始碼）

## 👨‍💻 開發者

- **開發者**：汪章貴
- **框架**：WPF / C# / .NET
