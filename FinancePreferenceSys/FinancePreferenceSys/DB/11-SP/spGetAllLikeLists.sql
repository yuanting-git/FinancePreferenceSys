USE [FinancePreferenceDB]
GO
DROP PROCEDURE [dbo].[spGetAllLikeLists]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[spGetAllLikeLists]
@UserID UNIQUEIDENTIFIER
AS
BEGIN
    SELECT l.SN, l.OrderNum, l.Account, l.TotalFee, l.TotalAmount, l.ProductNo, l.UserID,
           u.Email AS UserEmail,
           p.ProductName,
           p.Price,
           p.FeeRate
    FROM LikeList l
    INNER JOIN [User] u ON l.UserID = u.UserID
    INNER JOIN Product p ON l.ProductNo = p.No
	WHERE u.UserID = @UserID
END

GO


