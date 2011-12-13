CREATE PROCEDURE [dbo].[GetApplicationByCode]
(
	@pAppCode varchar(30)
)
AS
	SET NOCOUNT ON;
	SELECT AppCode, AppGuid, AppName, Description, Contact, Email, Phone, DownloadURL FROM dbo.Applications WHERE AppCode=@pAppCode
GO

