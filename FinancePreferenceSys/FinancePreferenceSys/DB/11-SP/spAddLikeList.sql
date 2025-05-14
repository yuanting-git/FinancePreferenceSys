USE [FinancePreferenceDB]
GO
DROP PROCEDURE [dbo].[spAddLikeList]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[spAddLikeList]
    @OrderNum INT,
    @Account NVARCHAR(255),
    @TotalFee DECIMAL(18, 2),
    @TotalAmount DECIMAL(18, 2),
    @ProductNo INT,
    @UserID UNIQUEIDENTIFIER
AS
BEGIN
    INSERT INTO LikeList (OrderNum, Account, TotalFee, TotalAmount, ProductNo, UserID)
    VALUES (@OrderNum, @Account, @TotalFee, @TotalAmount, @ProductNo, @UserID)
END

GO


