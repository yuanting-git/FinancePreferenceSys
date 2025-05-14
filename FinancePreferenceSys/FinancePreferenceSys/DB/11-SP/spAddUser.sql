USE [FinancePreferenceDB]
GO
DROP PROCEDURE [dbo].[spAddUser]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spAddUser]
    @UserName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Account NVARCHAR(100),
    @PasswordHash NVARCHAR(255)
AS
BEGIN
    INSERT INTO [User] (UserName, Email, Account, PasswordHash)
    VALUES (@UserName, @Email, @Account, @PasswordHash)
END
GO


