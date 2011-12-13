-- Table dbo.EventLog

-- Table dbo.EventLog

-- Table dbo.EventLog

-- Table dbo.EventLog

-- Table dbo.EventLog

CREATE TABLE [dbo].[EventLog]
(
 [LogId] Bigint IDENTITY(1000,1) NOT NULL,
 [EventTime] Datetime NOT NULL,
 [EventSource] Varchar(30) NOT NULL,
 [EventType] Varchar(30) NOT NULL,
 [Message] Varchar(1024) NOT NULL
)














