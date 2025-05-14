USE [FinancePreferenceDB]
GO
DROP PROCEDURE [dbo].[spUpdateLikeList]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[spUpdateLikeList]
    @SN INT,
    @OrderNum INT,
    @Account NVARCHAR(255),
    @TotalFee DECIMAL(18, 2),
    @TotalAmount DECIMAL(18, 2),
    @ProductNo INT,
    @UserID UNIQUEIDENTIFIER,
	@ModDate Datetime
AS
BEGIN
    UPDATE LikeList
    SET OrderNum = @OrderNum,
        Account = @Account,
        TotalFee = @TotalFee,
        TotalAmount = @TotalAmount,
        ProductNo = @ProductNo,
        UserID = @UserID,
		ModDate = @ModDate
    WHERE SN = @SN
END

GO


