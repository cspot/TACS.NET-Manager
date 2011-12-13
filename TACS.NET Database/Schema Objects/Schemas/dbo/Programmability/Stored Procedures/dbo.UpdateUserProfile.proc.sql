CREATE PROCEDURE dbo.UpdateUserProfile
(
	@Username varchar(40),
	@Password varchar(40),
	@FullName varchar(40),
	@Email varchar(80),
	@CreatedOn datetime,
	@ExpireOn datetime,
	@UserDisabled bit,
	@SessionToken varchar(32),
	@AcctId bigint,
	@AccountOwner bit,
	@SuperAdministrator bit,
	@Original_Username varchar(40)
)
AS
	SET NOCOUNT OFF;
UPDATE [Users] SET [Username] = @Username, [Password] = @Password, [FullName] = @FullName, [Email] = @Email, [CreatedOn] = @CreatedOn, [ExpireOn] = @ExpireOn, [UserDisabled] = @UserDisabled, [SessionToken] = @SessionToken, [AcctId] = @AcctId, [AccountOwner] = @AccountOwner, [SuperAdministrator] = @SuperAdministrator WHERE ([Username] = @Original_Username);
	
SELECT Username, Password, FullName, Email, CreatedOn, ExpireOn, UserDisabled, SessionToken, AcctId, AccountOwner, SuperAdministrator FROM Users WHERE (Username = @Username)
GO

