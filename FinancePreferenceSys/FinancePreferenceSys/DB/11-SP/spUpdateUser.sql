USE [FinancePreferenceDB]
GO
DROP PROCEDURE [dbo].[spUpdateUser]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUpdateUser]
    @UserID UNIQUEIDENTIFIER,
    @UserName NVARCHAR(100),
    @Account NVARCHAR(100),
    @PasswordHash NVARCHAR(255) = NULL,
    @ModDate DATETIME
AS
BEGIN
    UPDATE [User]
    SET
        UserName = @UserName,
        Account = @Account,
        ModDate = @ModDate,
        PasswordHash = ISNULL(@PasswordHash, PasswordHash)
    WHERE UserID = @UserID
END
GO


