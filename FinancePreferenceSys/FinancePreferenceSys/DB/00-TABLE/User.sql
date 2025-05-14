CREATE TABLE [User] (
    UserID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),-- �ϥΪ�ID (Primary Key)
    UserName NVARCHAR(255) NOT NULL,       -- �ϥΪ̦W��
    Email NVARCHAR(255) NOT NULL,          -- �ϥΪ̹q�l�l��
    Account NVARCHAR(255) NOT NULL,        -- ���ڱb��
	PasswordHash NVARCHAR(256) NOT NULL,
	CreDate DATETIME DEFAULT GETDATE(),
	ModDate DATETIME DEFAULT GETDATE()
)