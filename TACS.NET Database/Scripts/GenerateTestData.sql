-- =============================================
-- Script Template
-- =============================================
-- CAN ONLY BE USED ON EMPTY DATABASE!

--	1000
INSERT INTO Accounts
                         (AcctName, CreatedOn, ExpireOn)
VALUES        ('MetaCaging',GetDate(),'31-Jan-2015')
go
---	1001
INSERT INTO Accounts
                         (AcctName, CreatedOn, ExpireOn)
VALUES        ('UnitTest',GetDate(),'31-Jan-2030')
go
INSERT INTO Applications
                         (AppCode, AppGuid, AppName)
VALUES        ('MetaCagingApp','Insert GUID here','MetaCaging Web Application')
go
INSERT INTO Applications
                         (AppCode, AppGuid, AppName)
VALUES        ('UnitTestApp','Insert GUID here','TACS.NET Unit Testing')
go
INSERT INTO Projects
						(Project, ConnectorType, DataSource, [Database], Username,
						Password, CreatedOn, AppCode, AcctId)
VALUES		  ('MetaCaging', 'SQL_SERVER', 'ceres.mycspot.local', 'MetaCaging_DEV_Db',
			  'MetaCaging', 'Gocspot123', GetDate(), 'MetaCagingApp', 1000)
go
INSERT INTO Projects
						(Project, ConnectorType, DataSource, [Database], Username,
						Password, CreatedOn, AppCode, AcctId)
VALUES		  ('UnitTest', 'SQL_SERVER', 'xena.cspot-interworks.com', 'TacsDb2',
			  'TacsUnitTest', 'Gocspot123', GetDate(), 'UnitTestApp', 1001)
go
INSERT INTO Roles
						(RoleName, AccessLevel, Project)
VALUES		   ('Developer', 3, 'MetaCaging')
go
INSERT INTO Roles
						(RoleName, AccessLevel, Project)
VALUES		   ('Tester', 2, 'MetaCaging')
go
INSERT INTO Roles
						(RoleName, AccessLevel, Project)
VALUES		   ('Developer', 3, 'UnitTest')
go
INSERT INTO Users
						(Username, Password, FullName, Email, CreatedOn, ExpireOn,
						UserDisabled, AcctId, AccountOwner, SuperAdministrator)
VALUES			('smsullivan', '4DFF85D914B1790F84172C2532156E8D',
				'Sean M. Sullivan', 'sean@mycspot.com', GetDate(), '31-Jan-2012',
				0, 1000, 1, 1)
go
INSERT INTO Users
						(Username, Password, FullName, Email, CreatedOn, ExpireOn,
						UserDisabled, AcctId, AccountOwner, SuperAdministrator)
VALUES			('MetaCaging', '4DFF85D914B1790F84172C2532156E8D',
				'Meta Caging Project', 'khymas@mycspot.com', GetDate(), '31-Jan-2012',
				0, 1000, 1, 0)
go
INSERT INTO Users
						(Username, Password, FullName, Email, CreatedOn, ExpireOn,
						UserDisabled, AcctId, AccountOwner, SuperAdministrator)
VALUES			('UnitTestUser', '4DFF85D914B1790F84172C2532156E8D',
				'Unit Test Program User', 'sean@mycspot.com', GetDate(), '31-Jan-2012',
				0, 1001, 1, 1)
go
INSERT INTO UserProjects
						(RoleId, Project, Username)
VALUES			(1000, 'MetaCaging', 'smsullivan')
go
INSERT INTO UserProjects
						(RoleId, Project, Username)
VALUES			(1000, 'MetaCaging', 'MetaCaging')
go
INSERT INTO UserProjects
						(RoleId, Project, Username)
VALUES			(1002, 'UnitTest', 'UnitTestUser')
go

						