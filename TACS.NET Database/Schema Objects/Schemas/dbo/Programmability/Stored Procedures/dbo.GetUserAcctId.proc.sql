CREATE PROCEDURE dbo.GetUserAcctId
(
	@Username varchar(40)
)
AS
	SET NOCOUNT ON;
SELECT AcctId FROM dbo.Users WHERE Username=@Username
GO

