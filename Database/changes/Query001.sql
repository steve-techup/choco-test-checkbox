----
-- https://app.shortcut.com/caretag/story/527/setup-temporal-table-for-instrument-rfid
----

-- create a log table and capture all the changes related to Instrument_RFID table (insert / update / delete) via trigger
-- 
IF NOT EXISTS (SELECT 0 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Instrument_RFID_Log')
BEGIN
	CREATE TABLE [dbo].[Instrument_RFID_Log](
		[Instrument_RFID_Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
		[Instrument_ID] [bigint] NOT NULL,
		[EPC_Nr] [nvarchar](50) NOT NULL,
		[SEQ_Nr] [nvarchar](50) NULL,
		[SERIAL_NR] [nvarchar](255) NULL,
		[Description_ID] [nvarchar](255) NULL,
		[Description_Text] [nvarchar](max) NULL,
		[Instrument_LastSeen_Place] [nvarchar](50) NULL,
		[Instrument_LastSeen_Date] [datetime] NULL,
		[Instrument_InUse] [bit] NULL,
		[Maintance_Code] [int] NULL,
		[Department_ID] [int] NULL,
		[Tray_ID] [bigint] NULL,
		[UDI_Database] [bit] NULL,
		[ChangedOn] [datetime] NOT NULL,
		[ChangedType] [nvarchar](255) NOT NULL,
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO

-----
-- Track Insert & Update changes on Instrument_RFID
-----
CREATE OR ALTER TRIGGER [dbo].[tr_Instrument_RFID] on [dbo].[Instrument_RFID]
AFTER INSERT, UPDATE 
AS 
BEGIN
	DECLARE @changed nvarchar(128) = 'insert';
	IF EXISTS (SELECT 0 FROM deleted)
		SET @changed = 'update';

	INSERT INTO [dbo].[Instrument_RFID_Log]
			   (Instrument_ID
			   ,[EPC_Nr]
			   ,[SEQ_Nr]
			   ,[SERIAL_NR]
			   ,[Description_ID]
			   ,[Description_Text]
			   ,[Instrument_LastSeen_Place]
			   ,[Instrument_LastSeen_Date]
			   ,[Instrument_InUse]
			   ,[Maintance_Code]
			   ,[Department_ID]
			   ,[Tray_ID]
			   ,[UDI_Database]
			   ,[ChangedOn]
			   ,[ChangedType])
		 Select 
				Instrument_ID
			   ,[EPC_Nr]
			   ,[SEQ_Nr]
			   ,[SERIAL_NR]
			   ,[Description_ID]
			   ,[Description_Text]
			   ,[Instrument_LastSeen_Place]
			   ,[Instrument_LastSeen_Date]
			   ,[Instrument_InUse]
			   ,[Maintance_Code]
			   ,[Department_ID]
			   ,[Tray_ID]
			   ,[UDI_Database]
			   , GetDate()
			   , @changed
		  From inserted;
END
GO

ALTER TABLE [dbo].[Instrument_RFID] ENABLE TRIGGER [tr_Instrument_RFID]
GO
