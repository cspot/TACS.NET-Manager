CREATE PROCEDURE dbo.ResetPassword
(
	@Password varchar(40),
	@Username varchar(40)
)
AS
	SET NOCOUNT OFF;
UPDATE [dbo].[Users] SET [Password] = @Password WHERE (Username = @Username)
GO

