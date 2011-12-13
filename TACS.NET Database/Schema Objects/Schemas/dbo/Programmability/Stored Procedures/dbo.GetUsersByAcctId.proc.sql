CREATE PROCEDURE [dbo].[GetUsersByAcctId]
(
	@pAcctId bigint
)
AS
	SET NOCOUNT ON;
	SELECT Username, Password, FullName, Email, CreatedOn, ExpireOn, UserDisabled, SessionToken, AcctId, AccountOwner, SuperAdministrator FROM dbo.Users 
		WHERE AcctId=@pAcctId ORDER BY Username
GO


