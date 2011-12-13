CREATE PROCEDURE dbo.GetProjectsByApp
(
	@pAppCode varchar(30)
)
AS
	SET NOCOUNT ON;
SELECT Project, ConnectorType, DataSource, [Database], Username, Password, CreatedOn, AppCode, AcctId FROM dbo.Projects WHERE AppCode = @pAppCode ORDER BY Project
GO

