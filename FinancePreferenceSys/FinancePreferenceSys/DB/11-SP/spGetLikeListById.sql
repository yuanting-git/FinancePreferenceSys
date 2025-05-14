USE [FinancePreferenceDB]
GO
DROP PROCEDURE [dbo].[spGetLikeListById]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[spGetLikeListById]
    @SN INT
AS
BEGIN
    SELECT l.SN, l.OrderNum, l.Account, l.TotalFee, l.TotalAmount, l.ProductNo, l.UserID,
           p.ProductName,
           p.Price,
           p.FeeRate
    FROM LikeList l
    INNER JOIN Product p ON l.ProductNo = p.No
	WHERE l.SN = @SN
END

GO


