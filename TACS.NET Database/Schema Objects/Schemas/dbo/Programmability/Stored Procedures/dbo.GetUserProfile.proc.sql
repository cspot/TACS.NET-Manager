CREATE PROCEDURE [dbo].[GetUserProfile]
(
	@pUsername varchar(40)
)
AS
	SET NOCOUNT ON;
	SELECT Username, Password, FullName, Email, CreatedOn, ExpireOn, UserDisabled, SessionToken, 
		AcctId, AccountOwner, SuperAdministrator 
		FROM dbo.Users WHERE Username=@pUsername;
GO