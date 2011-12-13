CREATE PROCEDURE dbo.DeleteAccountUser
(
	@pUsername varchar(40),
	@pAcctId bigint
)
AS
	SET NOCOUNT OFF;
DELETE FROM [dbo].[Users] WHERE ([Username] = @pUsername AND [AcctId] = @pAcctId)
GO