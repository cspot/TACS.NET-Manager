CREATE PROCEDURE dbo.WriteEventLogEntry
(
	@EventTime datetime,
	@EventSource varchar(30),
	@EventType varchar(30),
	@Message varchar(1024)
)
AS
	SET NOCOUNT OFF;
INSERT INTO [dbo].[EventLog] ([EventTime], [EventSource], [EventType], [Message]) VALUES (@EventTime, @EventSource, @EventType, @Message);
	
SELECT LogId, EventTime, EventSource, EventType, Message FROM EventLog WHERE (LogId = SCOPE_IDENTITY())
GO

