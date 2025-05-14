CREATE TABLE [Product] (
    [No] INT IDENTITY(1,1) PRIMARY KEY,	-- ���~�y���� (Primary Key)
    ProductName NVARCHAR(255) NOT NULL, -- ���~�W��
    Price DECIMAL(18, 2) NOT NULL,      -- ���~����
    FeeRate DECIMAL(5, 4) NOT NULL      -- ����O�v (0.1 ��� 10%)
)