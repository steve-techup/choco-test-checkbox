SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Action_Description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Action_Description](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Action_Name] [nvarchar](64) NULL,
	[Department_ID] [bigint] NULL,
	[UserID] [int] NULL,
	[Action_Date] [datetime] NULL,
	[Action_Type] [nvarchar](50) NULL,
	[Action_Type_ID] [bigint] NULL,
	[Action_Done] [bit] NOT NULL,
	[Date_Changed] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Action_Type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Action_Type](
	[Action_Type_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Action_Type_Description] [nvarchar](max) NULL,
	[Only_Administrator] [bit] NOT NULL,
	[Is_Hidden] [bit] NOT NULL,
	[Can_Expired] [int] NOT NULL,
	[Date_Changed] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Antenna_Reader]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Antenna_Reader](
	[Antenna_ID] [int] IDENTITY(1,1) NOT NULL,
	[Reader_ID] [smallint] NOT NULL,
	[Antenna_Area_ID] [bigint] NULL,
	[Antenna_Name] [nvarchar](50) NULL,
	[Antenna_Type] [nvarchar](50) NULL,
	[Antenna_Location] [nvarchar](max) NULL,
	[Antenna_Factor] [smallint] NULL,
	[Antenna_Description] [nvarchar](max) NULL,
	[In_Use] [nchar](10) NULL,
	[StartDate] [datetime] NULL,
 CONSTRAINT [PK_Antenna_Reader] PRIMARY KEY CLUSTERED 
(
	[Antenna_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Area_Name_List]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Area_Name_List](
	[Area_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Area_Name] [nvarchar](50) NULL,
	[Area_Description] [nvarchar](max) NULL,
	[Area_Map_Name] [nvarchar](50) NULL,
	[TheMap] [varbinary](max) NULL,
	[Date_Changed] [datetime] NULL,
 CONSTRAINT [PK_Area_Name_List] PRIMARY KEY CLUSTERED 
(
	[Area_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cart_Description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cart_Description](
	[Description_ID] [int] IDENTITY(1,1) NOT NULL,
	[Cart_Name] [nvarchar](50) NULL,
	[Cart_Description] [nvarchar](max) NULL,
	[Cart_Lock] [bit] NULL,
	[Date_Changed] [datetime] NULL,
 CONSTRAINT [PK_Cart_Description] PRIMARY KEY CLUSTERED 
(
	[Description_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cart_RFID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cart_RFID](
	[Cart_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[SEQ_Nr] [nvarchar](50) NULL,
	[Description_ID] [int] NULL,
	[Special_Text] [nvarchar](max) NULL,
	[Cart_Contents] [int] NULL,
	[Cart_LastSeen_Place] [nvarchar](50) NULL,
	[Cart_LastSeen_Date] [datetime] NULL,
	[Cart_InUse] [bit] NULL,
	[Cart_Changed] [datetime] NULL,
 CONSTRAINT [PK_Cart_RFID] PRIMARY KEY CLUSTERED 
(
	[Cart_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cart_RFID_Life]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cart_RFID_Life](
	[EPC_Nr] [nvarchar](50) NOT NULL,
	[Description_ID] [nvarchar](255) NULL,
	[Date_Birth] [datetime] NOT NULL,
	[Date_End] [datetime] NULL,
	[Last_Service] [datetime] NULL,
	[Return_Service] [datetime] NULL,
	[Number_Service] [int] NULL,
	[Wash_Counter] [int] NULL,
	[Steri_In] [datetime] NULL,
	[Steri_Out] [datetime] NULL,
	[Steri_Name] [nvarchar](255) NULL,
	[OR_In] [datetime] NULL,
	[OR_Out] [datetime] NULL,
	[OR_Name] [nvarchar](255) NULL,
	[Used_In_OR] [int] NULL,
	[Passed_Steri] [int] NULL,
	[Last_Change] [datetime] NULL,
 CONSTRAINT [PK_Cart_RFID_Life] PRIMARY KEY CLUSTERED 
(
	[EPC_Nr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckBox_OR_Item_Sync]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CheckBox_OR_Item_Sync](
	[Sync_ID] [nvarchar](50) NULL,
	[Light_ID] [nvarchar](50) NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Tray_ID] [bigint] NULL,
	[Insert_Place] [nvarchar](50) NULL,
	[Insert_Time] [datetime] NULL,
	[Read_Tag] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckBox_OR_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CheckBox_OR_Log](
	[EPC_Nr] [nvarchar](50) NOT NULL,
	[CheckBox_Function] [nvarchar](50) NULL,
	[Area_ID] [bigint] NULL,
	[Tray_ID] [bigint] NULL,
	[Tray_Locked] [bit] NULL,
	[OR_Relation] [nvarchar](max) NULL,
	[Total_OR_Time] [bigint] NULL,
	[Instr_OR_Time] [bigint] NULL,
	[ChangeDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckBox_OR_Sync]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CheckBox_OR_Sync](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Synchronization] [bit] NULL,
	[Check_IN_ID] [bigint] NULL,
	[Check_IN_Light] [nvarchar](50) NULL,
	[Check_IN_Number] [int] NULL,
	[Check_IN_Start] [datetime] NULL,
	[Check_IN_End] [datetime] NULL,
	[Check_IN_Closed] [bit] NULL,
	[Check_OUT_ID] [bigint] NULL,
	[Check_OUT_Number] [int] NULL,
	[Check_OUT_Start] [datetime] NULL,
	[Check_OUT_End] [datetime] NULL,
	[Check_OUT_Closed] [bit] NULL,
	[Check_IN_Waiting] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckBox_SPD_Item_Sync]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CheckBox_SPD_Item_Sync](
	[Sync_ID] [nvarchar](50) NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Insert_Place] [nvarchar](50) NULL,
	[Insert_Time] [datetime] NULL,
	[Read_Tag] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckBox_SPD_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CheckBox_SPD_Log](
	[Instrument_ID] [bigint] NOT NULL,
	[CheckBox_Function] [nchar](20) NULL,
	[Area_ID] [bigint] NULL,
	[Tray_ID] [bigint] NULL,
	[Tray_Locked] [bit] NULL,
	[SPD_Relation] [nvarchar](max) NULL,
	[ChangeDate] [datetime] NULL,
	[Ext_Machine_1] [nvarchar](max) NULL,
	[Ext_Machine_2] [nvarchar](max) NULL,
	[Ext_Machine_3] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CheckBox_SPD_Sync]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CheckBox_SPD_Sync](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Synchronization] [bit] NULL,
	[Check_IN_ID] [bigint] NULL,
	[Check_IN_Number] [int] NULL,
	[Check_IN_Start] [datetime] NULL,
	[Check_IN_End] [datetime] NULL,
	[Check_IN_Closed] [bit] NULL,
	[Check_OUT_ID] [bigint] NULL,
	[Check_OUT_Number] [int] NULL,
	[Check_OUT_Start] [datetime] NULL,
	[Check_OUT_End] [datetime] NULL,
	[Check_OUT_Closed] [bit] NULL,
	[Check_IN_Waiting] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConfigTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ConfigTable](
	[ConfigID] [int] IDENTITY(1,1) NOT NULL,
	[TableName] [nvarchar](50) NOT NULL,
	[ValueColumStart] [int] NOT NULL,
	[AllowDelete] [bit] NOT NULL,
	[AllowInsert] [bit] NOT NULL,
	[ChangeDate] [smalldatetime] NULL,
 CONSTRAINT [PK_ConfigTable] PRIMARY KEY CLUSTERED 
(
	[ConfigID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Container_Description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Container_Description](
	[Description_ID] [int] IDENTITY(1,1) NOT NULL,
	[Container_Name] [nvarchar](50) NULL,
	[Container_Description] [nvarchar](max) NULL,
	[Container_Lock] [bit] NOT NULL,
	[Date_Changed] [datetime] NULL,
 CONSTRAINT [PK_Container_Description] PRIMARY KEY CLUSTERED 
(
	[Description_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Container_RFID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Container_RFID](
	[Container_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[SEQ_Nr] [nvarchar](50) NULL,
	[Description_ID] [int] NULL,
	[Special_Text] [nvarchar](max) NULL,
	[Container_Contents] [int] NULL,
	[Cart_ID] [bigint] NULL,
	[Tray_ID] [bigint] NULL,
	[Container_LastSeen_Place] [nvarchar](50) NULL,
	[Container_LastSeen_Date] [datetime] NULL,
	[Container_InUse] [bit] NULL,
	[Container_Changed] [datetime] NULL,
 CONSTRAINT [PK_Container_RFID] PRIMARY KEY CLUSTERED 
(
	[Container_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Container_RFID_Life]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Container_RFID_Life](
	[EPC_Nr] [nvarchar](50) NOT NULL,
	[Description_ID] [nvarchar](255) NULL,
	[Date_Birth] [datetime] NOT NULL,
	[Date_End] [datetime] NULL,
	[Last_Service] [datetime] NULL,
	[Return_Service] [datetime] NULL,
	[Number_Service] [int] NULL,
	[Wash_Counter] [int] NULL,
	[Steri_In] [datetime] NULL,
	[Steri_Out] [datetime] NULL,
	[Steri_Name] [nvarchar](255) NULL,
	[OR_In] [datetime] NULL,
	[OR_Out] [datetime] NULL,
	[OR_Name] [nvarchar](255) NULL,
	[Used_In_OR] [int] NULL,
	[Passed_Steri] [int] NULL,
	[Last_Change] [datetime] NULL,
 CONSTRAINT [PK_Container_RFID_Life] PRIMARY KEY CLUSTERED 
(
	[EPC_Nr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cost_Center]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cost_Center](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Cost_Center_Name] [nvarchar](max) NOT NULL,
	[Cost_Center_Code] [nvarchar](max) NULL,
	[Extra_Text] [nvarchar](max) NULL,
	[Hidden_Center] [bit] NULL,
	[Default_Always] [bit] NULL,
	[Change_Date] [datetime] NULL,
 CONSTRAINT [PK_Cost_Center] PRIMARY KEY CLUSTERED 
(
	[Index_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cost_Item]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cost_Item](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Cost_Center] [bigint] NOT NULL,
	[Cost_Type_ID] [bigint] NULL,
	[Default_Cost] [bit] NULL,
	[Change_Date] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cost_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cost_Log](
	[Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Cost_Center] [bigint] NOT NULL,
	[Cost_Item] [bigint] NOT NULL,
	[The_Item_ID] [bigint] NULL,
	[The_Tray_Log_ID] [bigint] NULL,
	[Extra_Text] [nvarchar](max) NULL,
	[Reader_ID] [int] NULL,
	[Used_Date] [datetime] NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cost_Type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cost_Type](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Cost_Type] [nvarchar](max) NULL,
	[Cost_Price] [decimal](18, 2) NULL,
	[Change_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Demand_Service_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Demand_Service_Log](
	[Demand_Service_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Description_ID] [nvarchar](255) NULL,
	[Demand_Text_ID] [bigint] NULL,
	[Rules_ID_String] [nvarchar](max) NULL,
	[Insert_Place] [nvarchar](50) NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Demand_Text]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Demand_Text](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[The_Text] [nvarchar](max) NOT NULL,
	[Text_Hidden] [bit] NULL,
	[Change_Date] [datetime] NULL,
 CONSTRAINT [PK_Demand_Text] PRIMARY KEY CLUSTERED 
(
	[Index_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Department](
	[Department_ID] [int] IDENTITY(1,1) NOT NULL,
	[Department_Name] [nvarchar](max) NULL,
	[Department_Code] [nvarchar](max) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Department_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Disposables_Description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Disposables_Description](
	[Description_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Disposables_External] [nvarchar](max) NULL,
	[Description_Text] [nvarchar](max) NULL,
	[Manufactor] [nvarchar](250) NULL,
	[Numbers] [int] NULL,
	[Cost_Factor] [decimal](18, 2) NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Disposables_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Disposables_Log](
	[Disposables_ID] [bigint] NULL,
	[Disposables_External] [nvarchar](max) NULL,
	[OR_Relation] [nvarchar](max) NULL,
	[Used_Place] [nvarchar](250) NULL,
	[ChangeDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EPC_Number_Serie]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EPC_Number_Serie](
	[Owner_Ship] [nvarchar](max) NOT NULL,
	[Owner_Serie] [nvarchar](50) NOT NULL,
	[Customer_Number] [nchar](10) NOT NULL,
	[Special_Number] [nchar](10) NULL,
	[Max_Number] [int] NULL,
	[Start_EPC] [nvarchar](max) NOT NULL,
	[New_EPC] [nvarchar](max) NULL,
	[Last_Used_EPC] [nvarchar](max) NULL,
	[Confirm_To_GS1] [bit] NULL,
	[Last_Used_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exchange_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Exchange_Log](
	[EPC_Nr] [nvarchar](50) NOT NULL,
	[Exchange_ID] [bigint] NULL,
	[Employee_ID] [int] NOT NULL,
	[Exchange_Date] [datetime] NULL,
	[Exchange_Return_Date] [datetime] NULL,
	[Exchange_Number] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Exchange_Table]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Exchange_Table](
	[Exchange_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Employee_ID] [int] NULL,
	[Exchange_Date] [datetime] NULL,
	[Exchange_Return_Date] [datetime] NULL,
	[Exchange_Place_ID] [bigint] NULL,
	[Exchange_Number] [int] NOT NULL,
	[Is_Missing] [bit] NOT NULL,
	[Change_Date] [datetime] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Gate_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Gate_Log](
	[EPC_Nr] [nvarchar](50) NULL,
	[Gate_Time] [datetime] NOT NULL,
	[Gate_Place] [nvarchar](50) NULL,
	[Reader_ID] [bigint] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Code]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Code](
	[Code_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description_ID] [nvarchar](max) NULL,
	[Code] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Description](
	[Description_ID] [nvarchar](255) NOT NULL,
	[Instrument_Company] [nvarchar](255) NULL,
	[Description_Name] [nvarchar](255) NULL,
	[D] [nvarchar](255) NULL,
	[E] [nvarchar](255) NULL,
	[Treatment_ID] [bigint] NULL,
	[Date_Changed] [datetime] NULL,
	[Vendor_ID] [int] NOT NULL,
 CONSTRAINT [PK__Instrume__8D2B489D656C112C] PRIMARY KEY CLUSTERED 
(
	[Description_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_External]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_External](
	[Description_ID] [nvarchar](255) NOT NULL,
	[External_ID] [nvarchar](255) NOT NULL,
	[External_Description] [nvarchar](255) NULL,
	[Date_Changed] [datetime] NULL,
 CONSTRAINT [PK_Instrument_External] PRIMARY KEY CLUSTERED 
(
	[Description_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Group]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Group](
	[Group_ID] [int] IDENTITY(1,1) NOT NULL,
	[Group_Description] [nvarchar](max) NOT NULL,
	[Group_Identifier] [nchar](10) NOT NULL,
	[Last_Date_Change] [datetime] NULL,
 CONSTRAINT [PK_Instrument_Group] PRIMARY KEY CLUSTERED 
(
	[Group_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Image]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Image](
	[Image_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TheImage] [varbinary](max) NULL,
	[Description_ID] [nvarchar](255) NULL,
	[Date_Changed] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Maintenance_RFID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Maintenance_RFID](
	[Maintenance_RFID_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EPC_Nr] [nvarchar](50) NOT NULL,
	[Description_ID] [nvarchar](255) NULL,
	[Rules_ID] [bigint] NULL,
	[Check_Ciffer] [int] NULL,
	[Maintenance_Period_Start] [datetime] NULL,
	[Reset_Check_Ciffer] [bit] NULL,
	[Check_Status] [bit] NULL,
	[Sendt_To_Service] [bit] NULL,
	[Return_From_Service] [bit] NULL,
	[ServiceVendor_ID] [int] NULL,
	[Service_Counter] [int] NULL,
	[Service_Date] [datetime] NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Packed_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Packed_Log](
	[The_Log_ID] [bigint] NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_ReCall]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_ReCall](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description_ID] [nvarchar](255) NULL,
	[ReCall_Name] [nvarchar](max) NULL,
	[ReCall_Type] [nvarchar](50) NULL,
	[ReCall_From] [datetime] NULL,
	[ReCall_Deleted] [bit] NOT NULL,
	[Special_Text] [nvarchar](255) NOT NULL,
	[Total_Population] [bigint] NULL,
	[Numbers_Recall] [bigint] NULL,
	[Changed_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_RFID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_RFID](
	[Instrument_ID] [bigint] IDENTITY(1,1) NOT NULL,
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
	[UDI_Database] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_RFID_History]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_RFID_History](
	[EPC_Nr] [nvarchar](50) NULL,
	[Instrument_InUse] [int] NULL,
	[Last_Seen] [nvarchar](50) NULL,
	[Now_Seen] [nvarchar](50) NULL,
	[Last_Seen_Date] [datetime] NULL,
	[Change_Date] [datetime] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_RFID_Life]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_RFID_Life](
	[EPC_Nr] [nvarchar](50) NOT NULL,
	[Description_ID] [nvarchar](255) NULL,
	[Date_Birth] [datetime] NOT NULL,
	[Date_End] [datetime] NULL,
	[Demand_Service_Number] [int] NULL,
	[Demand_Service] [datetime] NULL,
	[Demand_Log] [int] NULL,
	[Sent_To_Service] [bit] NULL,
	[Sent_Service] [datetime] NULL,
	[Return_Service] [datetime] NULL,
	[Number_Service] [int] NULL,
	[DaysInService] [int] NULL,
	[ServiceVendor_ID] [int] NULL,
	[Wash_Counter] [int] NULL,
	[Steri_In] [datetime] NULL,
	[Steri_Out] [datetime] NULL,
	[Steri_Name] [nvarchar](255) NULL,
	[OR_In] [datetime] NULL,
	[OR_Out] [datetime] NULL,
	[OR_Name] [nvarchar](255) NULL,
	[Used_In_OR] [int] NULL,
	[Passed_Steri] [int] NULL,
	[Last_Change] [datetime] NULL,
 CONSTRAINT [PK_Instrument_RFID_Life] PRIMARY KEY CLUSTERED 
(
	[EPC_Nr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Rules]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Rules](
	[Rules_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description_ID] [nvarchar](255) NULL,
	[Default_Rule] [bit] NULL,
	[Maintenance_Text] [nvarchar](max) NULL,
	[Maintenance_Value] [smallint] NULL,
	[Maintenance_Periods] [smallint] NULL,
	[Maintenance_Period_Start] [datetime] NULL,
	[Maintenance_Alarm] [bit] NULL,
	[Deleted] [bit] NULL,
	[ChangeDate] [datetime] NULL,
 CONSTRAINT [PK_Instrument_Rules] PRIMARY KEY CLUSTERED 
(
	[Rules_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Translation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Translation](
	[Caretag_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description_Name] [nvarchar](max) NULL,
	[ChangeDate] [datetime] NULL,
	[Vendor_ID_1] [nvarchar](50) NULL,
	[Vendor_ID_2] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Translation_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Translation_Log](
	[Instrument_Translation_Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[The_Item] [nvarchar](50) NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Translation_Vendor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Translation_Vendor](
	[The_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[The_Last_Vendor_Index] [nchar](10) NULL,
	[ChangeDate] [datetime] NULL,
	[Vendor_Name_1] [nvarchar](50) NULL,
	[Vendor_Name_2] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Instrument_Vendor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Instrument_Vendor](
	[Vendor_ID] [int] IDENTITY(1,1) NOT NULL,
	[Vendor_Name] [nvarchar](max) NOT NULL,
	[Vendor_Abbreviation] [nchar](10) NOT NULL,
	[Barcode_Prefix] [int] NULL,
	[Barcode_Suffix] [int] NULL,
	[Delimiter_Sign] [nchar](10) NULL,
	[Last_Date_Change] [datetime] NULL,
 CONSTRAINT [PK_Instrument_Vendor] PRIMARY KEY CLUSTERED 
(
	[Vendor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lend_Entity]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Lend_Entity](
	[Lend_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Lend_Name] [nvarchar](max) NULL,
	[Lend_Email] [nchar](255) NULL,
	[Lend_Company_ID] [bigint] NOT NULL,
	[Lend_Department] [nchar](255) NULL,
	[Lend_Address] [nchar](255) NULL,
	[Lend_ZIP] [nchar](10) NULL,
	[Lend_City] [nchar](255) NULL,
	[Lend_State] [nchar](255) NULL,
	[Lend_Country] [nchar](255) NULL,
	[Change_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lend_Instrument]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Lend_Instrument](
	[Lend_Instrument_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Lend_Description] [nvarchar](max) NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[LOT] [nvarchar](max) NULL,
	[Batch_Number] [nvarchar](max) NULL,
	[Lend_In_Coming] [bit] NULL,
	[Lend_OUT_Going] [bit] NULL,
	[Lend_ID] [bigint] NULL,
	[Lend_Receive_Date] [datetime] NULL,
	[Lend_Return_Date] [datetime] NULL,
	[Lend_Place] [nvarchar](max) NULL,
	[External_ID] [nvarchar](max) NULL,
	[External_KIT] [bit] NULL,
	[Digi_Sign_IN] [bit] NULL,
	[Digi_Sign_OUT] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Lend_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Lend_Log](
	[UserID] [int] NULL,
	[Lend_ID] [bigint] NULL,
	[Lend_IN] [bit] NULL,
	[IN_OUT_Issue] [bit] NULL,
	[OR_Relation] [nvarchar](max) NULL,
	[ChangeDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Log_Change]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Log_Change](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[Change_Date] [date] NULL,
	[User_Name] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Login_Security]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Login_Security](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Program_Name] [nvarchar](50) NOT NULL,
	[The_Security] [int] NULL,
	[Default_Security] [int] NULL,
	[Special_Text] [nvarchar](max) NULL,
	[Date_Changed] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LogIn_Table]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LogIn_Table](
	[Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Connect_ID] [bigint] NULL,
	[Log_Type] [nchar](10) NULL,
	[UserName] [nvarchar](50) NULL,
	[Log_Place] [nvarchar](50) NULL,
	[Log_Time] [datetime] NULL,
 CONSTRAINT [PK_Log_Table] PRIMARY KEY CLUSTERED 
(
	[Log_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Not_Known_RFID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Not_Known_RFID](
	[Not_Known_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Not_Known_LastSeen_Place] [nvarchar](50) NULL,
	[Not_Known_LastSeen_Date] [datetime] NULL,
	[Not_Known_InUse] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OR_Procedure]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OR_Procedure](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Cost_Center] [nvarchar](max) NULL,
	[Procedure_ID] [nvarchar](max) NULL,
	[Procedure_Name] [nvarchar](max) NULL,
	[Cost_Center_ID] [bigint] NULL,
	[Hidden] [bit] NULL,
	[External_ID] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[Date_Changed] [datetime] NULL,
 CONSTRAINT [PK_OR_Trays_Descriptions] PRIMARY KEY CLUSTERED 
(
	[Index_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OR_Trays_ID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OR_Trays_ID](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OR_Procedure_ID] [bigint] NULL,
	[Tray_ID] [bigint] NULL,
	[Numbers] [int] NOT NULL,
	[Date_Changed] [datetime] NULL,
 CONSTRAINT [PK_OR:Trays_ID] PRIMARY KEY CLUSTERED 
(
	[Index_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Procedure_Demand_List]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Procedure_Demand_List](
	[Demand_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Time_Arrived] [datetime] NOT NULL,
	[Desired_Date] [datetime] NULL,
	[Priority] [int] NOT NULL,
	[Packed_Day] [datetime] NULL,
	[Cost_Center_ID] [int] NULL,
	[Procedure_ID] [nvarchar](max) NULL,
	[Note] [nvarchar](max) NULL,
	[Date_Changed] [datetime] NOT NULL,
	[Is_Used] [datetime] NULL,
	[Sent_To_PackList] [bit] NULL,
	[User_Name] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reader_Description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reader_Description](
	[Reader_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Reader_Name] [nvarchar](50) NOT NULL,
	[Area_ID] [bigint] NULL,
	[Reader_Description] [nvarchar](max) NULL,
	[Reader_Attach] [bit] NULL,
	[In_Use] [nchar](10) NULL,
	[CheckBox_IN] [bit] NULL,
	[IP_Address] [nvarchar](50) NULL,
	[External_IP_Address] [nvarchar](50) NULL,
	[Last_Edited] [datetime] NOT NULL,
	[Start_Date] [datetime] NOT NULL,
	[ReaderGuid] [uniqueidentifier] NULL,
	[SoftwareVersion] [nvarchar](50) NULL,
	[Location] [nvarchar](50) NULL,
	[Last_Stand] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reader_Description] PRIMARY KEY CLUSTERED 
(
	[Reader_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Reader_ErrorLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Reader_ErrorLog](
	[ErrorLog_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Department_ID] [int] NULL,
	[Reader_ID] [bigint] NOT NULL,
	[Error_Description] [nvarchar](max) NULL,
	[ChangeDate] [datetime] NULL,
	[IP_Address] [nvarchar](50) NULL,
 CONSTRAINT [PK_Reader_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ErrorLog_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReCall_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReCall_Log](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Log_Text] [nvarchar](max) NULL,
	[UserID] [nvarchar](50) NULL,
	[Changed_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Rules_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Rules_Log](
	[Rules_Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Rules_ID] [bigint] NULL,
	[Types_Service] [nvarchar](50) NULL,
	[ServiceVendor_ID] [int] NULL,
	[ChangeDate] [datetime] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Service_Connections]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Service_Connections](
	[Service_Connection_ID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceVendor_ID] [int] NULL,
	[Service_Connection] [nvarchar](max) NULL,
	[Connection_Code] [uniqueidentifier] NULL,
	[PassCode] [nvarchar](max) NULL,
	[LastLogin] [datetime] NULL,
	[NumberLogins] [int] NULL,
	[Connection_InUse] [bit] NOT NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Service_Connections_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Service_Connections_Log](
	[Service_Connection_ID] [int] NULL,
	[ServiceVendor_ID] [int] NULL,
	[Instrument_ID] [bigint] NULL,
	[Service_Start] [datetime] NULL,
	[Service_Finish] [datetime] NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Service_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Service_Log](
	[Service_Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Rules_ID] [bigint] NULL,
	[ServiceVendor_ID] [int] NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Service_Vendor]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Service_Vendor](
	[ServiceVendor_ID] [int] IDENTITY(1,1) NOT NULL,
	[Vendor_Name] [nvarchar](max) NOT NULL,
	[Vendor_Street_1] [nvarchar](max) NULL,
	[Vendor_Street_2] [nvarchar](max) NULL,
	[Vendor_City] [nvarchar](50) NULL,
	[Vendor_Zip_Code] [nvarchar](50) NULL,
	[Vendor_Country] [nvarchar](50) NULL,
	[Special_Text] [nvarchar](max) NULL,
	[Changed_Date] [datetime] NULL,
 CONSTRAINT [PK_Service_Vendor] PRIMARY KEY CLUSTERED 
(
	[ServiceVendor_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SPD_Machine]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SPD_Machine](
	[Machine_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Machine_Name] [nvarchar](50) NOT NULL,
	[Area_ID] [bigint] NOT NULL,
	[Machine_Number] [nvarchar](max) NOT NULL,
	[Machine_Info] [nvarchar](max) NULL,
	[Speciel_Text] [nvarchar](max) NULL,
	[Last_Time_Used] [datetime] NULL,
	[Change_Date] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Steril_Central]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Steril_Central](
	[SterilCentral_ID] [int] IDENTITY(1,1) NOT NULL,
	[Steril_Name] [nvarchar](max) NOT NULL,
	[Steril_Street_1] [nvarchar](max) NULL,
	[Steril_Street_2] [nvarchar](max) NULL,
	[Steril_City] [nvarchar](50) NULL,
	[Steril_Zip_Code] [nvarchar](50) NULL,
	[Steril_Country] [nvarchar](50) NULL,
	[Special_Text] [nvarchar](max) NULL,
	[The_Logo] [varbinary](max) NULL,
	[Changed_Date] [datetime] NULL,
 CONSTRAINT [PK_Steril_Central] PRIMARY KEY CLUSTERED 
(
	[SterilCentral_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Stop_Instrument]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Stop_Instrument](
	[Stop_ID] [int] IDENTITY(1,1) NOT NULL,
	[Stop_Descripting] [nvarchar](max) NULL,
	[Stop_Action] [smallint] NULL,
	[Changed_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Storage_Item]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Storage_Item](
	[EPC_Nr] [nvarchar](50) NOT NULL,
	[Storage_ID] [bigint] NULL,
	[Is_Checked_OUT] [bit] NOT NULL,
	[Tray_ID] [bigint] NULL,
	[Container_ID] [bigint] NULL,
	[Cart_ID] [bigint] NULL,
	[Date_Changed] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Storage_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Storage_Log](
	[Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Tray_ID] [bigint] NULL,
	[Container_ID] [bigint] NULL,
	[Returned] [bit] NULL,
	[Date_Changed] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Storage_Station]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Storage_Station](
	[Storage_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Reestablish_ID] [bigint] NULL,
	[Station_Name] [nvarchar](50) NULL,
	[Reader_ID] [bigint] NULL,
	[Date_Changed] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SW_Update]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SW_Update](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Software_Name] [nvarchar](max) NULL,
	[SW_Path] [nvarchar](max) NOT NULL,
	[Mandatory] [bit] NULL,
	[Blocked_Use] [bit] NULL,
	[Update_Time_Start] [int] NULL,
	[Update_Time_End] [int] NULL,
	[Update_Code] [nvarchar](50) NULL,
	[Changed_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SystemInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SystemInfo](
	[ID] [int] NOT NULL,
	[SoftwareName] [nvarchar](50) NULL,
	[SoftwareVersion] [nvarchar](50) NULL,
	[Mandatory] [bit] NULL,
	[Copyrights] [nvarchar](50) NULL,
	[PackingSt_Counter] [bit] NULL,
	[Security_Code] [bit] NULL,
	[TechnicalST_Locked] [bit] NULL,
	[Unique_Rules] [bit] NULL,
	[GateNameSwitch] [bit] NULL,
	[UDI_Database] [nvarchar](max) NULL,
	[Path_To_Files] [nvarchar](max) NULL,
	[AdgangsKode] [nvarchar](max) NULL,
	[Use_Cost_Center] [bit] NULL,
	[Use_Login] [bit] NULL,
	[Use_ActiveDirectory] [bit] NULL,
	[Login_Verification] [nvarchar](max) NULL,
	[Device_Numbers] [nvarchar](max) NULL,
	[Use_Action] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPassword]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TblPassword](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[FamilyName] [nvarchar](50) NULL,
	[UserName] [nvarchar](50) NULL,
	[PassCode] [nvarchar](max) NULL,
	[UserGuid] [uniqueidentifier] NULL,
	[RFID_Code] [nvarchar](max) NULL,
	[SEQ_Code] [nvarchar](max) NULL,
	[Log_ID] [bigint] NULL,
	[LastLogin] [datetime] NULL,
	[NumberLogins] [int] NULL,
	[WindowsUser] [nvarchar](50) NULL,
	[DashBoard] [bit] NULL,
	[DashBoardAdmin] [bit] NULL,
	[SecurityLevel] [smallint] NULL,
	[Using_Action] [bit] NULL,
	[ChangedBy] [nvarchar](50) NULL,
	[ChangeDate] [datetime] NULL,
	[User_LastSeen_Date] [datetime] NULL,
	[User_LastSeen_Place] [nvarchar](50) NULL,
 CONSTRAINT [PK_tblPassword] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Technical_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Technical_Log](
	[Technical_Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Description_ID] [nvarchar](50) NULL,
	[Technical_Type] [nvarchar](50) NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tray_Description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tray_Description](
	[Description_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Tray_Name] [nvarchar](50) NULL,
	[Tray_Description] [nvarchar](max) NULL,
	[Tray_Lock] [bit] NULL,
	[Date_Changed] [datetime] NULL,
	[Hide_Tray] [bit] NULL,
	[Deleted_Tray] [bit] NULL,
	[Special_Text] [nvarchar](max) NULL,
	[Cost_ID] [int] NOT NULL,
 CONSTRAINT [PK_Tray_Description] PRIMARY KEY CLUSTERED 
(
	[Description_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tray_Image]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tray_Image](
	[Image_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[TheImage] [varbinary](max) NULL,
	[Description_ID] [int] NULL,
	[Tray_Name] [nvarchar](50) NULL,
	[Date_Changed] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tray_Items]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tray_Items](
	[Description_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Tray_ID] [bigint] NOT NULL,
	[Disposable_ID] [bigint] NOT NULL,
	[Item_Description] [nvarchar](max) NULL,
	[Item_Mandatory] [bit] NULL,
	[Hide_Item] [bit] NULL,
	[Deleted_Item] [bit] NULL,
	[Cost_ID] [int] NULL,
	[Date_Changed] [datetime] NULL,
 CONSTRAINT [PK_Tray_Items] PRIMARY KEY CLUSTERED 
(
	[Description_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tray_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tray_Log](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Tray_ID] [bigint] NULL,
	[Tray_EPC_Nr] [nvarchar](50) NULL,
	[Packed_Name] [nvarchar](max) NULL,
	[Tray_Packed_Place] [nvarchar](50) NULL,
	[Tray_Packed_Start] [datetime] NULL,
	[Tray_Packed_End] [datetime] NULL,
	[Number_Instruments] [int] NULL,
	[Packed_Locked] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tray_Packed]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tray_Packed](
	[Tray_EPC_Nr] [nvarchar](50) NULL,
	[Tray_Description_ID] [int] NOT NULL,
	[EPC_Nr] [nvarchar](50) NOT NULL,
	[Description_ID] [nvarchar](255) NULL,
	[Packed_Locked] [bit] NULL,
	[Pack_User_ID] [int] NULL,
	[Pack_Station_ID] [int] NULL,
	[Date_Changed] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tray_PackList]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tray_PackList](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Tray_Descrip_ID] [int] NULL,
	[Instrument_Descrip_ID] [nvarchar](255) NULL,
	[Number] [int] NULL,
	[Date_Changed] [datetime] NULL,
 CONSTRAINT [PK_Tray_PackList] PRIMARY KEY CLUSTERED 
(
	[Index_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tray_RFID]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tray_RFID](
	[Tray_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[SEQ_Nr] [nvarchar](50) NULL,
	[Description_ID] [int] NULL,
	[Description_Text] [nvarchar](max) NULL,
	[Special_Text] [nvarchar](max) NULL,
	[Packed_Date] [datetime] NULL,
	[Tray_Contents] [int] NULL,
	[Tray_LastSeen_Place] [nvarchar](50) NULL,
	[Tray_LastSeen_Date] [datetime] NULL,
	[Tray_InUse] [bit] NULL,
	[Date_Changed] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tray_RFID_Life]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tray_RFID_Life](
	[EPC_Nr] [nvarchar](50) NOT NULL,
	[Description_ID] [nvarchar](255) NULL,
	[Date_Birth] [datetime] NOT NULL,
	[Date_End] [datetime] NULL,
	[Last_Service] [datetime] NULL,
	[Return_Service] [datetime] NULL,
	[Number_Service] [int] NULL,
	[Wash_Counter] [int] NULL,
	[Steri_In] [datetime] NULL,
	[Steri_Out] [datetime] NULL,
	[Steri_Name] [nvarchar](255) NULL,
	[OR_In] [datetime] NULL,
	[OR_Out] [datetime] NULL,
	[OR_Name] [nvarchar](255) NULL,
	[Used_In_OR] [int] NULL,
	[Passed_Steri] [int] NULL,
	[Last_Change] [datetime] NULL,
 CONSTRAINT [PK_Tray_RFID_Life] PRIMARY KEY CLUSTERED 
(
	[EPC_Nr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tray_Translation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Tray_Translation](
	[Tray_Trans_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[OutSide_ID] [nvarchar](max) NULL,
	[Tray_ID] [int] NULL,
	[Special_Text] [nvarchar](max) NULL,
	[Changed_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Trays_To_Pack]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Trays_To_Pack](
	[Tray_Pack_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Arrived_Date] [datetime] NULL,
	[Priority] [int] NOT NULL,
	[Cost_Center_ID] [int] NOT NULL,
	[Desired_Date] [datetime] NULL,
	[Special_Text] [nvarchar](max) NULL,
	[Tray_ID] [int] NOT NULL,
	[Is_Taken_For_Pack] [bit] NOT NULL,
	[User_ID] [int] NOT NULL,
	[Pack_Done] [bit] NOT NULL,
	[Identity_Num] [int] NULL,
	[Demand_ID] [bigint] NULL,
	[Changed_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TreatMachine_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TreatMachine_Log](
	[Treatment_ID] [bigint] NOT NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Treatment_Machine_ID] [bigint] NULL,
	[Cycle_Nr] [bigint] NULL,
	[ChangeDate] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Treatment_Description]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Treatment_Description](
	[Treatment_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Treatment_Description] [nvarchar](max) NOT NULL,
	[Treatment_Path] [varchar](max) NULL,
	[Change_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Treatment_Detail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Treatment_Detail](
	[Detail_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Treatment_ID] [bigint] NULL,
	[Treatment_Type] [bigint] NULL,
	[The_Order] [smallint] NULL,
	[Detail_Text] [nvarchar](max) NULL,
	[Detail_Name] [varchar](50) NULL,
	[Change_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Treatment_Log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Treatment_Log](
	[TreatLog_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[EPC_Nr] [nvarchar](50) NULL,
	[Detail_ID] [bigint] NULL,
	[Treatment_ID] [bigint] NULL,
	[Done_ID] [bigint] NULL,
	[Start_Time] [datetime] NULL,
	[ChangeDate] [datetime] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Treatment_Machine]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Treatment_Machine](
	[Machine_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Machine_Name] [nvarchar](50) NOT NULL,
	[Area_ID] [bigint] NULL,
	[Treatment_ID] [bigint] NOT NULL,
	[Treatment_Cycle] [int] NULL,
	[Last_Time_Used] [datetime] NULL,
	[Change_Date] [datetime] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Treatment_Type]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Treatment_Type](
	[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Description_Type] [nchar](10) NOT NULL,
	[Server_Path] [nvarchar](max) NULL,
	[Change_Date] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Action_Description_Action_Done]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Action_Description] ADD  CONSTRAINT [DF_Action_Description_Action_Done]  DEFAULT ((0)) FOR [Action_Done]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Action_Description_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Action_Description] ADD  CONSTRAINT [DF_Action_Description_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Action_Type_Only_Administrator]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Action_Type] ADD  CONSTRAINT [DF_Action_Type_Only_Administrator]  DEFAULT ((0)) FOR [Only_Administrator]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Action_Type_Is_Hidden]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Action_Type] ADD  CONSTRAINT [DF_Action_Type_Is_Hidden]  DEFAULT ((0)) FOR [Is_Hidden]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Action_Type_Can_Expired]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Action_Type] ADD  CONSTRAINT [DF_Action_Type_Can_Expired]  DEFAULT ((0)) FOR [Can_Expired]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Action_Type_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Action_Type] ADD  CONSTRAINT [DF_Action_Type_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Antenna_Reader_Antenna_Function]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Antenna_Reader] ADD  CONSTRAINT [DF_Antenna_Reader_Antenna_Function]  DEFAULT ((0)) FOR [Antenna_Factor]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Antenna_Reader_In_Use]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Antenna_Reader] ADD  CONSTRAINT [DF_Antenna_Reader_In_Use]  DEFAULT (N'Yes') FOR [In_Use]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Antenna_Reader_StartDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Antenna_Reader] ADD  CONSTRAINT [DF_Antenna_Reader_StartDate]  DEFAULT (getdate()) FOR [StartDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Area_Name_List_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Area_Name_List] ADD  CONSTRAINT [DF_Area_Name_List_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cart_Description_Cart_Lock]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cart_Description] ADD  CONSTRAINT [DF_Cart_Description_Cart_Lock]  DEFAULT ((1)) FOR [Cart_Lock]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cart_Description_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cart_Description] ADD  CONSTRAINT [DF_Cart_Description_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cart_RFID_Cart_Contents]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cart_RFID] ADD  CONSTRAINT [DF_Cart_RFID_Cart_Contents]  DEFAULT ((0)) FOR [Cart_Contents]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cart_RFID_Cart_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cart_RFID] ADD  CONSTRAINT [DF_Cart_RFID_Cart_Changed]  DEFAULT (getdate()) FOR [Cart_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cart_RFID_Life_Last_Change]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cart_RFID_Life] ADD  CONSTRAINT [DF_Cart_RFID_Life_Last_Change]  DEFAULT (getdate()) FOR [Last_Change]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_Item_Sync_Insert_Time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_OR_Item_Sync] ADD  CONSTRAINT [DF_CheckBox_Item_Sync_Insert_Time]  DEFAULT (getdate()) FOR [Insert_Time]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_Item_Sync_Read_Tag]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_OR_Item_Sync] ADD  CONSTRAINT [DF_CheckBox_Item_Sync_Read_Tag]  DEFAULT ((0)) FOR [Read_Tag]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_Log_CheckBox_Process]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_OR_Log] ADD  CONSTRAINT [DF_CheckBox_Log_CheckBox_Process]  DEFAULT ('No Value') FOR [CheckBox_Function]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_Log_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_OR_Log] ADD  CONSTRAINT [DF_CheckBox_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_Sync_Synchronization]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_OR_Sync] ADD  CONSTRAINT [DF_CheckBox_Sync_Synchronization]  DEFAULT ((0)) FOR [Synchronization]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_OR_Sync_Check_IN_Light]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_OR_Sync] ADD  CONSTRAINT [DF_CheckBox_OR_Sync_Check_IN_Light]  DEFAULT (NULL) FOR [Check_IN_Light]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_SPD_Item_Sync_Insert_Time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_SPD_Item_Sync] ADD  CONSTRAINT [DF_CheckBox_SPD_Item_Sync_Insert_Time]  DEFAULT (getdate()) FOR [Insert_Time]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_SPD_Item_Sync_Read_Tag]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_SPD_Item_Sync] ADD  CONSTRAINT [DF_CheckBox_SPD_Item_Sync_Read_Tag]  DEFAULT ((0)) FOR [Read_Tag]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_SPD_Log_CheckBox_Process]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_SPD_Log] ADD  CONSTRAINT [DF_CheckBox_SPD_Log_CheckBox_Process]  DEFAULT ('No Value') FOR [CheckBox_Function]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_SPD_Log_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_SPD_Log] ADD  CONSTRAINT [DF_CheckBox_SPD_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_CheckBox_SPD_Sync_Synchronization]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[CheckBox_SPD_Sync] ADD  CONSTRAINT [DF_CheckBox_SPD_Sync_Synchronization]  DEFAULT ((0)) FOR [Synchronization]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ConfigTable_AllowDelete]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConfigTable] ADD  CONSTRAINT [DF_ConfigTable_AllowDelete]  DEFAULT ((0)) FOR [AllowDelete]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ConfigTable_AllowInsert]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConfigTable] ADD  CONSTRAINT [DF_ConfigTable_AllowInsert]  DEFAULT ((0)) FOR [AllowInsert]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ConfigTable_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ConfigTable] ADD  CONSTRAINT [DF_ConfigTable_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Container_Description_Container_Lock]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Container_Description] ADD  CONSTRAINT [DF_Container_Description_Container_Lock]  DEFAULT ((1)) FOR [Container_Lock]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Container_Description_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Container_Description] ADD  CONSTRAINT [DF_Container_Description_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Container_RFID_Container_Contents]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Container_RFID] ADD  CONSTRAINT [DF_Container_RFID_Container_Contents]  DEFAULT ((0)) FOR [Container_Contents]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Container_RFID_Container_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Container_RFID] ADD  CONSTRAINT [DF_Container_RFID_Container_Changed]  DEFAULT (getdate()) FOR [Container_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Container_RFID_Life_Last_Change]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Container_RFID_Life] ADD  CONSTRAINT [DF_Container_RFID_Life_Last_Change]  DEFAULT (getdate()) FOR [Last_Change]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cost_Center_Hidden_Center]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cost_Center] ADD  CONSTRAINT [DF_Cost_Center_Hidden_Center]  DEFAULT ((0)) FOR [Hidden_Center]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cost_Center_Default_Always]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cost_Center] ADD  CONSTRAINT [DF_Cost_Center_Default_Always]  DEFAULT ((0)) FOR [Default_Always]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cost_Center_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cost_Center] ADD  CONSTRAINT [DF_Cost_Center_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cost_Item_Default_Cost]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cost_Item] ADD  CONSTRAINT [DF_Cost_Item_Default_Cost]  DEFAULT ((0)) FOR [Default_Cost]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cost_Item_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cost_Item] ADD  CONSTRAINT [DF_Cost_Item_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cost_Log_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cost_Log] ADD  CONSTRAINT [DF_Cost_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Cost_Type_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Cost_Type] ADD  CONSTRAINT [DF_Cost_Type_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Demand_Service_Log_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Demand_Service_Log] ADD  CONSTRAINT [DF_Demand_Service_Log_Change_Date]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Demand_Text_Text_Hidden]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Demand_Text] ADD  CONSTRAINT [DF_Demand_Text_Text_Hidden]  DEFAULT ((0)) FOR [Text_Hidden]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Demand_Text_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Demand_Text] ADD  CONSTRAINT [DF_Demand_Text_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Disposables_Description_Cost_Factor]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Disposables_Description] ADD  CONSTRAINT [DF_Disposables_Description_Cost_Factor]  DEFAULT ((1)) FOR [Cost_Factor]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Disposables_description_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Disposables_Description] ADD  CONSTRAINT [DF_Disposables_description_Date_Changed]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Disposables_Log_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Disposables_Log] ADD  CONSTRAINT [DF_Disposables_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_EPC_Number_Serie_Start_EPC]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EPC_Number_Serie] ADD  CONSTRAINT [DF_EPC_Number_Serie_Start_EPC]  DEFAULT ((0)) FOR [Start_EPC]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_EPC_Number_Serie_Last_Used_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[EPC_Number_Serie] ADD  CONSTRAINT [DF_EPC_Number_Serie_Last_Used_Date]  DEFAULT (getdate()) FOR [Last_Used_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Exchange_Log_Exchange_Number]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Exchange_Log] ADD  CONSTRAINT [DF_Exchange_Log_Exchange_Number]  DEFAULT ((1)) FOR [Exchange_Number]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Exchange_Table_Borrow_Number]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Exchange_Table] ADD  CONSTRAINT [DF_Exchange_Table_Borrow_Number]  DEFAULT ((0)) FOR [Exchange_Number]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Exchange_Table_Is_Missing]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Exchange_Table] ADD  CONSTRAINT [DF_Exchange_Table_Is_Missing]  DEFAULT ((0)) FOR [Is_Missing]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Exchange_Table_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Exchange_Table] ADD  CONSTRAINT [DF_Exchange_Table_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Gate_Log_Gate_Time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Gate_Log] ADD  CONSTRAINT [DF_Gate_Log_Gate_Time]  DEFAULT (getdate()) FOR [Gate_Time]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Description_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Description] ADD  CONSTRAINT [DF_Instrument_Description_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Description_Vendor_ID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Description] ADD  CONSTRAINT [DF_Instrument_Description_Vendor_ID]  DEFAULT ((0)) FOR [Vendor_ID]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_External_External_ID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_External] ADD  CONSTRAINT [DF_Instrument_External_External_ID]  DEFAULT ((0)) FOR [External_ID]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_External_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_External] ADD  CONSTRAINT [DF_Instrument_External_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Group_Last_date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Group] ADD  CONSTRAINT [DF_Instrument_Group_Last_date]  DEFAULT (getdate()) FOR [Last_Date_Change]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Image_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Image] ADD  CONSTRAINT [DF_Instrument_Image_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Maintenance_RFID_Check_Ciffer]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Maintenance_RFID] ADD  CONSTRAINT [DF_Instrument_Maintenance_RFID_Check_Ciffer]  DEFAULT ((0)) FOR [Check_Ciffer]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Maintance_RFID_Reset_Check_Ciffer]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Maintenance_RFID] ADD  CONSTRAINT [DF_Instrument_Maintance_RFID_Reset_Check_Ciffer]  DEFAULT ((1)) FOR [Reset_Check_Ciffer]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Maintance_RFID_Sendt_To_Service]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Maintenance_RFID] ADD  CONSTRAINT [DF_Instrument_Maintance_RFID_Sendt_To_Service]  DEFAULT ((0)) FOR [Sendt_To_Service]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Maintance_RFID_Reurn_From_Service]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Maintenance_RFID] ADD  CONSTRAINT [DF_Instrument_Maintance_RFID_Reurn_From_Service]  DEFAULT ((0)) FOR [Return_From_Service]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Maintance_RFID_Service_Counter]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Maintenance_RFID] ADD  CONSTRAINT [DF_Instrument_Maintance_RFID_Service_Counter]  DEFAULT ((0)) FOR [Service_Counter]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Packed_Log_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Packed_Log] ADD  CONSTRAINT [DF_Packed_Log_Change_Date]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_ReCall_ReCall_Deleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_ReCall] ADD  CONSTRAINT [DF_Instrument_ReCall_ReCall_Deleted]  DEFAULT ((0)) FOR [ReCall_Deleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_ReCall_Special_Text]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_ReCall] ADD  CONSTRAINT [DF_Instrument_ReCall_Special_Text]  DEFAULT ('None') FOR [Special_Text]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_ReCall_Total_Population]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_ReCall] ADD  CONSTRAINT [DF_Instrument_ReCall_Total_Population]  DEFAULT ((0)) FOR [Total_Population]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_ReCall_Numbers_Recall]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_ReCall] ADD  CONSTRAINT [DF_Instrument_ReCall_Numbers_Recall]  DEFAULT ((0)) FOR [Numbers_Recall]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_ReCall_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_ReCall] ADD  CONSTRAINT [DF_Instrument_ReCall_Change_Date]  DEFAULT (getdate()) FOR [Changed_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_RFID_UDI_Database]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_RFID] ADD  CONSTRAINT [DF_Instrument_RFID_UDI_Database]  DEFAULT ((0)) FOR [UDI_Database]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_RFID_History_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_RFID_History] ADD  CONSTRAINT [DF_Instrument_RFID_History_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_RFID_Life_Demand_Log]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_RFID_Life] ADD  CONSTRAINT [DF_Instrument_RFID_Life_Demand_Log]  DEFAULT ((0)) FOR [Demand_Log]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_RFID_Life_Sent_To_Service]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_RFID_Life] ADD  CONSTRAINT [DF_Instrument_RFID_Life_Sent_To_Service]  DEFAULT ((0)) FOR [Sent_To_Service]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_RFID_Life_Last_Change]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_RFID_Life] ADD  CONSTRAINT [DF_Instrument_RFID_Life_Last_Change]  DEFAULT (getdate()) FOR [Last_Change]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Rules_Maintenance_Text]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Rules] ADD  CONSTRAINT [DF_Instrument_Rules_Maintenance_Text]  DEFAULT ((0)) FOR [Maintenance_Text]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Rules_Deleted]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Rules] ADD  CONSTRAINT [DF_Instrument_Rules_Deleted]  DEFAULT ((0)) FOR [Deleted]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Rules_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Rules] ADD  CONSTRAINT [DF_Instrument_Rules_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Translation_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Translation] ADD  CONSTRAINT [DF_Instrument_Translation_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Translation_Log_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Translation_Log] ADD  CONSTRAINT [DF_Instrument_Translation_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Translation_Vendor_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Translation_Vendor] ADD  CONSTRAINT [DF_Instrument_Translation_Vendor_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Instrument_Vendor_Last_Date_Change]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Instrument_Vendor] ADD  CONSTRAINT [DF_Instrument_Vendor_Last_Date_Change]  DEFAULT (getdate()) FOR [Last_Date_Change]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lend_Entity_Lend_Company_ID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Entity] ADD  CONSTRAINT [DF_Lend_Entity_Lend_Company_ID]  DEFAULT ((0)) FOR [Lend_Company_ID]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lent_Entity_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Entity] ADD  CONSTRAINT [DF_Lent_Entity_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lend_Instrument_Lend_In_Coming]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Instrument] ADD  CONSTRAINT [DF_Lend_Instrument_Lend_In_Coming]  DEFAULT ((0)) FOR [Lend_In_Coming]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lend_Instrument_Lend_OUT_Going]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Instrument] ADD  CONSTRAINT [DF_Lend_Instrument_Lend_OUT_Going]  DEFAULT ((0)) FOR [Lend_OUT_Going]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lent_Instrument_Lent_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Instrument] ADD  CONSTRAINT [DF_Lent_Instrument_Lent_Date]  DEFAULT (getdate()) FOR [Lend_Receive_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lend_Instrument_External_KIT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Instrument] ADD  CONSTRAINT [DF_Lend_Instrument_External_KIT]  DEFAULT ((0)) FOR [External_KIT]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lend_Instrument_Digi_Sign_IN]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Instrument] ADD  CONSTRAINT [DF_Lend_Instrument_Digi_Sign_IN]  DEFAULT ((0)) FOR [Digi_Sign_IN]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lend_Instrument_Digi_Sign_OUT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Instrument] ADD  CONSTRAINT [DF_Lend_Instrument_Digi_Sign_OUT]  DEFAULT ((0)) FOR [Digi_Sign_OUT]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lend_Log_Lend_IN]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Log] ADD  CONSTRAINT [DF_Lend_Log_Lend_IN]  DEFAULT ((0)) FOR [Lend_IN]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lend_Log_IN_OUT_Issue]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Log] ADD  CONSTRAINT [DF_Lend_Log_IN_OUT_Issue]  DEFAULT ((0)) FOR [IN_OUT_Issue]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Lend_Log_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Lend_Log] ADD  CONSTRAINT [DF_Lend_Log_Change_Date]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Log_Change_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Log_Change] ADD  CONSTRAINT [DF_Log_Change_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Login_Security_Program_Name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Login_Security] ADD  CONSTRAINT [DF_Login_Security_Program_Name]  DEFAULT (' ') FOR [Program_Name]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Login_Security_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Login_Security] ADD  CONSTRAINT [DF_Login_Security_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_LogIn_Table_Log_Time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[LogIn_Table] ADD  CONSTRAINT [DF_LogIn_Table_Log_Time]  DEFAULT (getdate()) FOR [Log_Time]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_OR_Trays_Names_Hidden_Name]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[OR_Procedure] ADD  CONSTRAINT [DF_OR_Trays_Names_Hidden_Name]  DEFAULT ((0)) FOR [Hidden]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_OR_Trays_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[OR_Procedure] ADD  CONSTRAINT [DF_OR_Trays_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_OR:Trays_ID_Numbers]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[OR_Trays_ID] ADD  CONSTRAINT [DF_OR:Trays_ID_Numbers]  DEFAULT ((1)) FOR [Numbers]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_OR:Trays_ID_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[OR_Trays_ID] ADD  CONSTRAINT [DF_OR:Trays_ID_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Procedure_Demand_List_Time_Arrived]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Procedure_Demand_List] ADD  CONSTRAINT [DF_Procedure_Demand_List_Time_Arrived]  DEFAULT (getdate()) FOR [Time_Arrived]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Procedure_Demand_List_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Procedure_Demand_List] ADD  CONSTRAINT [DF_Procedure_Demand_List_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Procedure_Demand_List_Sent_To_PackList]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Procedure_Demand_List] ADD  CONSTRAINT [DF_Procedure_Demand_List_Sent_To_PackList]  DEFAULT ((0)) FOR [Sent_To_PackList]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Reader_Description_Reader_Change]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_Reader_Description_Reader_Change]  DEFAULT ((1)) FOR [Reader_Attach]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ReaderDescription_In_Use]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_ReaderDescription_In_Use]  DEFAULT (N'Yes') FOR [In_Use]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Reader_Description_CheckBox_IN]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_Reader_Description_CheckBox_IN]  DEFAULT ((0)) FOR [CheckBox_IN]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Reader_Description_Last_Edited]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_Reader_Description_Last_Edited]  DEFAULT (getdate()) FOR [Last_Edited]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Reader_Description_Start_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_Reader_Description_Start_Date]  DEFAULT (getdate()) FOR [Start_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Reader_Description_AutoUpdate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_Reader_Description_AutoUpdate]  DEFAULT ((0)) FOR [Location]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Reader_ErrorLog_Error_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Reader_ErrorLog] ADD  CONSTRAINT [DF_Reader_ErrorLog_Error_Date]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_ReCall_Log_Changed_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ReCall_Log] ADD  CONSTRAINT [DF_ReCall_Log_Changed_Date]  DEFAULT (getdate()) FOR [Changed_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Rules_Log_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Rules_Log] ADD  CONSTRAINT [DF_Rules_Log_Change_Date]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Service_Connection_Connection_Code]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Service_Connections] ADD  CONSTRAINT [DF_Service_Connection_Connection_Code]  DEFAULT (newid()) FOR [Connection_Code]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Service_Connection_NumberLogins]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Service_Connections] ADD  CONSTRAINT [DF_Service_Connection_NumberLogins]  DEFAULT ((0)) FOR [NumberLogins]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Service_Connection_Connection_InUse]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Service_Connections] ADD  CONSTRAINT [DF_Service_Connection_Connection_InUse]  DEFAULT ((0)) FOR [Connection_InUse]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Service_Connection_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Service_Connections] ADD  CONSTRAINT [DF_Service_Connection_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Service_Log_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Service_Log] ADD  CONSTRAINT [DF_Service_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Service_Vendor_Changed_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Service_Vendor] ADD  CONSTRAINT [DF_Service_Vendor_Changed_Date]  DEFAULT (getdate()) FOR [Changed_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SPD_Machine_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SPD_Machine] ADD  CONSTRAINT [DF_SPD_Machine_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Steril_Central_Changed_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Steril_Central] ADD  CONSTRAINT [DF_Steril_Central_Changed_Date]  DEFAULT (getdate()) FOR [Changed_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Stop_Instrument_Changed_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Stop_Instrument] ADD  CONSTRAINT [DF_Stop_Instrument_Changed_Date]  DEFAULT (getdate()) FOR [Changed_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Storage_Item_Is_Checked_OUT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Storage_Item] ADD  CONSTRAINT [DF_Storage_Item_Is_Checked_OUT]  DEFAULT ((0)) FOR [Is_Checked_OUT]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Storage_Item_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Storage_Item] ADD  CONSTRAINT [DF_Storage_Item_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Storage_Log_Returned]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Storage_Log] ADD  CONSTRAINT [DF_Storage_Log_Returned]  DEFAULT ((0)) FOR [Returned]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Storage_Log_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Storage_Log] ADD  CONSTRAINT [DF_Storage_Log_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Storage_Station_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Storage_Station] ADD  CONSTRAINT [DF_Storage_Station_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SW_Update_SW_Path]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SW_Update] ADD  CONSTRAINT [DF_SW_Update_SW_Path]  DEFAULT ('\\Server_SW') FOR [SW_Path]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SW_Update_Mandatory]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SW_Update] ADD  CONSTRAINT [DF_SW_Update_Mandatory]  DEFAULT ((0)) FOR [Mandatory]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SW_Update_Blocked_Use]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SW_Update] ADD  CONSTRAINT [DF_SW_Update_Blocked_Use]  DEFAULT ((0)) FOR [Blocked_Use]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SW_Update_Update_Code]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SW_Update] ADD  CONSTRAINT [DF_SW_Update_Update_Code]  DEFAULT ((100)) FOR [Update_Code]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SW_Update_Last_Edited]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SW_Update] ADD  CONSTRAINT [DF_SW_Update_Last_Edited]  DEFAULT (getdate()) FOR [Changed_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SystemInfo_Mandatory]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_Mandatory]  DEFAULT ((-1)) FOR [Mandatory]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SystemInfo_GateNameSwitch]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_GateNameSwitch]  DEFAULT ((0)) FOR [GateNameSwitch]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SystemInfo_Use_Login]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_Use_Login]  DEFAULT ((1)) FOR [Use_Login]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SystemInfo_Use_ActiveDirectory]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_Use_ActiveDirectory]  DEFAULT ((0)) FOR [Use_ActiveDirectory]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SystemInfo_Login_Verification]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_Login_Verification]  DEFAULT ((0)) FOR [Login_Verification]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_SystemInfo_Use_Action]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_Use_Action]  DEFAULT ((0)) FOR [Use_Action]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_TblPassword_Log_ID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblPassword] ADD  CONSTRAINT [DF_TblPassword_Log_ID]  DEFAULT (NULL) FOR [Log_ID]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_TblPassword_NumberLogins]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblPassword] ADD  CONSTRAINT [DF_TblPassword_NumberLogins]  DEFAULT ((0)) FOR [NumberLogins]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_tblPassword_DashBoardAdmin]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblPassword] ADD  CONSTRAINT [DF_tblPassword_DashBoardAdmin]  DEFAULT ((0)) FOR [DashBoardAdmin]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_TblPassword_Using_Action]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblPassword] ADD  CONSTRAINT [DF_TblPassword_Using_Action]  DEFAULT ((0)) FOR [Using_Action]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_tblPassword_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TblPassword] ADD  CONSTRAINT [DF_tblPassword_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Technical_Log_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Technical_Log] ADD  CONSTRAINT [DF_Technical_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Description_Tray_Lock]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Tray_Lock]  DEFAULT ((1)) FOR [Tray_Lock]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Description_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Description_Hide_Tray]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Hide_Tray]  DEFAULT ('0') FOR [Hide_Tray]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Description_Deleted_Tray]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Deleted_Tray]  DEFAULT ((0)) FOR [Deleted_Tray]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Description_Special_Text]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Special_Text]  DEFAULT ((0)) FOR [Special_Text]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Description_Cost_ID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Cost_ID]  DEFAULT ((0)) FOR [Cost_ID]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Image_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Image] ADD  CONSTRAINT [DF_Tray_Image_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Items_Tray_Lock]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Items] ADD  CONSTRAINT [DF_Tray_Items_Tray_Lock]  DEFAULT ((0)) FOR [Item_Mandatory]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Items_Hide_Tray]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Items] ADD  CONSTRAINT [DF_Tray_Items_Hide_Tray]  DEFAULT ('0') FOR [Hide_Item]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Items_Deleted_Tray]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Items] ADD  CONSTRAINT [DF_Tray_Items_Deleted_Tray]  DEFAULT ((0)) FOR [Deleted_Item]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Items_Cost_ID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Items] ADD  CONSTRAINT [DF_Tray_Items_Cost_ID]  DEFAULT ((0)) FOR [Cost_ID]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Items_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Items] ADD  CONSTRAINT [DF_Tray_Items_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_PackList_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_PackList] ADD  CONSTRAINT [DF_Tray_PackList_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_RFID_Tray_Contents]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_RFID] ADD  CONSTRAINT [DF_Tray_RFID_Tray_Contents]  DEFAULT ((0)) FOR [Tray_Contents]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_RFID_Date_Changed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_RFID] ADD  CONSTRAINT [DF_Tray_RFID_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_RFID_Life_Last_Change]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_RFID_Life] ADD  CONSTRAINT [DF_Tray_RFID_Life_Last_Change]  DEFAULT (getdate()) FOR [Last_Change]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Tray_Translation_Changed_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Tray_Translation] ADD  CONSTRAINT [DF_Tray_Translation_Changed_Date]  DEFAULT (getdate()) FOR [Changed_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Trays_To_Pack_Arrived_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Arrived_Date]  DEFAULT (getdate()) FOR [Arrived_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Trays_To_Pack_Department_ID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Department_ID]  DEFAULT ((0)) FOR [Cost_Center_ID]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Trays_To_Pack_Tray_ID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Tray_ID]  DEFAULT ((0)) FOR [Tray_ID]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Trays_To_Pack_Is_Taken_For_Pack]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Is_Taken_For_Pack]  DEFAULT ((0)) FOR [Is_Taken_For_Pack]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Trays_To_Pack_User_ID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_User_ID]  DEFAULT ((0)) FOR [User_ID]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Trays_To_Pack_Pack_Done]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Pack_Done]  DEFAULT ((0)) FOR [Pack_Done]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Trays_To_Pack_Changed_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Changed_Date]  DEFAULT (getdate()) FOR [Changed_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_TreatMachine_Log_ChangeDate]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[TreatMachine_Log] ADD  CONSTRAINT [DF_TreatMachine_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Treatment_Description_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Treatment_Description] ADD  CONSTRAINT [DF_Treatment_Description_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Treatment_Detail_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Treatment_Detail] ADD  CONSTRAINT [DF_Treatment_Detail_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Treatment_Log_Start_Time]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Treatment_Log] ADD  CONSTRAINT [DF_Treatment_Log_Start_Time]  DEFAULT (getdate()) FOR [Start_Time]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Treatment_Log_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Treatment_Log] ADD  CONSTRAINT [DF_Treatment_Log_Change_Date]  DEFAULT (getdate()) FOR [ChangeDate]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Machine_Description_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Treatment_Machine] ADD  CONSTRAINT [DF_Machine_Description_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_Treatment_Type_Change_Date]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[Treatment_Type] ADD  CONSTRAINT [DF_Treatment_Type_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[Update_date]'))
EXEC dbo.sp_executesql @statement = N'-- =============================================
-- Author:		Soren Bilsoe
-- Create date: 24-08-2013
-- Description:	Update the Change Date
-- =============================================
CREATE TRIGGER [dbo].[Update_date] 
   ON  [dbo].[Instrument_RFID_Life] 
   AFTER INSERT,DELETE,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
UPDATE dbo.Instrument_RFID_Life SET dbo.Instrument_RFID_Life.Last_Change=GETDATE()
WHERE EPC_Nr IN (SELECT DISTINCT EPC_Nr FROM INSERTED)
END
' 
GO
ALTER TABLE [dbo].[Instrument_RFID_Life] ENABLE TRIGGER [Update_date]
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Action_Type', N'COLUMN',N'Can_Expired'))
	EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'zero can''t 1 = one month' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Action_Type', @level2type=N'COLUMN',@level2name=N'Can_Expired'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Antenna_Reader', N'COLUMN',N'Antenna_Factor'))
	EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Used to tell if it is a :
0=Initialized NOT IN USE
1= passing antenna - like a door
2= Box where items can be BOTH  taken from and stored
3=Box where Items ONLY can taken from
4=Box where Items ONLY can be stored' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Antenna_Reader', @level2type=N'COLUMN',@level2name=N'Antenna_Factor'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Instrument_Code', NULL,NULL))
	EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'This is the Code Used ti Indentify the Instrument to Rules' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Instrument_Code'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Reader_Description', N'COLUMN',N'Location'))
	EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Location on MAP :   X,Y' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reader_Description', @level2type=N'COLUMN',@level2name=N'Location'
GO
IF NOT EXISTS (SELECT * FROM sys.fn_listextendedproperty(N'MS_Description' , N'SCHEMA',N'dbo', N'TABLE',N'Service_Connections', N'COLUMN',N'Service_Connection'))
	EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Connection string OR and ID to an Table' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Service_Connections', @level2type=N'COLUMN',@level2name=N'Service_Connection'
GO
