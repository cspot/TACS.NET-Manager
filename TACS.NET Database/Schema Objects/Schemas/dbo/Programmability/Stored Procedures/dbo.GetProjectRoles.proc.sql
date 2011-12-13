CREATE PROCEDURE dbo.GetProjectRoles
(
	@Project varchar(40)
)
AS
	SET NOCOUNT ON;
SELECT RoleId, RoleName, AccessLevel, Project FROM dbo.Roles WHERE Project=@Project ORDER BY RoleName
GO

