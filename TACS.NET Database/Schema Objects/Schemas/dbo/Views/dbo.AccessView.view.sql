-- Create views section -------------------------------------------------

-- Create views section -------------------------------------------------

-- Create views section -------------------------------------------------

-- Create views section -------------------------------------------------

CREATE VIEW [dbo].[AccessView]
 AS
  SELECT        dbo.Accounts.AcctId, dbo.Accounts.AcctName, dbo.Accounts.ExpireOn AS AcctExpirey, dbo.Projects.Project, dbo.Projects.ConnectorType, dbo.Projects.DataSource, 
                         dbo.Projects.[Database], dbo.Projects.Username AS DbUsername, dbo.Projects.Password AS DbPassword, dbo.Users.Username, dbo.Users.Password, 
                         dbo.Users.FullName, dbo.Users.Email, dbo.Users.ExpireOn AS UserExpirey, dbo.Users.UserDisabled, dbo.Users.SessionToken, dbo.Users.AccountOwner,
                         dbo.Users.SuperAdministrator
FROM            dbo.Accounts INNER JOIN
                         dbo.Projects ON dbo.Accounts.AcctId = dbo.Projects.AcctId INNER JOIN
                         dbo.Users ON dbo.Accounts.AcctId = dbo.Users.AcctId









GO
