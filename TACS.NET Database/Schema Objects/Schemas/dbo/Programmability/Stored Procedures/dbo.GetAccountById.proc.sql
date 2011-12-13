CREATE PROCEDURE dbo.GetAccountById
(
	@pAcctId bigint
)
AS
	SET NOCOUNT ON;
SELECT AcctId, AcctName, Contact, Address1, Address2, City, State, ZipCode, Email, Phone, CreatedOn, ExpireOn FROM dbo.Accounts WHERE AcctId=@pAcctId
GO

