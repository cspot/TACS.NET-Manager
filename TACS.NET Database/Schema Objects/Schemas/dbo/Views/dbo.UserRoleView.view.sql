CREATE VIEW [dbo].[UserRoleView]
 AS
  SELECT        dbo.Roles.RoleName, dbo.UserProjects.RoleId, dbo.UserProjects.Username, dbo.Roles.AccessLevel, dbo.Roles.Project
FROM            dbo.Roles INNER JOIN
                         dbo.UserProjects ON dbo.Roles.RoleId = dbo.UserProjects.RoleId











