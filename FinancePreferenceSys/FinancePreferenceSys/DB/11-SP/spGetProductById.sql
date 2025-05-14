USE [FinancePreferenceDB]
GO
DROP PROCEDURE [dbo].[spGetProductById]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spGetProductById]
    @No INT
AS
BEGIN
    SELECT No, ProductName, Price, FeeRate*100 as FeeRate FROM Product WHERE No = @No
END
GO


