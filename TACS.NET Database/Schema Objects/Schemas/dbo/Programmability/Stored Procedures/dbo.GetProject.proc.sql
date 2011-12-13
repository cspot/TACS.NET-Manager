CREATE PROCEDURE dbo.GetProject
(
	@pProject varchar(40)
)
AS
	SET NOCOUNT ON;
SELECT Project, ConnectorType, DataSource, [Database], Username, Password, CreatedOn, AppCode, AcctId FROM dbo.Projects WHERE Project=@pProject
GO

