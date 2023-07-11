namespace Caretag_Class.Migrations
{
	using Caretag_Class.Migrations.Base;

	public partial class First : DbMigrationBase
    {
        private void CreateTables()
        {
	        Sql(@"
				CREATE TABLE [dbo].[ConfigTable](
					[ConfigID] [int] IDENTITY(1,1) NOT NULL,
					[TableName] [nvarchar](50) NOT NULL,
					[ValueColumStart] [int] NOT NULL,
					[AllowDelete] [bit] NOT NULL,
					[ChangeDate] [smalldatetime] NULL,
					[AllowInsert] [bit] NOT NULL,
				 CONSTRAINT [PK_ConfigTable] PRIMARY KEY CLUSTERED 
				(
					[ConfigID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[ConfigTable] ADD  CONSTRAINT [DF_ConfigTable_AllowDelete]  DEFAULT ((0)) FOR [AllowDelete]
				GO

				ALTER TABLE [dbo].[ConfigTable] ADD  CONSTRAINT [DF_ConfigTable_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				ALTER TABLE [dbo].[ConfigTable] ADD  CONSTRAINT [DF_ConfigTable_AllowInsert]  DEFAULT ((0)) FOR [AllowInsert]
				GO

				/***

					Container tables

				***/

				/****** Object:  Table [dbo].[Container_Description]    Script Date: 27-04-2022 10:32:57 ******/
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
				GO

				ALTER TABLE [dbo].[Container_Description] ADD  CONSTRAINT [DF_Container_Description_Container_Lock]  DEFAULT ((1)) FOR [Container_Lock]
				GO

				ALTER TABLE [dbo].[Container_Description] ADD  CONSTRAINT [DF_Container_Description_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				/****** Object:  Table [dbo].[Container_RFID]    Script Date: 27-04-2022 10:34:49 ******/
				CREATE TABLE [dbo].[Container_RFID](
					[Container_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[SEQ_Nr] [nvarchar](50) NULL,
					[Description_ID] [int] NULL,
					[Special_Text] [nvarchar](max) NULL,
					[Container_Contents] [int] NULL,
					[Container_LastSeen_Place] [nvarchar](50) NULL,
					[Container_LastSeen_Date] [datetime] NULL,
					[Container_InUse] [bit] NULL,
					[Container_Changed] [datetime] NULL,
					[Cart_ID] [bigint] NULL,
					[Tray_ID] [bigint] NULL,
				 CONSTRAINT [PK_Container_RFID] PRIMARY KEY CLUSTERED 
				(
					[Container_ID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Container_RFID] ADD  CONSTRAINT [DF_Container_RFID_Container_Contents]  DEFAULT ((0)) FOR [Container_Contents]
				GO

				ALTER TABLE [dbo].[Container_RFID] ADD  CONSTRAINT [DF_Container_RFID_Container_Changed]  DEFAULT (getdate()) FOR [Container_Changed]
				GO

				/****** Object:  Table [dbo].[Container_RFID_Life]    Script Date: 27-04-2022 10:34:56 ******/
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
				GO

				ALTER TABLE [dbo].[Container_RFID_Life] ADD  CONSTRAINT [DF_Container_RFID_Life_Last_Change]  DEFAULT (getdate()) FOR [Last_Change]
				GO

				/***

					Cost Center tables

				**/

				/****** Object:  Table [dbo].[Cost_Center]    Script Date: 27-04-2022 10:35:10 ******/
				CREATE TABLE [dbo].[Cost_Center](
					[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Cost_Center_Name] [nvarchar](max) NOT NULL,
					[Cost_Center_Code] [nvarchar](max) NULL,
					[Hidden_Center] [bit] NULL,
					[Change_Date] [datetime] NULL,
					[Extra_Text] [nvarchar](max) NULL,
					[Default_Always] [bit] NULL,
				 CONSTRAINT [PK_Cost_Center] PRIMARY KEY CLUSTERED 
				(
					[Index_ID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Cost_Center] ADD  CONSTRAINT [DF_Cost_Center_Hidden_Center]  DEFAULT ((0)) FOR [Hidden_Center]
				GO

				ALTER TABLE [dbo].[Cost_Center] ADD  CONSTRAINT [DF_Cost_Center_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
				GO

				ALTER TABLE [dbo].[Cost_Center] ADD  CONSTRAINT [DF_Cost_Center_Default_Always]  DEFAULT ((0)) FOR [Default_Always]
				GO

				/****** Object:  Table [dbo].[Cost_Item]    Script Date: 27-04-2022 10:36:12 ******/

				CREATE TABLE [dbo].[Cost_Item](
					[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Cost_Center] [bigint] NOT NULL,
					[Change_Date] [datetime] NULL,
					[Cost_Type_ID] [bigint] NULL,
					[Default_Cost] [bit] NULL
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Cost_Item] ADD  CONSTRAINT [DF_Cost_Item_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
				GO

				ALTER TABLE [dbo].[Cost_Item] ADD  CONSTRAINT [DF_Cost_Item_Default_Cost]  DEFAULT ((0)) FOR [Default_Cost]
				GO

				/****** Object:  Table [dbo].[Cost_Log]    Script Date: 27-04-2022 10:36:21 ******/

				CREATE TABLE [dbo].[Cost_Log](
					[Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Cost_Center] [bigint] NOT NULL,
					[Cost_Item] [bigint] NOT NULL,
					[The_Item_ID] [bigint] NULL,
					[Extra_Text] [nvarchar](max) NULL,
					[Used_Date] [datetime] NULL,
					[Reader_ID] [int] NULL,
					[ChangeDate] [datetime] NULL,
					[The_Tray_Log_ID] [bigint] NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Cost_Log] ADD  CONSTRAINT [DF_Cost_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
				GO


				/****** Object:  Table [dbo].[Cost_Type]    Script Date: 27-04-2022 10:36:29 ******/

				CREATE TABLE [dbo].[Cost_Type](
					[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Cost_Type] [nvarchar](max) NULL,
					[Cost_Price] [decimal](18, 2) NULL,
					[Change_Date] [datetime] NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Cost_Type] ADD  CONSTRAINT [DF_Cost_Type_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
				GO

				/*** 

					Various tables

				*/

				/****** Object:  Table [dbo].[Demand_Service_Log]    Script Date: 27-04-2022 10:37:01 ******/

				CREATE TABLE [dbo].[Demand_Service_Log](
					[Demand_Service_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[Description_ID] [nvarchar](255) NULL,
					[Rules_ID_String] [nvarchar](max) NULL,
					[Insert_Place] [nvarchar](50) NULL,
					[ChangeDate] [datetime] NULL,
					[Demand_Text_ID] [bigint] NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Demand_Service_Log] ADD  CONSTRAINT [DF_Demand_Service_Log_Change_Date]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				/****** Object:  Table [dbo].[EPC_Number_Serie]    Script Date: 27-04-2022 10:37:51 ******/

				CREATE TABLE [dbo].[EPC_Number_Serie](
					[Owner_Ship] [nvarchar](max) NOT NULL,
					[Owner_Serie] [nvarchar](50) NOT NULL,
					[Customer_Number] [nchar](10) NOT NULL,
					[Special_Number] [nchar](10) NULL,
					[Max_Number] [int] NULL,
					[Start_EPC] [nvarchar](max) NOT NULL,
					[New_EPC] [nvarchar](max) NULL,
					[Confirm_To_GS1] [bit] NULL,
					[Last_Used_EPC] [nvarchar](max) NULL,
					[Last_Used_Date] [datetime] NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[EPC_Number_Serie] ADD  CONSTRAINT [DF_EPC_Number_Serie_Start_EPC]  DEFAULT ((0)) FOR [Start_EPC]
				GO

				ALTER TABLE [dbo].[EPC_Number_Serie] ADD  CONSTRAINT [DF_EPC_Number_Serie_Last_Used_Date]  DEFAULT (getdate()) FOR [Last_Used_Date]
				GO

				/**

					Instrument tables

				**/


				/****** Object:  Table [dbo].[Instrument_Description]    Script Date: 27-04-2022 10:45:00 ******/

				CREATE TABLE [dbo].[Instrument_Description](
					[Description_ID] [nvarchar](255) NOT NULL,
					[Instrument_Company] [nvarchar](255) NULL,
					[Description_Name] [nvarchar](255) NULL,
					[D] [nvarchar](255) NULL,
					[E] [nvarchar](255) NULL,
					[Date_Changed] [datetime] NULL,
					[Treatment_ID] [bigint] NULL,
					[Vendor_ID] [int] NOT NULL,
				PRIMARY KEY CLUSTERED 
				(
					[Description_ID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Instrument_Description] ADD  CONSTRAINT [DF_Instrument_Description_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				ALTER TABLE [dbo].[Instrument_Description] ADD  CONSTRAINT [DF_Instrument_Description_Vendor_ID]  DEFAULT ((0)) FOR [Vendor_ID]
				GO

				/****** Object:  Table [dbo].[Instrument_Group]    Script Date: 27-04-2022 10:46:29 ******/

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
				GO

				ALTER TABLE [dbo].[Instrument_Group] ADD  CONSTRAINT [DF_Instrument_Group_Last_date]  DEFAULT (getdate()) FOR [Last_Date_Change]
				GO

				/****** Object:  Table [dbo].[Instrument_Image]    Script Date: 27-04-2022 10:46:51 ******/


				CREATE TABLE [dbo].[Instrument_Image](
					[Image_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[TheImage] [varbinary](max) NULL,
					[Description_ID] [nvarchar](255) NULL,
					[Date_Changed] [datetime] NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Instrument_Image] ADD  CONSTRAINT [DF_Instrument_Image_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				/****** Object:  Table [dbo].[Instrument_Maintenance_RFID]    Script Date: 27-04-2022 10:47:02 ******/

				CREATE TABLE [dbo].[Instrument_Maintenance_RFID](
					[Maintenance_RFID_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[EPC_Nr] [nvarchar](50) NOT NULL,
					[Rules_ID] [bigint] NULL,
					[Check_Ciffer] [int] NULL,
					[Reset_Check_Ciffer] [bit] NULL,
					[Check_Status] [bit] NULL,
					[Sendt_To_Service] [bit] NULL,
					[Return_From_Service] [bit] NULL,
					[Service_Counter] [int] NULL,
					[Service_Date] [datetime] NULL,
					[Maintenance_Period_Start] [datetime] NULL,
					[ServiceVendor_ID] [int] NULL,
					[Description_ID] [nvarchar](255) NULL,
					[ChangeDate] [datetime] NULL
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Instrument_Maintenance_RFID] ADD  CONSTRAINT [DF_Instrument_Maintenance_RFID_Check_Ciffer]  DEFAULT ((0)) FOR [Check_Ciffer]
				GO

				ALTER TABLE [dbo].[Instrument_Maintenance_RFID] ADD  CONSTRAINT [DF_Instrument_Maintance_RFID_Reset_Check_Ciffer]  DEFAULT ((1)) FOR [Reset_Check_Ciffer]
				GO

				ALTER TABLE [dbo].[Instrument_Maintenance_RFID] ADD  CONSTRAINT [DF_Instrument_Maintance_RFID_Sendt_To_Service]  DEFAULT ((0)) FOR [Sendt_To_Service]
				GO

				ALTER TABLE [dbo].[Instrument_Maintenance_RFID] ADD  CONSTRAINT [DF_Instrument_Maintance_RFID_Reurn_From_Service]  DEFAULT ((0)) FOR [Return_From_Service]
				GO

				ALTER TABLE [dbo].[Instrument_Maintenance_RFID] ADD  CONSTRAINT [DF_Instrument_Maintance_RFID_Service_Counter]  DEFAULT ((0)) FOR [Service_Counter]
				GO


				/****** Object:  Table [dbo].[Instrument_Packed_Log]    Script Date: 27-04-2022 10:47:56 ******/
				CREATE TABLE [dbo].[Instrument_Packed_Log](
					[The_Log_ID] [bigint] NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[ChangeDate] [datetime] NULL
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Instrument_Packed_Log] ADD  CONSTRAINT [DF_Packed_Log_Change_Date]  DEFAULT (getdate()) FOR [ChangeDate]
				GO


				/****** Object:  Table [dbo].[Instrument_RFID]    Script Date: 27-04-2022 10:49:57 ******/
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
				GO

				ALTER TABLE [dbo].[Instrument_RFID] ADD  CONSTRAINT [DF_Instrument_RFID_UDI_Database]  DEFAULT ((0)) FOR [UDI_Database]
				GO

				/****** Object:  Table [dbo].[Instrument_RFID_History]    Script Date: 27-04-2022 10:50:18 ******/
				CREATE TABLE [dbo].[Instrument_RFID_History](
					[EPC_Nr] [nvarchar](50) NULL,
					[Instrument_InUse] [int] NULL,
					[Last_Seen] [nvarchar](50) NULL,
					[Now_Seen] [nvarchar](50) NULL,
					[Last_Seen_Date] [datetime] NULL,
					[Change_Date] [datetime] NOT NULL
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Instrument_RFID_History] ADD  CONSTRAINT [DF_Instrument_RFID_History_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
				GO

				/****** Object:  Table [dbo].[Instrument_RFID_Life]    Script Date: 27-04-2022 10:50:30 ******/
				CREATE TABLE [dbo].[Instrument_RFID_Life](
					[EPC_Nr] [nvarchar](50) NOT NULL,
					[Description_ID] [nvarchar](255) NULL,
					[Date_Birth] [datetime] NOT NULL,
					[Date_End] [datetime] NULL,
					[Demand_Service] [datetime] NULL,
					[Demand_Service_Number] [int] NULL,
					[Demand_Log] [int] NULL,
					[Sent_To_Service] [bit] NULL,
					[Sent_Service] [datetime] NULL,
					[Return_Service] [datetime] NULL,
					[Number_Service] [int] NULL,
					[DaysInService] [int] NULL,
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
					[ServiceVendor_ID] [int] NULL,
				 CONSTRAINT [PK_Instrument_RFID_Life] PRIMARY KEY CLUSTERED 
				(
					[EPC_Nr] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Instrument_RFID_Life] ADD  CONSTRAINT [DF_Instrument_RFID_Life_Demand_Log]  DEFAULT ((0)) FOR [Demand_Log]
				GO

				ALTER TABLE [dbo].[Instrument_RFID_Life] ADD  CONSTRAINT [DF_Instrument_RFID_Life_Sent_To_Service]  DEFAULT ((0)) FOR [Sent_To_Service]
				GO

				ALTER TABLE [dbo].[Instrument_RFID_Life] ADD  CONSTRAINT [DF_Instrument_RFID_Life_Last_Change]  DEFAULT (getdate()) FOR [Last_Change]
				GO


				/****** Object:  Table [dbo].[Instrument_Rules]    Script Date: 27-04-2022 10:50:47 ******/
				CREATE TABLE [dbo].[Instrument_Rules](
					[Rules_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Description_ID] [nvarchar](255) NULL,
					[Default_Rule] [bit] NULL,
					[Maintenance_Text] [nvarchar](max) NULL,
					[Maintenance_Value] [smallint] NULL,
					[Maintenance_Periods] [smallint] NULL,
					[Maintenance_Period_Start] [datetime] NULL,
					[Maintenance_Alarm] [bit] NULL,
					[ChangeDate] [datetime] NULL,
					[Deleted] [bit] NULL,
				 CONSTRAINT [PK_Instrument_Rules] PRIMARY KEY CLUSTERED 
				(
					[Rules_ID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Instrument_Rules] ADD  CONSTRAINT [DF_Instrument_Rules_Maintenance_Text]  DEFAULT ((0)) FOR [Maintenance_Text]
				GO

				ALTER TABLE [dbo].[Instrument_Rules] ADD  CONSTRAINT [DF_Instrument_Rules_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				ALTER TABLE [dbo].[Instrument_Rules] ADD  CONSTRAINT [DF_Instrument_Rules_Deleted]  DEFAULT ((0)) FOR [Deleted]
				GO

				/****** Object:  Table [dbo].[Instrument_Translation]    Script Date: 27-04-2022 11:00:44 ******/
				CREATE TABLE [dbo].[Instrument_Translation](
					[Caretag_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Description_Name] [nvarchar](max) NULL,
					[ChangeDate] [datetime] NULL,
					[Vendor_ID_1] [nvarchar](50) NULL,
					[Vendor_ID_2] [nvarchar](50) NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Instrument_Translation] ADD  CONSTRAINT [DF_Instrument_Translation_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				/****** Object:  Table [dbo].[Instrument_Translation_Vendor]    Script Date: 27-04-2022 11:00:55 ******/
				CREATE TABLE [dbo].[Instrument_Translation_Vendor](
					[The_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[The_Last_Vendor_Index] [nchar](10) NULL,
					[ChangeDate] [datetime] NULL,
					[Vendor_Name_1] [nvarchar](50) NULL,
					[Vendor_Name_2] [nvarchar](50) NULL
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Instrument_Translation_Vendor] ADD  CONSTRAINT [DF_Instrument_Translation_Vendor_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
				GO


				/****** Object:  Table [dbo].[Lend_Log]    Script Date: 27-04-2022 11:02:04 ******/
				CREATE TABLE [dbo].[Lend_Log](
					[UserID] [int] NULL,
					[Lend_ID] [bigint] NULL,
					[Lend_IN] [bit] NULL,
					[IN_OUT_Issue] [bit] NULL,
					[OR_Relation] [nvarchar](max) NULL,
					[ChangeDate] [datetime] NOT NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Lend_Log] ADD  CONSTRAINT [DF_Lend_Log_Lend_IN]  DEFAULT ((0)) FOR [Lend_IN]
				GO

				ALTER TABLE [dbo].[Lend_Log] ADD  CONSTRAINT [DF_Lend_Log_IN_OUT_Issue]  DEFAULT ((0)) FOR [IN_OUT_Issue]
				GO

				ALTER TABLE [dbo].[Lend_Log] ADD  CONSTRAINT [DF_Lend_Log_Change_Date]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				/****** Object:  Table [dbo].[Log_Change]    Script Date: 27-04-2022 11:02:27 ******/
				CREATE TABLE [dbo].[Log_Change](
					[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Text] [nvarchar](max) NULL,
					[Change_Date] [date] NULL,
					[User_Name] [nvarchar](50) NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Log_Change] ADD  CONSTRAINT [DF_Log_Change_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
				GO

				/****** Object:  Table [dbo].[Login_Security]    Script Date: 27-04-2022 11:02:44 ******/
				CREATE TABLE [dbo].[Login_Security](
					[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Program_Name] [nvarchar](50) NOT NULL,
					[The_Security] [int] NULL,
					[Default_Security] [int] NULL,
					[Special_Text] [nvarchar](max) NULL,
					[Date_Changed] [datetime] NOT NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Login_Security] ADD  CONSTRAINT [DF_Login_Security_Program_Name]  DEFAULT (' ') FOR [Program_Name]
				GO

				ALTER TABLE [dbo].[Login_Security] ADD  CONSTRAINT [DF_Login_Security_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				/****** Object:  Table [dbo].[LogIn_Table]    Script Date: 27-04-2022 11:02:57 ******/
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
				GO

				ALTER TABLE [dbo].[LogIn_Table] ADD  CONSTRAINT [DF_LogIn_Table_Log_Time]  DEFAULT (getdate()) FOR [Log_Time]
				GO

				/****** Object:  Table [dbo].[Not_Known_RFID]    Script Date: 27-04-2022 11:03:22 ******/
				CREATE TABLE [dbo].[Not_Known_RFID](
					[Not_Known_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[Not_Known_LastSeen_Place] [nvarchar](50) NULL,
					[Not_Known_LastSeen_Date] [datetime] NULL,
					[Not_Known_InUse] [bit] NULL
				) ON [PRIMARY]
				GO

				/****** Object:  Table [dbo].[OperationInstruments]    Script Date: 27-04-2022 11:03:34 ******/

				CREATE TABLE [dbo].[OperationInstruments](
					[Id] [int] IDENTITY(1,1) NOT NULL,
					[InstrumentId] [bigint] NOT NULL,
					[InstrumentEPC] [nvarchar](50) NOT NULL,
					[OperationId] [int] NOT NULL,
					[ActiveLink] [bit] NOT NULL,
					[Timestamp] [datetimeoffset](7) NULL
				) ON [PRIMARY]
				GO

				/****** Object:  Table [dbo].[Operations]    Script Date: 27-04-2022 11:03:43 ******/
				CREATE TABLE [dbo].[Operations](
					[Id] [int] IDENTITY(1,1) NOT NULL,
					[OperationId] [nvarchar](200) NULL,
					[OperatingRoom] [nvarchar](max) NULL,
					[State] [nvarchar](50) NULL,
					[Timestamp] [datetimeoffset](7) NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				/****** Object:  Table [dbo].[OR_Procedure]    Script Date: 27-04-2022 11:04:11 ******/
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
				GO

				ALTER TABLE [dbo].[OR_Procedure] ADD  CONSTRAINT [DF_OR_Trays_Names_Hidden_Name]  DEFAULT ((0)) FOR [Hidden]
				GO

				ALTER TABLE [dbo].[OR_Procedure] ADD  CONSTRAINT [DF_OR_Trays_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				/****** Object:  Table [dbo].[OR_Trays_ID]    Script Date: 27-04-2022 11:04:27 ******/
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
				GO

				ALTER TABLE [dbo].[OR_Trays_ID] ADD  CONSTRAINT [DF_OR:Trays_ID_Numbers]  DEFAULT ((1)) FOR [Numbers]
				GO

				ALTER TABLE [dbo].[OR_Trays_ID] ADD  CONSTRAINT [DF_OR:Trays_ID_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				/****** Object:  Table [dbo].[Procedure_Demand_List]    Script Date: 27-04-2022 11:04:43 ******/
				CREATE TABLE [dbo].[Procedure_Demand_List](
					[Demand_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Time_Arrived] [datetime] NOT NULL,
					[Priority] [int] NOT NULL,
					[Packed_Day] [datetime] NULL,
					[Procedure_ID] [nvarchar](max) NULL,
					[Note] [nvarchar](max) NULL,
					[Date_Changed] [datetime] NOT NULL,
					[Is_Used] [datetime] NULL,
					[User_Name] [nvarchar](max) NULL,
					[Desired_Date] [datetime] NULL,
					[Cost_Center_ID] [int] NULL,
					[Sent_To_PackList] [bit] NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Procedure_Demand_List] ADD  CONSTRAINT [DF_Procedure_Demand_List_Time_Arrived]  DEFAULT (getdate()) FOR [Time_Arrived]
				GO

				ALTER TABLE [dbo].[Procedure_Demand_List] ADD  CONSTRAINT [DF_Procedure_Demand_List_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				ALTER TABLE [dbo].[Procedure_Demand_List] ADD  CONSTRAINT [DF_Procedure_Demand_List_Sent_To_PackList]  DEFAULT ((0)) FOR [Sent_To_PackList]
				GO

				/****** Object:  Table [dbo].[Reader_Description]    Script Date: 27-04-2022 11:04:56 ******/
				CREATE TABLE [dbo].[Reader_Description](
					[Reader_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Reader_Name] [nvarchar](50) NOT NULL,
					[Area_ID] [bigint] NULL,
					[Reader_Description] [nvarchar](max) NULL,
					[Reader_Attach] [bit] NULL,
					[In_Use] [nchar](10) NULL,
					[CheckBox_IN] [bit] NULL,
					[IP_Address] [nvarchar](50) NULL,
					[Last_Edited] [datetime] NOT NULL,
					[Start_Date] [datetime] NOT NULL,
					[External_IP_Address] [nvarchar](50) NULL,
					[SoftwareVersion] [nvarchar](50) NULL,
					[ReaderGUID] [uniqueidentifier] NULL,
					[Location] [nvarchar](50) NULL,
					[Last_Stand] [nvarchar](max) NULL,
				 CONSTRAINT [PK_Reader_Description] PRIMARY KEY CLUSTERED 
				(
					[Reader_ID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_Reader_Description_Reader_Change]  DEFAULT ((1)) FOR [Reader_Attach]
				GO

				ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_ReaderDescription_In_Use]  DEFAULT (N'Yes') FOR [In_Use]
				GO

				ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_Reader_Description_CheckBox_IN]  DEFAULT ((0)) FOR [CheckBox_IN]
				GO

				ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_Reader_Description_Last_Edited]  DEFAULT (getdate()) FOR [Last_Edited]
				GO

				ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_Reader_Description_Start_Date]  DEFAULT (getdate()) FOR [Start_Date]
				GO

				ALTER TABLE [dbo].[Reader_Description] ADD  CONSTRAINT [DF_Reader_Description_AutoUpdate]  DEFAULT ((0)) FOR [Location]
				GO

				EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Location on MAP :   X,Y' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Reader_Description', @level2type=N'COLUMN',@level2name=N'Location'
				GO

				/****** Object:  Table [dbo].[Reader_ErrorLog]    Script Date: 27-04-2022 11:05:08 ******/
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
				GO

				ALTER TABLE [dbo].[Reader_ErrorLog] ADD  CONSTRAINT [DF_Reader_ErrorLog_Error_Date]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				/****** Object:  Table [dbo].[Rules_Log]    Script Date: 27-04-2022 11:09:32 ******/
				CREATE TABLE [dbo].[Rules_Log](
					[Rules_Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[UserID] [int] NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[Rules_ID] [bigint] NULL,
					[Types_Service] [nvarchar](50) NULL,
					[ServiceVendor_ID] [int] NULL,
					[ChangeDate] [datetime] NOT NULL
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Rules_Log] ADD  CONSTRAINT [DF_Rules_Log_Change_Date]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				/****** Object:  Table [dbo].[ScanEvent]    Script Date: 27-04-2022 11:09:42 ******/
				CREATE TABLE [dbo].[ScanEvent](
					[ID] [int] IDENTITY(1,1) NOT NULL,
					[EPC] [varchar](200) NOT NULL,
					[Time_stamp] [datetime] NOT NULL,
					[Scan_location] [varchar](200) NOT NULL,
				PRIMARY KEY CLUSTERED 
				(
					[ID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY]
				GO

				/****** Object:  Table [dbo].[Service_Log]    Script Date: 27-04-2022 11:10:17 ******/
				CREATE TABLE [dbo].[Service_Log](
					[Service_Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[UserID] [int] NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[Rules_ID] [bigint] NULL,
					[ServiceVendor_ID] [int] NULL,
					[ChangeDate] [datetime] NULL
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Service_Log] ADD  CONSTRAINT [DF_Service_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				/****** Object:  Table [dbo].[Service_Vendor]    Script Date: 27-04-2022 11:10:30 ******/
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
				GO

				ALTER TABLE [dbo].[Service_Vendor] ADD  CONSTRAINT [DF_Service_Vendor_Changed_Date]  DEFAULT (getdate()) FOR [Changed_Date]
				GO

				/****** Object:  Table [dbo].[Steril_Central]    Script Date: 27-04-2022 11:11:15 ******/
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
				GO

				ALTER TABLE [dbo].[Steril_Central] ADD  CONSTRAINT [DF_Steril_Central_Changed_Date]  DEFAULT (getdate()) FOR [Changed_Date]
				GO

				/****** Object:  Table [dbo].[Storage_Log]    Script Date: 27-04-2022 11:12:06 ******/
				CREATE TABLE [dbo].[Storage_Log](
					[Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[Tray_ID] [bigint] NULL,
					[Container_ID] [bigint] NULL,
					[Returned] [bit] NULL,
					[Date_Changed] [datetime] NULL
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Storage_Log] ADD  CONSTRAINT [DF_Storage_Log_Returned]  DEFAULT ((0)) FOR [Returned]
				GO

				ALTER TABLE [dbo].[Storage_Log] ADD  CONSTRAINT [DF_Storage_Log_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				/****** Object:  Table [dbo].[SW_Update]    Script Date: 27-04-2022 11:12:45 ******/
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
				GO

				ALTER TABLE [dbo].[SW_Update] ADD  CONSTRAINT [DF_SW_Update_SW_Path]  DEFAULT ('\\Server_SW') FOR [SW_Path]
				GO

				ALTER TABLE [dbo].[SW_Update] ADD  CONSTRAINT [DF_SW_Update_Mandatory]  DEFAULT ((0)) FOR [Mandatory]
				GO

				ALTER TABLE [dbo].[SW_Update] ADD  CONSTRAINT [DF_SW_Update_Blocked_Use]  DEFAULT ((0)) FOR [Blocked_Use]
				GO

				ALTER TABLE [dbo].[SW_Update] ADD  CONSTRAINT [DF_SW_Update_Update_Code]  DEFAULT ((100)) FOR [Update_Code]
				GO

				ALTER TABLE [dbo].[SW_Update] ADD  CONSTRAINT [DF_SW_Update_Last_Edited]  DEFAULT (getdate()) FOR [Changed_Date]
				GO

				/****** Object:  Table [dbo].[SystemInfo]    Script Date: 27-04-2022 11:13:04 ******/
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
				GO

				ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_Mandatory]  DEFAULT ((-1)) FOR [Mandatory]
				GO

				ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_GateNameSwitch]  DEFAULT ((0)) FOR [GateNameSwitch]
				GO

				ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_Use_Login]  DEFAULT ((1)) FOR [Use_Login]
				GO

				ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_Use_ActiveDirectory]  DEFAULT ((0)) FOR [Use_ActiveDirectory]
				GO

				ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_Login_Verification]  DEFAULT ((0)) FOR [Login_Verification]
				GO

				ALTER TABLE [dbo].[SystemInfo] ADD  CONSTRAINT [DF_SystemInfo_Use_Action]  DEFAULT ((0)) FOR [Use_Action]
				GO


				/****** Object:  Table [dbo].[TblPassword]    Script Date: 27-04-2022 11:13:15 ******/
				CREATE TABLE [dbo].[TblPassword](
					[UserID] [int] IDENTITY(1,1) NOT NULL,
					[UserName] [nvarchar](50) NULL,
					[PassCode] [nvarchar](max) NULL,
					[LastLogin] [datetime] NULL,
					[NumberLogins] [int] NULL,
					[WindowsUser] [nvarchar](50) NULL,
					[DashBoard] [bit] NULL,
					[DashBoardAdmin] [bit] NULL,
					[SecurityLevel] [smallint] NULL,
					[ChangedBy] [nvarchar](50) NULL,
					[ChangeDate] [datetime] NULL,
					[FirstName] [nvarchar](50) NULL,
					[FamilyName] [nvarchar](50) NULL,
					[RFID_Code] [nvarchar](max) NULL,
					[SEQ_Code] [nvarchar](max) NULL,
					[Log_ID] [bigint] NULL,
					[UserGuid] [uniqueidentifier] NULL,
					[Using_Action] [bit] NULL,
					[User_LastSeen_Date] [datetime] NULL,
					[User_LastSeen_Place] [nvarchar](50) NULL,
				 CONSTRAINT [PK_tblPassword] PRIMARY KEY CLUSTERED 
				(
					[UserID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[TblPassword] ADD  CONSTRAINT [DF_TblPassword_NumberLogins]  DEFAULT ((0)) FOR [NumberLogins]
				GO

				ALTER TABLE [dbo].[TblPassword] ADD  CONSTRAINT [DF_tblPassword_DashBoardAdmin]  DEFAULT ((0)) FOR [DashBoardAdmin]
				GO

				ALTER TABLE [dbo].[TblPassword] ADD  CONSTRAINT [DF_tblPassword_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				ALTER TABLE [dbo].[TblPassword] ADD  CONSTRAINT [DF_TblPassword_Log_ID]  DEFAULT (NULL) FOR [Log_ID]
				GO

				ALTER TABLE [dbo].[TblPassword] ADD  CONSTRAINT [DF_TblPassword_Using_Action]  DEFAULT ((0)) FOR [Using_Action]
				GO
				/****** Object:  Table [dbo].[Technical_Log]    Script Date: 27-04-2022 11:13:55 ******/

				CREATE TABLE [dbo].[Technical_Log](
					[Technical_Log_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[UserID] [int] NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[Description_ID] [nvarchar](50) NULL,
					[Technical_Type] [nvarchar](50) NULL,
					[ChangeDate] [datetime] NULL
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Technical_Log] ADD  CONSTRAINT [DF_Technical_Log_ChangeDate]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				/** 

					Tray Tables


				***/

				/****** Object:  Table [dbo].[Tray_Description]    Script Date: 27-04-2022 11:14:21 ******/
				CREATE TABLE [dbo].[Tray_Description](
					[Description_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Tray_Name] [nvarchar](50) NULL,
					[Tray_Description] [nvarchar](max) NULL,
					[Tray_Lock] [bit] NULL,
					[Date_Changed] [datetime] NULL,
					[Hide_Tray] [bit] NULL,
					[Deleted_Tray] [bit] NULL,
					[Cost_ID] [int] NOT NULL,
					[Special_Text] [nvarchar](max) NULL,
				 CONSTRAINT [PK_Tray_Description] PRIMARY KEY CLUSTERED 
				(
					[Description_ID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Tray_Lock]  DEFAULT ((1)) FOR [Tray_Lock]
				GO

				ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Hide_Tray]  DEFAULT ('0') FOR [Hide_Tray]
				GO

				ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Deleted_Tray]  DEFAULT ((0)) FOR [Deleted_Tray]
				GO

				ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Cost_ID]  DEFAULT ((0)) FOR [Cost_ID]
				GO

				ALTER TABLE [dbo].[Tray_Description] ADD  CONSTRAINT [DF_Tray_Description_Special_Text]  DEFAULT ((0)) FOR [Special_Text]
				GO

				/****** Object:  Table [dbo].[Tray_Image]    Script Date: 27-04-2022 11:14:31 ******/
				CREATE TABLE [dbo].[Tray_Image](
					[Image_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[TheImage] [varbinary](max) NULL,
					[Description_ID] [int] NULL,
					[Tray_Name] [nvarchar](50) NULL,
					[Date_Changed] [datetime] NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Tray_Image] ADD  CONSTRAINT [DF_Tray_Image_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				/****** Object:  Table [dbo].[Tray_Items]    Script Date: 27-04-2022 11:14:59 ******/
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
				GO

				ALTER TABLE [dbo].[Tray_Items] ADD  CONSTRAINT [DF_Tray_Items_Tray_Lock]  DEFAULT ((0)) FOR [Item_Mandatory]
				GO

				ALTER TABLE [dbo].[Tray_Items] ADD  CONSTRAINT [DF_Tray_Items_Hide_Tray]  DEFAULT ('0') FOR [Hide_Item]
				GO

				ALTER TABLE [dbo].[Tray_Items] ADD  CONSTRAINT [DF_Tray_Items_Deleted_Tray]  DEFAULT ((0)) FOR [Deleted_Item]
				GO

				ALTER TABLE [dbo].[Tray_Items] ADD  CONSTRAINT [DF_Tray_Items_Cost_ID]  DEFAULT ((0)) FOR [Cost_ID]
				GO

				ALTER TABLE [dbo].[Tray_Items] ADD  CONSTRAINT [DF_Tray_Items_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				/****** Object:  Table [dbo].[Tray_Log]    Script Date: 27-04-2022 11:15:12 ******/
				CREATE TABLE [dbo].[Tray_Log](
					[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Tray_ID] [bigint] NULL,
					[Packed_Name] [nvarchar](max) NULL,
					[Tray_Packed_Place] [nvarchar](50) NULL,
					[Tray_Packed_Start] [datetime] NULL,
					[Tray_Packed_End] [datetime] NULL,
					[Number_Instruments] [int] NULL,
					[Packed_Locked] [bit] NULL,
					[Tray_EPC_Nr] [nvarchar](50) NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				/****** Object:  Table [dbo].[Tray_Packed]    Script Date: 27-04-2022 11:15:23 ******/

				CREATE TABLE [dbo].[Tray_Packed](
					[Tray_EPC_Nr] [nvarchar](50) NULL,
					[Tray_Description_ID] [int] NOT NULL,
					[EPC_Nr] [nvarchar](50) NOT NULL,
					[Description_ID] [nvarchar](255) NULL,
					[Packed_Locked] [bit] NULL,
					[Date_Changed] [datetime] NULL,
					[Pack_User_ID] [int] NULL,
					[Pack_Station_ID] [int] NULL
				) ON [PRIMARY]
				GO

				/****** Object:  Table [dbo].[Tray_PackList]    Script Date: 27-04-2022 11:15:37 ******/
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
				GO

				ALTER TABLE [dbo].[Tray_PackList] ADD  CONSTRAINT [DF_Tray_PackList_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				/****** Object:  Table [dbo].[Tray_RFID]    Script Date: 27-04-2022 11:15:45 ******/
				CREATE TABLE [dbo].[Tray_RFID](
					[Tray_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[SEQ_Nr] [nvarchar](50) NULL,
					[Description_ID] [int] NULL,
					[Description_Text] [nvarchar](max) NULL,
					[Tray_Contents] [int] NULL,
					[Tray_LastSeen_Place] [nvarchar](50) NULL,
					[Tray_LastSeen_Date] [datetime] NULL,
					[Tray_InUse] [bit] NULL,
					[Date_Changed] [datetime] NULL,
					[Packed_Date] [datetime] NULL,
					[Special_Text] [nvarchar](max) NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Tray_RFID] ADD  CONSTRAINT [DF_Tray_RFID_Tray_Contents]  DEFAULT ((0)) FOR [Tray_Contents]
				GO

				ALTER TABLE [dbo].[Tray_RFID] ADD  CONSTRAINT [DF_Tray_RFID_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO


				/****** Object:  Table [dbo].[Tray_RFID_Life]    Script Date: 27-04-2022 11:15:58 ******/
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
				GO

				ALTER TABLE [dbo].[Tray_RFID_Life] ADD  CONSTRAINT [DF_Tray_RFID_Life_Last_Change]  DEFAULT (getdate()) FOR [Last_Change]
				GO

				/****** Object:  Table [dbo].[Trays_To_Pack]    Script Date: 27-04-2022 11:16:21 ******/
				CREATE TABLE [dbo].[Trays_To_Pack](
					[Tray_Pack_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Arrived_Date] [datetime] NULL,
					[Priority] [int] NOT NULL,
					[Desired_Date] [datetime] NULL,
					[Tray_ID] [int] NOT NULL,
					[Special_Text] [nvarchar](max) NULL,
					[Is_Taken_For_Pack] [bit] NOT NULL,
					[Changed_Date] [datetime] NULL,
					[Pack_Done] [bit] NOT NULL,
					[User_ID] [int] NOT NULL,
					[Cost_Center_ID] [int] NOT NULL,
					[Identity_Num] [int] NULL,
					[Demand_ID] [bigint] NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Arrived_Date]  DEFAULT (getdate()) FOR [Arrived_Date]
				GO

				ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Tray_ID]  DEFAULT ((0)) FOR [Tray_ID]
				GO

				ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Is_Taken_For_Pack]  DEFAULT ((0)) FOR [Is_Taken_For_Pack]
				GO

				ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Changed_Date]  DEFAULT (getdate()) FOR [Changed_Date]
				GO

				ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Pack_Done]  DEFAULT ((0)) FOR [Pack_Done]
				GO

				ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_User_ID]  DEFAULT ((0)) FOR [User_ID]
				GO

				ALTER TABLE [dbo].[Trays_To_Pack] ADD  CONSTRAINT [DF_Trays_To_Pack_Department_ID]  DEFAULT ((0)) FOR [Cost_Center_ID]
				GO


				/****** Object:  Table [dbo].[Treatment_Description]    Script Date: 27-04-2022 11:17:15 ******/
				CREATE TABLE [dbo].[Treatment_Description](
					[Treatment_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Treatment_Description] [nvarchar](max) NOT NULL,
					[Change_Date] [datetime] NULL,
					[Treatment_Path] [varchar](max) NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Treatment_Description] ADD  CONSTRAINT [DF_Treatment_Description_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
				GO


				/****** Object:  Table [dbo].[Treatment_Detail]    Script Date: 27-04-2022 11:17:25 ******/
				CREATE TABLE [dbo].[Treatment_Detail](
					[Detail_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Treatment_ID] [bigint] NULL,
					[The_Order] [smallint] NULL,
					[Detail_Text] [nvarchar](max) NULL,
					[Change_Date] [datetime] NULL,
					[Treatment_Type] [bigint] NULL,
					[Detail_Name] [varchar](50) NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Treatment_Detail] ADD  CONSTRAINT [DF_Treatment_Detail_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
				GO

				/****** Object:  Table [dbo].[Treatment_Log]    Script Date: 27-04-2022 11:17:41 ******/
				CREATE TABLE [dbo].[Treatment_Log](
					[Treatment_ID] [bigint] NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[Detail_ID] [bigint] NULL,
					[TreatLog_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[UserID] [int] NULL,
					[ChangeDate] [datetime] NOT NULL,
					[Done_ID] [bigint] NULL,
					[Start_Time] [datetime] NULL
				) ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Treatment_Log] ADD  CONSTRAINT [DF_Treatment_Log_Change_Date]  DEFAULT (getdate()) FOR [ChangeDate]
				GO

				ALTER TABLE [dbo].[Treatment_Log] ADD  CONSTRAINT [DF_Treatment_Log_Start_Time]  DEFAULT (getdate()) FOR [Start_Time]
				GO

				/****** Object:  Table [dbo].[Treatment_Type]    Script Date: 27-04-2022 11:18:16 ******/
				CREATE TABLE [dbo].[Treatment_Type](
					[Index_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[Description_Type] [nchar](10) NOT NULL,
					[Server_Path] [nvarchar](max) NULL,
					[Change_Date] [datetime] NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Treatment_Type] ADD  CONSTRAINT [DF_Treatment_Type_Change_Date]  DEFAULT (getdate()) FOR [Change_Date]
				GO

				/****** Object:  Table [dbo].[Area_Name_List]    Script Date: 27-04-2022 11:34:43 ******/

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
				GO

				ALTER TABLE [dbo].[Area_Name_List] ADD  CONSTRAINT [DF_Area_Name_List_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				/****** Object:  Table [dbo].[Department]    Script Date: 27-04-2022 11:35:00 ******/
				CREATE TABLE [dbo].[Department](
					[Department_ID] [int] IDENTITY(1,1) NOT NULL,
					[Department_Name] [nvarchar](max) NULL,
					[Department_Code] [nvarchar](max) NULL,
				 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
				(
					[Department_ID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

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
				GO

				ALTER TABLE [dbo].[Cart_Description] ADD  CONSTRAINT [DF_Cart_Description_Cart_Lock]  DEFAULT ((1)) FOR [Cart_Lock]
				GO

				ALTER TABLE [dbo].[Cart_Description] ADD  CONSTRAINT [DF_Cart_Description_Date_Changed]  DEFAULT (getdate()) FOR [Date_Changed]
				GO

				CREATE TABLE [dbo].[Cart_RFID](
					[Cart_ID] [bigint] IDENTITY(1,1) NOT NULL,
					[EPC_Nr] [nvarchar](50) NULL,
					[SEQ_Nr] [nvarchar](50) NULL,
					[Description_ID] [int] NULL,
					[Special_Text] [nvarchar](max) NULL,
					[Cart_Contents] [int] NULL,
					[Cart_LastSeen_Place] [nvarchar](50) NULL,
					[Cart_LastSeen_Date] [datetime] NULL,
					[Cart_Changed] [datetime] NULL,
					[Cart_InUse] [bit] NULL,
				 CONSTRAINT [PK_Cart_RFID] PRIMARY KEY CLUSTERED 
				(
					[Cart_ID] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				ALTER TABLE [dbo].[Cart_RFID] ADD  CONSTRAINT [DF_Cart_RFID_Cart_Contents]  DEFAULT ((0)) FOR [Cart_Contents]
				GO

				ALTER TABLE [dbo].[Cart_RFID] ADD  CONSTRAINT [DF_Cart_RFID_Cart_Changed]  DEFAULT (getdate()) FOR [Cart_Changed]
				GO


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
				GO

				ALTER TABLE [dbo].[Cart_RFID_Life] ADD  CONSTRAINT [DF_Cart_RFID_Life_Last_Change]  DEFAULT (getdate()) FOR [Last_Change]
				GO

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
				GO

				ALTER TABLE [dbo].[Antenna_Reader] ADD  CONSTRAINT [DF_Antenna_Reader_Antenna_Function]  DEFAULT ((0)) FOR [Antenna_Factor]
				GO

				ALTER TABLE [dbo].[Antenna_Reader] ADD  CONSTRAINT [DF_Antenna_Reader_In_Use]  DEFAULT (N'Yes') FOR [In_Use]
				GO

				ALTER TABLE [dbo].[Antenna_Reader] ADD  CONSTRAINT [DF_Antenna_Reader_StartDate]  DEFAULT (getdate()) FOR [StartDate]
				GO

				EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Used to tell if it is a :
				0=Initialized NOT IN USE
				1= passing antenna - like a door
				2= Box where items can be BOTH  taken from and stored
				3=Box where Items ONLY can taken from
				4=Box where Items ONLY can be stored' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Antenna_Reader', @level2type=N'COLUMN',@level2name=N'Antenna_Factor'
				GO

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
                GO
                SET IDENTITY_INSERT [dbo].[Instrument_Vendor] ON 
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (87, N'AESCULAP', N'AES       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.567' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (88, N'BOSS', N'BOS       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.567' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (90, N'CARL ZEISS', N'CZ        ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.570' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (91, N'CODMAN', N'COD       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.570' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (92, N'ELEKTA', N'EL 9876   ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.570' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (93, N'FEHLING INSTRUMENTS', N'FEH       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.570' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (94, N'FUJITA', N'FUJ       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.570' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (95, N'GIMMI', N'GIM88     ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.570' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (96, N'HIPP MEDICAL', N'HIP       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.570' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (97, N'JOHNSON & JOHNSON', N'JJ        ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.573' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (98, N'KARL STORZ', N'KST       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.573' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (99, N'KLS MARTIN', N'KLM       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.573' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (100, N'MEDICON', N'MED       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.573' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (101, N'MEDTRONIC', N'MED       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.577' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (102, N'MIZUHO', N'MIZ       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.577' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (103, N'PRO MED INSTRUMENTS', N'POM       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.577' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (104, N'SMITH & NEPHEW', N'SN        ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.577' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (105, N'STILLE', N'STI       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.577' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (106, N'STRYKER', N'STR       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.577' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (107, N'SYNTHES', N'SYN       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.577' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (108, N'TELEFLEX', N'TEL       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.577' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (109, N'TUMED', N'TUM       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.580' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (110, N'ULRICH MEDICAL', N'ULR       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.580' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (112, N'ZEPPELIN', N'ZEP       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:18:24.580' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (114, N'ZIMMER111', N'ZIM       ', NULL, NULL, NULL, CAST(N'2019-02-22T13:30:23.327' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (123, N'ABEL', N'ABEL      ', NULL, NULL, NULL, CAST(N'2019-02-26T09:54:50.843' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (125, N'ADAIR', N'ADAI      ', NULL, NULL, NULL, CAST(N'2019-02-26T09:54:50.850' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (446, N'ABRAHAM', N'ABRA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:52.330' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (447, N'ADSON', N'ADSO      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:56.063' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (448, N'ADLERKREUTZ', N'ADLE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:56.953' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (452, N'RICHARD WOLF', N'RICH      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.203' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (453, N'B.BRAUN', N'BBRA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.207' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (454, N'GEISTER', N'GEIS      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.207' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (455, N'BECTON DICKINSON', N'BECT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.210' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (456, N'C. R. BARD (BECTON DICKINSON)', N'CRBA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.210' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (457, N'CAREFUSION (BECTON DICKINSON)', N'CARE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.213' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (458, N'V. MUELLER (CAREFUSION)', N'VMUE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.213' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (459, N'COVIDIEN (MEDTRONIC)', N'COVI      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.217' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (460, N'DE PUY SYNTHES (JOHNSON & JOHNSON)', N'DEPU      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.220' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (462, N'BAXTER', N'BAXT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.223' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (463, N'ST. JUDE MEDICAL', N'STJU      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.223' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (464, N'SURGICAL HOLDINGS', N'SURG      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.227' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (465, N'CARDINAL HEALTH', N'CARD      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.227' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (466, N'BOSTON SCIENTIFIC', N'BOST      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.230' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (467, N'TYCO INTERNATIONAL', N'TYCO      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.230' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (468, N'PILLING WECK (TELEFLEX)', N'PILL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.230' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (469, N'AS MEDIZINTECHNIK', N'ASME      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.233' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (470, N'AR REUCHLEN', N'ARRE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.233' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (471, N'BEMA MEDICAL', N'BEMA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.237' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (472, N'MAYHA', N'MAYH      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.237' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (473, N'ERMIS MEDTECH', N'ERMI      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.240' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (474, N'FETZER MEDICAL', N'FETZ      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.240' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (475, N'GEUDER', N'GEUD      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.240' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (476, N'HEBA MEDICAL', N'HEBA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.243' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (477, N'HEIKO WILD', N'HEIK      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.243' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (478, N'HENKE-SASS, WOLF', N'HENK      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.247' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (479, N'ERBE', N'ERBE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.250' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (480, N'MATTES INSTRUMENTE', N'MATT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.250' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (481, N'MICROMED MEDIZIN TECHNIK', N'MICR      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.253' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (482, N'PETER LAZIC GMBH', N'PETE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.253' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (483, N'REGER MEDIZINTECHNIK', N'REGE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.253' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (484, N'SCHÖLLY', N'SCHÖ      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.257' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (485, N'RUDOLF STORZ', N'RUDO      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.257' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (486, N'STEMA MEDIZINTECHNIK', N'STEM      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.257' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (487, N'WEBER INSTRUMENTE', N'WEBE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.260' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (488, N'VOMED', N'VOME      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.260' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (489, N'SUTTER', N'SUTT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.260' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (490, N'INOMED', N'INOM      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:16:59.260' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (492, N'ADSON BROWN', N'ADSO1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:24:57.903' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (493, N'ADSON-ANDERSON', N'ADSO2     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:26:02.387' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (494, N'ADSON-BROWN', N'ADSO3     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:26:02.390' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (507, N'ALLIS', N'ALLI      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.287' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (508, N'ALLIS- THOMS', N'ALLI1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.290' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (509, N'ALLISON', N'ALLI2     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.290' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (510, N'ALUMINIUM', N'ALUM      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.293' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (511, N'ANDERSON- ADSON', N'ANDE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.293' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (512, N'AUTO', N'AUTO      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.297' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (513, N'AUTO INSERTED', N'AUTO1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.300' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (515, N'BARRÉ', N'BARR      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.303' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (516, N'BENNETT', N'BENN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.307' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (517, N'BENSAUDE', N'BENS      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.310' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (518, N'BERGMANN', N'BERG      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.313' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (519, N'BILSOE', N'BILS      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.320' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (520, N'BLOUNT', N'BLOU      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.323' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (521, N'BRAUN', N'BRAU      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.327' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (524, N'BROM', N'BROM      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.350' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (525, N'BRUNS', N'BRUN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.350' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (526, N'BRÜNIGS', N'BRÜN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.357' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (527, N'BUCHWALD', N'BUCH      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.363' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (528, N'BUMM', N'BUMM      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.373' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (529, N'BUNNELL', N'BUNN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.373' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (530, N'CARREL', N'CARR      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.377' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (531, N'CASPAR', N'CASP      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.377' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (532, N'CASTROVIEJO', N'CAST      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.380' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (533, N'CHEATTLE', N'CHEA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.380' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (534, N'CLOWARD', N'CLOW      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.383' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (536, N'COLLIN', N'COLL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.383' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (538, N'COOLEY', N'COOL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.387' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (539, N'CRILE', N'CRIL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.387' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (540, N'CUSHING', N'CUSH      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.387' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (541, N'CZERNY', N'CZER      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.390' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (542, N'DE BAKEY', N'DEBA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.390' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (544, N'DESCRIPTION_NAME', N'DESC      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.393' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (545, N'DIETHRICH', N'DIET      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.397' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (546, N'DINGMAN', N'DING      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.397' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (547, N'DOYEN', N'DOYE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.400' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (548, N'DUPLAY', N'DUPL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.400' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (549, N'DUVAL- COLLIN', N'DUVA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.400' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (550, N'EAST- GRINSTED WARD', N'EAST      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.403' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (551, N'ENGEL', N'ENGE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.403' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (552, N'ESMARCH', N'ESMA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.407' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (553, N'FICKLING', N'FICK      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.407' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (554, N'FOMON', N'FOMO      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.407' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (555, N'FRIEDMANN', N'FRIE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.410' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (556, N'GALABINS', N'GALA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.410' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (557, N'GELPI', N'GELP      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.410' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (558, N'GERALD', N'GERA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.410' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (559, N'GOSLEE', N'GOSL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.410' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (560, N'HARDY', N'HARD      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.413' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (561, N'HARDY-FAHLBUSCH', N'HARD1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.417' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (562, N'HARRINGTON-MIXTER', N'HARR      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.417' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (563, N'HEANEY', N'HEAN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.420' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (564, N'HEANEY MODIF.', N'HEAN1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.420' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (565, N'HEANEY-REZEK', N'HEAN2     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.420' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (566, N'HEATH', N'HEAT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.423' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (567, N'HEGENBARTH', N'HEGE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.423' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (568, N'HENNING', N'HENN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.427' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (569, N'HERRICK', N'HERR      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.427' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (570, N'HEYWOOD-SMITH', N'HEYW      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.427' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (571, N'HEYWOOD-SMITH MODIF.', N'HEYW1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.433' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (572, N'HÖSEL', N'HÖSE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.437' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (574, N'IVES-FANSLER', N'IVES      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.440' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (575, N'JACOBS', N'JACO      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.440' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (576, N'JACOBSON', N'JACO1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.443' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (577, N'JAVID', N'JAVI      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.443' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (578, N'JOLL', N'JOLL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.447' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (579, N'JUDD- ALLIS', N'JUDD      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.447' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (580, N'KADER', N'KADE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.447' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (581, N'KAVO', N'KAVO      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.450' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (582, N'KILIAN', N'KILI      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.450' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (583, N'KOCHER', N'KOCH      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.450' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (584, N'KOGAN', N'KOGA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.450' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (585, N'KRISTELLER', N'KRIS      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.453' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (586, N'KÜSTNER', N'KÜST      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.453' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (587, N'LANGENBECK', N'LANG      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.453' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (588, N'LEES', N'LEES      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.457' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (589, N'LISTER', N'LIST      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.457' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (590, N'LITTLEWOOD', N'LITT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.457' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (591, N'LOCKWOOD', N'LOCK      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.460' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (592, N'LUCAS', N'LUCA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.460' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (593, N'LUER- FRIEDMANN', N'LUER      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.460' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (594, N'MAINGOT', N'MAIN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.460' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (595, N'MANNERFELT MODIF.', N'MANN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.463' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (596, N'MARBURG MODELL', N'MARB      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.463' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (597, N'MARTIN', N'MART      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.463' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (598, N'MARTIN-ASEPTIC', N'MART1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.467' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (599, N'MAYO-HARRINGTON', N'MAYO      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.467' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (600, N'MAYO-STILLE', N'MAYO1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.470' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (601, N'MC IVOR', N'MCIV      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.470' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (602, N'MEAD', N'MEAD      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.470' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (603, N'MICHEL', N'MICH      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.473' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (604, N'MICRO-HALSTED', N'MICR1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.473' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (605, N'MILLIN', N'MILL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.477' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (606, N'MILLS', N'MILL1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.477' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (607, N'MIXTER', N'MIXT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.477' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (608, N'MOD. USA', N'MODU      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.480' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (609, N'MORRIS', N'MORR      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.480' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (610, N'MOYNIHAN', N'MOYN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.480' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (611, N'MUSEUX', N'MUSE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.480' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (612, N'MÜHLING', N'MÜHL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.483' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (613, N'MÜLLER', N'MÜLL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.483' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (614, N'NEGUS', N'NEGU      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.483' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (615, N'NIEDERDELLMANN', N'NIED      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.487' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (616, N'NORFOLK- NORWICH', N'NORF      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.487' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (617, N'OBWEGESER', N'OBWE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.487' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (618, N'OCHSNER', N'OCHS      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.490' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (619, N'PEAN', N'PEAN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.490' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (620, N'PENFIELD', N'PENF      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.490' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (621, N'PENNINGTON', N'PENN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.490' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (622, N'PENNYBACKER', N'PENN1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.493' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (623, N'PERTHES', N'PERT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.493' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (624, N'PHANEUF', N'PHAN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.493' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (625, N'POTTS- DE MARTEL', N'POTT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.497' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (627, N'POTTS-SMITH', N'POTT2     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.497' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (628, N'POZZI', N'POZZ      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.500' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (629, N'PRATT', N'PRAT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.500' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (630, N'PRICE- THOMAS', N'PRIC      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.500' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (631, N'RECAMIER', N'RECA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.500' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (632, N'REVERDIN', N'REVE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.503' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (633, N'ROBERTS', N'ROBE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.503' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (634, N'ROCHESTER- CARMALT', N'ROCH      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.503' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (635, N'SAROT', N'SARO      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.507' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (636, N'SAUERBRUCH', N'SAUE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.507' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (637, N'SCHMIEDEN- TAILOR', N'SCHM      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.507' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (638, N'SCHRÖDER', N'SCHR      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.510' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (639, N'SCHWARZ', N'SCHW      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.510' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (640, N'SEIDL', N'SEID      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.510' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (641, N'SEUTIN', N'SEUT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.513' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (642, N'SIMS', N'SIMS      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.513' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (643, N'SIRONA', N'SIRO      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.513' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (644, N'SMILLIE', N'SMIL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.517' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (645, N'ST. MARKS', N'STMA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.517' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (646, N'STELLBRINK', N'STEL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.517' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (648, N'STRULLY', N'STRU      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.520' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (649, N'SYMMETRY SURGICAL', N'SYMM      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.520' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (650, N'SYPERT', N'SYPE      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.520' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (651, N'SYSTRUNK', N'SYST      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.520' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (652, N'TEALE', N'TEAL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.523' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (653, N'TOENNIS', N'TOEN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.523' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (654, N'TUFFIER', N'TUFF      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.523' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (655, N'TÜBINGEN', N'TÜBI      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.527' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (657, N'WALLICH', N'WALL      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.530' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (658, N'WEISSBARTH', N'WEIS      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.530' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (659, N'WERTHEIM', N'WERT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.533' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (660, N'WERTHEIM- CULLEN', N'WERT1     ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.537' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (661, N'WIENER MODELL', N'WIEN      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.537' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (662, N'WILSON', N'WILS      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.537' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (663, N'WINTER', N'WINT      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.540' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (664, N'WÖRRLEIN', N'WÖRR      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.540' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (665, N'YASARGIL', N'YASA      ', NULL, NULL, NULL, CAST(N'2019-02-28T10:49:15.540' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (666, N'BABY- MOSQUITO', N'BABY      ', NULL, NULL, NULL, CAST(N'2019-07-28T10:09:45.630' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (667, N'CLOWARD MODIF.', N'CLOW1     ', NULL, NULL, NULL, CAST(N'2019-07-28T10:09:45.640' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (668, N'COLLIN- POZZI', N'COLL1     ', NULL, NULL, NULL, CAST(N'2019-07-28T10:09:45.643' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (669, N'DEPUY', N'DEPU1     ', NULL, NULL, NULL, CAST(N'2019-07-28T10:09:45.647' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (670, N'INSTRUMENT_COMPANY', N'INST      ', NULL, NULL, NULL, CAST(N'2019-07-28T10:09:45.650' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (671, N'POTTS-DE MARTEL', N'POTT1     ', NULL, NULL, NULL, CAST(N'2019-07-28T10:09:45.663' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (672, N'RICARD WOLF', N'RICA      ', NULL, NULL, NULL, CAST(N'2019-07-28T10:09:45.667' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (673, N'STILLE-AESCULAP', N'STIL      ', NULL, NULL, NULL, CAST(N'2019-07-28T10:09:45.673' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (674, N'V.MUELLER', N'VMUE1     ', NULL, NULL, NULL, CAST(N'2019-07-28T10:09:45.680' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (676, N'SURGICALWELL', N'SUW       ', NULL, NULL, NULL, CAST(N'2021-02-13T10:51:48.143' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (677, N'UNKNOWN', N'UNKN      ', NULL, NULL, NULL, CAST(N'2022-02-23T12:30:01.390' AS DateTime))
                GO
                INSERT [dbo].[Instrument_Vendor] ([Vendor_ID], [Vendor_Name], [Vendor_Abbreviation], [Barcode_Prefix], [Barcode_Suffix], [Delimiter_Sign], [Last_Date_Change]) VALUES (680, N'UNKNOWN', N'UNKN      ', NULL, NULL, NULL, CAST(N'2022-02-23T00:00:00.000' AS DateTime))
                GO
                SET IDENTITY_INSERT [dbo].[Instrument_Vendor] OFF
                GO
                ALTER TABLE [dbo].[Instrument_Vendor] ADD  CONSTRAINT [DF_Instrument_Vendor_Last_Date_Change]  DEFAULT (getdate()) FOR [Last_Date_Change]
                GO
			");
	        
	        CreateTable(
			        "dbo.ValidatedPackingListLineItems",
			        c => new
			        {
				        Id = c.Int(nullable: false, identity: true),
				        Timestamp = c.DateTime(nullable: false),
				        Expected = c.Int(nullable: false),
				        Actual = c.Int(nullable: false),
				        DescriptionId = c.String(),
				        Description = c.String(),
				        ValidatedPackingList_Id = c.Int(),
			        })
		        .PrimaryKey(t => t.Id)
		        .ForeignKey("dbo.ValidatedPackingLists", t => t.ValidatedPackingList_Id)
		        .Index(t => t.ValidatedPackingList_Id);

	        CreateTable(
			        "dbo.ValidatedPackingLists",
			        c => new
			        {
				        Id = c.Int(nullable: false, identity: true),
				        Timestamp = c.DateTime(nullable: false),
				        Location = c.String(),
				        TrayId = c.Long(nullable: false),
				        Result = c.Int(nullable: false),
			        })
		        .PrimaryKey(t => t.Id)
		        .ForeignKey("dbo.Tray_Description", t => t.TrayId, cascadeDelete: true)
		        .Index(t => t.TrayId);

	        CreateTable(
			        "dbo.ValidatedPackingListLineItemInstrument_RFID",
			        c => new
			        {
				        ValidatedPackingListLineItem_Id = c.Int(nullable: false),
				        Instrument_RFID_Instrument_ID = c.Long(nullable: false),
				        Instrument_RFID_EPC_Nr = c.String(nullable: false, maxLength: 50),
			        })
		        .PrimaryKey(t => new { t.ValidatedPackingListLineItem_Id, t.Instrument_RFID_Instrument_ID, t.Instrument_RFID_EPC_Nr })
		        .ForeignKey("dbo.ValidatedPackingListLineItems", t => t.ValidatedPackingListLineItem_Id, cascadeDelete: true)
		        .Index(t => t.ValidatedPackingListLineItem_Id)
		        .Index(t => new { t.Instrument_RFID_Instrument_ID, t.Instrument_RFID_EPC_Nr });
	        
	        Sql(@"
				SET ANSI_NULLS ON
				GO

				SET QUOTED_IDENTIFIER ON
				GO

				CREATE TABLE [dbo].[ServiceActionRecords](
					[Id] [int] IDENTITY(1,1) NOT NULL,
					[ServiceActionTemplateId] [int] NOT NULL,
					[ServiceRequestId] [int] NOT NULL,
					[UserId] [int] NOT NULL,
					[Timestamp] [datetime] NOT NULL,
					[Location] [nvarchar](100) NOT NULL
				) ON [PRIMARY]
				GO

				CREATE TABLE [dbo].[ServiceActionRecordLines](
					[Id] [int] IDENTITY(1,1) NOT NULL,
					[ServiceActionRecordId] [int] NOT NULL,
					[ServiceActionTemplateLineId] [int] NOT NULL,
					[Checked] [bit] NOT NULL
				) ON [PRIMARY]
				GO

				CREATE TABLE [dbo].[ServiceActionTemplates](
					[Id] [int] IDENTITY(1,1) NOT NULL,
					[Name] [nvarchar](100) NOT NULL,
					[Description] [nvarchar](max) NOT NULL,
					[StartStates] [nvarchar](max) NOT NULL,
					[EndState] [nvarchar](50) NOT NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				CREATE TABLE [dbo].[ServiceActionTemplateLines](
					[Id] [int] IDENTITY(1,1) NOT NULL,
					[ServiceActionTemplateId] [int] NOT NULL,
					[LineContents] [nvarchar](200) NOT NULL
				) ON [PRIMARY]
				GO

				CREATE TABLE [dbo].[ServiceRequests](
					[Id] [int] IDENTITY(1,1) NOT NULL,
					[InstrumentId] [bigint] NOT NULL,
					[InstrumentEPC] [nvarchar](max) NOT NULL,
					[Timestamp] [datetime] NOT NULL,
					[State] [nvarchar](50) NOT NULL,
					[Note] [nvarchar](max) NOT NULL,
					[TriggeredBy] [nvarchar](50) NOT NULL,
					[ServiceRuleId] [int] NOT NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				CREATE TABLE [dbo].[ServiceRules](
					[Id] [int] NOT NULL,
					[Name] [nvarchar](50) NOT NULL,
					[Description] [nvarchar](max) NOT NULL,
					[Cycles] [int] NOT NULL
				) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
				GO

				CREATE TABLE [dbo].[UncommittedAssetIds] (
					[Id] [int] NOT NULL IDENTITY,
					[Timestamp] [datetime] NOT NULL,
					CONSTRAINT [PK_dbo.UncommittedAssetIds] PRIMARY KEY ([Id])
				)

				SET ANSI_PADDING ON
				GO

				/****** Object:  Index [Instrument_Description_Index]    Script Date: 04-08-2022 11:37:32 ******/
				CREATE NONCLUSTERED INDEX [Instrument_Description_Index] ON [dbo].[Instrument_Description]
				(
					[Description_ID] ASC,
					[Description_Name] ASC,
					[D] ASC,
					[E] ASC
				)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
				GO
			");
        }

        private void DropTables()
        {
	        DropTable("dbo.ValidatedPackingListLineItemInstrument_RFID");
			DropTable("dbo.Trays_To_Pack");
			DropTable("dbo.Tray_RFID_Life");
			DropTable("dbo.Tray_RFID");
			DropTable("dbo.Tray_PackList");
			DropTable("dbo.Tray_Packed");
			DropTable("dbo.Tray_Log");
			DropTable("dbo.Tray_Items");
			DropTable("dbo.Tray_Image");
			DropTable("dbo.ValidatedPackingListLineItems");
			DropTable("dbo.ValidatedPackingLists");
			DropTable("dbo.Tray_Description");
            DropTable("dbo.UncommittedAssetIds");
            DropTable("dbo.Treatment_Type");
            DropTable("dbo.Treatment_Log");
            DropTable("dbo.Treatment_Detail");
            DropTable("dbo.Treatment_Description");
            DropTable("dbo.Technical_Log");
            DropTable("dbo.TblPassword");
            DropTable("dbo.SystemInfo");
            DropTable("dbo.SW_Update");
            DropTable("dbo.Storage_Log");
            DropTable("dbo.Steril_Central");
            DropTable("dbo.ServiceActionTemplateLines");
            DropTable("dbo.ServiceActionTemplates");
            DropTable("dbo.ServiceActionRecordLines");
            DropTable("dbo.ServiceActionRecords");
            DropTable("dbo.Service_Vendor");
            DropTable("dbo.Service_Log");
            DropTable("dbo.ScanEvent");
            DropTable("dbo.Rules_Log");
            DropTable("dbo.Reader_ErrorLog");
            DropTable("dbo.Reader_Description");
            DropTable("dbo.Procedure_Demand_List");
            DropTable("dbo.OR_Trays_ID");
            DropTable("dbo.OR_Procedure");
            DropTable("dbo.Not_Known_RFID");
            DropTable("dbo.LogIn_Table");
            DropTable("dbo.Login_Security");
            DropTable("dbo.Log_Change");
            DropTable("dbo.Lend_Log");
            DropTable("dbo.Instrument_Translation_Vendor");
            DropTable("dbo.Instrument_Translation");
            DropTable("dbo.Instrument_Rules");
            DropTable("dbo.Instrument_RFID_Life");
            DropTable("dbo.Instrument_RFID_History");
            DropTable("dbo.ServiceRules");
            DropTable("dbo.ServiceRequests");
            DropTable("dbo.Operations");
            DropTable("dbo.OperationInstruments");
            DropTable("dbo.Instrument_RFID");
            DropTable("dbo.Instrument_Packed_Log");
            DropTable("dbo.Instrument_Maintenance_RFID");
            DropTable("dbo.Instrument_Image");
            DropTable("dbo.Instrument_Group");
            DropTable("dbo.Instrument_Description");
            DropTable("dbo.Department");
            DropTable("dbo.Demand_Service_Log");
            DropTable("dbo.Cost_Type");
            DropTable("dbo.Cost_Log");
            DropTable("dbo.Cost_Item");
            DropTable("dbo.Cost_Center");
            DropTable("dbo.Container_RFID_Life");
            DropTable("dbo.Container_RFID");
            DropTable("dbo.Container_Description");
            DropTable("dbo.ConfigTable");
            DropTable("dbo.Cart_RFID_Life");
            DropTable("dbo.Cart_RFID");
            DropTable("dbo.Cart_Description");
            DropTable("dbo.Area_Name_List");
            DropTable("dbo.Antenna_Reader");
			DropTable("dbo.EPC_Number_Serie");
        }
    }
}

