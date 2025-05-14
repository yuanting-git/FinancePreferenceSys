# 金融商品喜好紀錄系統

一個使用 ASP.NET MVC + SQL Server 實作的金融商品喜好紀錄系統，支援使用者對不同金融商品增刪改查的功能。

## 📦 專案架構

- ASP.NET MVC / Razor Pages
- SQL Server Express 作為後端資料庫搭配SSMS

## 使用說明
1. DB 名稱：FinancePreferenceDB，並將\DB資料夾內提供語法沖入DB
2. appsettings.json：ConnectionStrings須調整為上一步驟新增之DB
3. 本地建置專案後須先註冊帳號
4. 登入後可至「金融商品管理」新增金融商品，新增完成後可於「金融商品喜好清單」選取到已新增之金融商品
5. 金融商品喜好清單新增時預設帶入註冊時付款帳號，但可修改