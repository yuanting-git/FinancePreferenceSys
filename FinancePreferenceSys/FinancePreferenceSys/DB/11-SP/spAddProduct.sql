USE [FinancePreferenceDB]
GO
DROP PROCEDURE [dbo].[spAddProduct]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAddProduct]
    @ProductName NVARCHAR(100),
    @Price DECIMAL(18,2),
    @FeeRate DECIMAL(5,4)
AS
BEGIN
    INSERT INTO Product (ProductName, Price, FeeRate)
    VALUES (@ProductName, @Price, @FeeRate)
END
GO


