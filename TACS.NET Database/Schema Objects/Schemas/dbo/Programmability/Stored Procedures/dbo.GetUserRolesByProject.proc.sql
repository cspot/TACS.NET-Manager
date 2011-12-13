CREATE PROCEDURE dbo.GetUserRolesByProject
(
	@pUsername varchar(40),
	@pProject varchar(40)
)
AS
	SET NOCOUNT ON;
SELECT RoleName, RoleId, Username, AccessLevel, Project FROM dbo.UserRoleView WHERE Username = @pUsername AND Project = @pProject
GO

