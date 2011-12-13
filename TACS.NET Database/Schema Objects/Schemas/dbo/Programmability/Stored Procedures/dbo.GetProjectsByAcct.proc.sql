CREATE PROCEDURE dbo.GetProjectsByAcct
(
	@pAcctId bigint
)
AS
	SET NOCOUNT ON;
SELECT Project, ConnectorType, DataSource, [Database], Username, Password, CreatedOn, AppCode, AcctId FROM dbo.Projects WHERE AcctId=@pAcctId ORDER BY Project
GO

