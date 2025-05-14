CREATE TABLE [Product] (
    [No] INT IDENTITY(1,1) PRIMARY KEY,	-- 產品流水號 (Primary Key)
    ProductName NVARCHAR(255) NOT NULL, -- 產品名稱
    Price DECIMAL(18, 2) NOT NULL,      -- 產品價格
    FeeRate DECIMAL(5, 4) NOT NULL      -- 手續費率 (0.1 表示 10%)
)