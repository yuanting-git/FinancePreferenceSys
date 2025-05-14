USE [FinancePreferenceDB]
GO
DROP PROCEDURE [dbo].[spUpdateProduct]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateProduct]
    @No INT,
    @ProductName NVARCHAR(100),
    @Price DECIMAL(18,2),
    @FeeRate DECIMAL(5,4)
AS
BEGIN
    UPDATE Product
    SET ProductName = @ProductName,
        Price = @Price,
        FeeRate = @FeeRate
    WHERE No = @No
END
GO


