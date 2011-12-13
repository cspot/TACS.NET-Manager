CREATE PROCEDURE [dbo].[Login]
(
	@pProject varchar(40),
	@pUsername varchar(40),
	@pPassword varchar(40)
)
AS
	SET NOCOUNT ON;
SELECT AcctId, AcctName, AcctExpirey, Project, ConnectorType, DataSource, [Database], DbUsername, DbPassword, Username, Password, FullName, Email, UserExpirey, UserDisabled, SessionToken, AccountOwner, SuperAdministrator FROM dbo.AccessView WHERE Project=@pProject AND Username=@pUsername AND Password=@pPassword
GO

