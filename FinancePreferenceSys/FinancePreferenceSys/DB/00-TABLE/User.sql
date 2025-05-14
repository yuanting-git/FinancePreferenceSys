CREATE TABLE [User] (
    UserID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),-- 使用者ID (Primary Key)
    UserName NVARCHAR(255) NOT NULL,       -- 使用者名稱
    Email NVARCHAR(255) NOT NULL,          -- 使用者電子郵件
    Account NVARCHAR(255) NOT NULL,        -- 扣款帳號
	PasswordHash NVARCHAR(256) NOT NULL,
	CreDate DATETIME DEFAULT GETDATE(),
	ModDate DATETIME DEFAULT GETDATE()
)