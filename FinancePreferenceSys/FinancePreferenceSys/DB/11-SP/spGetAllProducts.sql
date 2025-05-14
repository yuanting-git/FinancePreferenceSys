USE [FinancePreferenceDB]
GO
DROP PROCEDURE [dbo].[spGetAllProducts]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spGetAllProducts]
AS
BEGIN
    SELECT No, ProductName, Price, FeeRate FROM [Product]
END
GO


