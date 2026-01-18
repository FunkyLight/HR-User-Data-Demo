# Human Resource Management System (HR User Rights Demo)

這是一個基於 C# WinForms 的員工資料管理系統 Demo。
本專案為 **聯成電腦 宇辰系統科技C#軟體工程師培訓班** 的實作練習作品。主要目的是練習 **ADO.NET/Dapper 資料庫串接**、**介面 (Interface) 設計模式**，以及實作 **RBAC (Role-Based Access Control) 權限控管機制**。

系統能透過使用者登入後的權限碼，動態決定畫面的功能（如：唯讀、編輯、新增或刪除），模擬真實企業環境中的人資系統邏輯。

## 📸 專案特色

* **權限導向的 UI 設計 (Dynamic UI based on Permissions)**
    * 系統不只是單純的 CRUD，而是根據登入者的職級與部門權限 (`PermCodes`)，自動判斷按鈕的顯示/隱藏與欄位的唯讀狀態。
    * *實作：* 透過 `IPerm` 介面統一管理 `PermInit` 方法，確保所有表單遵循一致的權限初始化流程。
* **強型別的結果模式 (Result Pattern)**
    * 捨棄傳統直接回傳 `null` 或依賴 `try-catch` 的方式，設計了 `Result` 與 `Result<T>` 類別來標準化回傳結果與錯誤訊息，提升程式碼的健壯性與可讀性。
* **介面化設計 (Interface Segregation)**
    * 使用 `IDb` 介面定義資料庫操作，實現低耦合設計，便於未來的維護與擴充。
* **資料篩選 (Client-side Filtering)**
    * 利用 `DataTable.DefaultView.RowFilter` 實作即時的姓名關鍵字搜尋，提升使用者體驗。

## 🛠️ 技術堆疊 (Tech Stack)

* **語言:** C# (.NET 6 / .NET 8)
* **框架:** Windows Forms (WinForms)
* **資料庫:** MySQL / MariaDB
* **ORM / Data Access:**
    * **Dapper:** 用於物件映射 (如 `QueryFirstOrDefault`)，簡化 SQL 操作。
    * **ADO.NET:** 用於 `DataTable` 的批次載入與處理。
* **架構模式:** N-Tier (簡易分層: UI -> Logic/Interface -> Data)

## 資料庫設計 (Database Schema)

本系統使用關聯式資料庫，主要包含以下資料表：

* **staffs:** 員工基本資料 (帳號、密碼、個資)。
* **departments / ranks:** 部門與職級的正規化資料表。
* **permissions:** 定義系統可用的權限代碼 (如 `EDIT_USER`, `VIEW_ALL`)。
* **dept_rank_perm:** **核心權限表**。透過部門 ID 與職級 ID 的組合，對應出該職位擁有的權限。

> **SQL 查詢邏輯運用：**
> 登入時透過 SQL Join 關聯多張表，並使用 `GROUP_CONCAT` 將權限代碼串接成字串 (e.g., "VIEW_ALL,EDIT_USER")，登入後由程式解析為 List，供前端即時判斷。

## 程式碼結構亮點

### 1. 統一的回傳結構 (Result Pattern)
為了優化錯誤處理，回傳包含狀態與訊息的物件：
```csharp
public class Result<T> : Result
{
    internal T? Data { get; set; } // 泛型資料載體
}
```

2. 權限初始化介面 (IPerm Interface)
強制表單實作權限設定方法，確保每個受管控的表單都有標準的初始化流程：
```csharp
internal interface IPerm
{
    void PermInit(List<string> permCodes);
}
```
3. 安全性意識
在 SqlQuery 類別中使用參數化查詢 (Parameterized Queries) ... WHERE s.account = @account ...，防止 SQL Injection 攻擊。

## 功能操作說明
系統登入：輸入帳號密碼，系統驗證後載入使用者資訊與權限。

列表瀏覽：

若擁有 VIEW_ALL 權限，可看到所有員工列表。

若無此權限，僅能查看或編輯個人資料。

資料編輯：

點選列表中的員工，進入詳細資訊頁。

系統會依據 EDIT_USER 權限鎖定或開放欄位修改。

搜尋：上方搜尋框輸入姓名可即時過濾列表。

## 學習心得與未來展望 (Future Improvements)
作為課程實作專案，目前版本著重於功能的實現與架構的嘗試，未來可針對以下項目進行優化：

安全性：目前的密碼在資料庫為測試用明碼，未來應加入 Hash (如 SHA256 + Salt) 加密機制。

配置管理：將 Connection String 移至 appsettings.json 管理。

非同步處理：將資料庫操作全面改為 async/await，提升 UI 回應速度。
