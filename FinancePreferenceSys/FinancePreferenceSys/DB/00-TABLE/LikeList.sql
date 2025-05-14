CREATE TABLE LikeList (
    SN INT IDENTITY(1,1) PRIMARY KEY,					-- �y���Ǹ� (Primary Key)
    OrderNum INT NOT NULL,				-- �ʶR�ƶq
    Account NVARCHAR(255) NOT NULL,		-- ���ڱb��
    TotalFee DECIMAL(18, 2) NOT NULL,	-- �`����O�� (�x���p��)
    TotalAmount DECIMAL(18, 2) NOT NULL,-- �w�p�����`���B
	ProductNo INT NOT NULL,				-- ���~�y����
	UserID UNIQUEIDENTIFIER NOT NULL,	-- �ϥΪ�ID
	CreDate�@datetime default getdate(),
	ModDate�@datetime default getdate()
)