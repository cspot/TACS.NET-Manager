CREATE VIEW [dbo].[AppProjectsView]
 AS
  SELECT        dbo.Applications.AppCode, dbo.Applications.AppGuid, dbo.Applications.AppName, dbo.Applications.DownloadURL, dbo.Projects.Project, 
                         dbo.Projects.ConnectorType, dbo.Projects.DataSource, dbo.Projects.[Database], dbo.Projects.Username, dbo.Projects.Password, dbo.Projects.AcctId
FROM            dbo.Applications INNER JOIN
                         dbo.Projects ON dbo.Applications.AppCode = dbo.Projects.AppCode









GO
