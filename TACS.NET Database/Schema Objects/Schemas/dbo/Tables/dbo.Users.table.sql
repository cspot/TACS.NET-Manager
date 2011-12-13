-- Table dbo.Users

-- Table dbo.Users

-- Table dbo.Users

-- Table dbo.Users

-- Table dbo.Users

-- Table dbo.Users

-- Table dbo.Users

-- Table dbo.Users

CREATE TABLE [dbo].[Users]
(
 [Username] Varchar(40) NOT NULL,
 [Password] Varchar(40) NOT NULL,
 [FullName] Varchar(40) NULL,
 [Email] Varchar(80) NULL,
 [CreatedOn] Datetime NULL,
 [ExpireOn] Datetime NULL,
 [AccountOwner] Bit NOT NULL,
 [SuperAdministrator] Bit DEFAULT 0 NOT NULL,
 [UserDisabled] Bit NOT NULL,
 [SessionToken] Varchar(32) NULL,
 [AcctId] Bigint NOT NULL
)






































