-- Table dbo.Projects

-- Table dbo.Projects

-- Table dbo.Projects

-- Table dbo.Projects

-- Table dbo.Projects

-- Table dbo.Projects

-- Table dbo.Projects

-- Table dbo.Projects

CREATE TABLE [dbo].[Projects]
(
 [Project] Varchar(40) NOT NULL,
 [ConnectorType] Varchar(30) NOT NULL
        CONSTRAINT [ValidValuesConnectorType] CHECK (([ConnectorType] IN ('SQL_SERVER','MYSQL'))),
 [DataSource] Varchar(40) NOT NULL,
 [Database] Varchar(40) NOT NULL,
 [Username] Varchar(30) NULL,
 [Password] Varchar(30) NULL,
 [CreatedOn] Datetime NULL,
 [AppCode] Varchar(30) NOT NULL,
 [AcctId] Bigint NOT NULL
)






































