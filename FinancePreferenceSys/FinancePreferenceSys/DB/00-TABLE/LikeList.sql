CREATE TABLE LikeList (
    SN INT IDENTITY(1,1) PRIMARY KEY,					-- 流水序號 (Primary Key)
    OrderNum INT NOT NULL,				-- 購買數量
    Account NVARCHAR(255) NOT NULL,		-- 扣款帳號
    TotalFee DECIMAL(18, 2) NOT NULL,	-- 總手續費用 (台幣計價)
    TotalAmount DECIMAL(18, 2) NOT NULL,-- 預計扣款總金額
	ProductNo INT NOT NULL,				-- 產品流水號
	UserID UNIQUEIDENTIFIER NOT NULL,	-- 使用者ID
	CreDate　datetime default getdate(),
	ModDate　datetime default getdate()
)