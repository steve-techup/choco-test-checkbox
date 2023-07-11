namespace Caretag_Class.Migrations
{
	using Caretag_Class.Migrations.Base;

	public partial class First : DbMigrationBase
    {
        private void CreateViews()
        {
            Sql(@"
				CREATE VIEW [dbo].[View_AllInstruments]
				AS
				SELECT     dbo.Department.Department_Name, dbo.Instrument_Description.Description_Name, dbo.Instrument_Description.D, dbo.Instrument_Description.E, 
									  dbo.Instrument_RFID.EPC_Nr, dbo.Instrument_Description.Instrument_Company
				FROM         dbo.Instrument_RFID INNER JOIN
									  dbo.Instrument_Description ON dbo.Instrument_RFID.Description_ID = dbo.Instrument_Description.Description_ID INNER JOIN
									  dbo.Department ON dbo.Instrument_RFID.Department_ID = dbo.Department.Department_ID
				GO

				
				/****** Object:  View [dbo].[View_Carts_In_Database]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Carts_In_Database]
				AS
				SELECT        dbo.Cart_RFID.Cart_ID, dbo.Cart_RFID.EPC_Nr, dbo.Cart_RFID.SEQ_Nr, dbo.Cart_Description.Cart_Name, dbo.Cart_Description.Cart_Description, dbo.Cart_Description.Cart_Lock, dbo.Cart_Description.Date_Changed, 
										 dbo.Cart_RFID.Description_ID, dbo.Cart_RFID.Cart_LastSeen_Place, dbo.Cart_RFID.Cart_LastSeen_Date, dbo.Cart_RFID.Cart_Changed, dbo.Cart_RFID.Cart_Contents, DATEDIFF(day, dbo.Cart_RFID.Cart_LastSeen_Date, 
										 GETDATE()) AS Days, dbo.Cart_RFID.Special_Text
				FROM            dbo.Cart_RFID INNER JOIN
										 dbo.Cart_Description ON dbo.Cart_RFID.Description_ID = dbo.Cart_Description.Description_ID
				GO
				/****** Object:  View [dbo].[View_Combine]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Combine]
				AS
				SELECT        TOP (100) PERCENT ID, Description_ID, Maintenance_Value, Maintenance_Periods, Maintenance_Period_Start
				FROM            (SELECT        Rules_ID AS ID, Maintenance_Text, Description_ID, Maintenance_Value, Maintenance_Periods, Maintenance_Period_Start
										  FROM            dbo.Instrument_Rules
										  UNION
										  SELECT        Rules_ID AS ID, Maintenance_Text, Description_ID, Maintenance_Value, Maintenance_Periods, Maintenance_Period_Start
										  FROM            dbo.Instrument_Rules AS Instrument_Rules_1) AS a
				ORDER BY Description_ID DESC
				GO
				/****** Object:  View [dbo].[View_Containers_In_Database]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Containers_In_Database]
				AS
				SELECT        dbo.Container_RFID.EPC_Nr, dbo.Container_RFID.Description_ID, dbo.Container_RFID.Container_Contents, dbo.Container_RFID.Container_LastSeen_Place, dbo.Container_RFID.Container_LastSeen_Date, 
										 dbo.Container_RFID.Container_Changed, dbo.Container_Description.Container_Name, dbo.Container_Description.Container_Description, dbo.Container_Description.Container_Lock, dbo.Container_Description.Date_Changed, 
										 DATEDIFF(day, dbo.Container_RFID.Container_LastSeen_Date, GETDATE()) AS Days, dbo.Container_RFID.Special_Text
				FROM            dbo.Container_RFID INNER JOIN
										 dbo.Container_Description ON dbo.Container_RFID.Description_ID = dbo.Container_Description.Description_ID
				GO
				/****** Object:  View [dbo].[View_CostCenter]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_CostCenter]
				AS
				SELECT        dbo.Cost_Center.Index_ID, dbo.Cost_Center.Cost_Center_Name, dbo.Cost_Type.Cost_Type, dbo.Cost_Type.Cost_Price, dbo.Cost_Center.Hidden_Center, dbo.Cost_Center.Change_Date, dbo.Cost_Item.Cost_Center, 
										 dbo.Cost_Item.Cost_Type_ID, dbo.Cost_Item.Default_Cost, dbo.Cost_Center.Cost_Center_Code, dbo.Cost_Center.Extra_Text, dbo.Cost_Center.Default_Always
				FROM            dbo.Cost_Center INNER JOIN
										 dbo.Cost_Item ON dbo.Cost_Center.Index_ID = dbo.Cost_Item.Cost_Center INNER JOIN
										 dbo.Cost_Type ON dbo.Cost_Item.Cost_Type_ID = dbo.Cost_Type.Index_ID
				GO
				/****** Object:  View [dbo].[View_EPC_DescriptionName_New]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_EPC_DescriptionName_New]
				AS
				SELECT        Description_ID, Description_Name, D, E, Instrument_Company, Description_Name + N' ' + D + N' ' + E AS FullName
				FROM            dbo.Instrument_Description
				GO
				/****** Object:  View [dbo].[View_EPC_DescriptionName_Org]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_EPC_DescriptionName_Org]
				AS
				SELECT     dbo.Instrument_RFID.EPC_Nr, dbo.Instrument_RFID.Description_ID, dbo.Instrument_Description.Description_Name, dbo.Instrument_Description.D, 
									  dbo.Instrument_Description.E, dbo.Instrument_Description.Instrument_Company, dbo.Instrument_RFID.Instrument_LastSeen_Place, 
									  dbo.Instrument_RFID.Instrument_LastSeen_Date
				FROM         dbo.Instrument_RFID INNER JOIN
									  dbo.Instrument_Description ON dbo.Instrument_RFID.Description_ID = dbo.Instrument_Description.Description_ID
				GO
				/****** Object:  View [dbo].[View_EPC_To_Tray]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_EPC_To_Tray]
				AS
				SELECT        dbo.Instrument_RFID.EPC_Nr, dbo.Instrument_Description.Description_Name, dbo.Instrument_Description.Instrument_Company, dbo.Instrument_RFID.Description_ID, dbo.Tray_PackList.Number, 
										 dbo.Tray_PackList.Tray_Descrip_ID, dbo.Tray_PackList.Instrument_Descrip_ID, dbo.Tray_PackList.Index_ID, dbo.Tray_Description.Tray_Name, dbo.Tray_Description.Tray_Description, 
										 dbo.Tray_Description.Tray_Lock, dbo.Tray_Description.Date_Changed
				FROM            dbo.Tray_PackList INNER JOIN
										 dbo.Tray_Description ON dbo.Tray_PackList.Tray_Descrip_ID = dbo.Tray_Description.Description_ID RIGHT OUTER JOIN
										 dbo.Instrument_Description INNER JOIN
										 dbo.Instrument_RFID ON dbo.Instrument_Description.Description_ID = dbo.Instrument_RFID.Description_ID ON dbo.Tray_PackList.Instrument_Descrip_ID = dbo.Instrument_Description.Description_ID
				GO

				/****** Object:  View [dbo].[View_Full_UserName]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Full_UserName]
				AS
				SELECT        UserID, UserName, FirstName + N' ' + FamilyName AS Full_Name, SecurityLevel, NumberLogins
				FROM            dbo.TblPassword
				GO
				/****** Object:  View [dbo].[View_GridView_1]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_GridView_1]
				AS
				SELECT     dbo.Instrument_RFID.EPC_Nr, dbo.Instrument_RFID.Instrument_LastSeen_Place, dbo.Instrument_RFID.Instrument_LastSeen_Date, 
									  dbo.Instrument_RFID.Instrument_InUse, dbo.Department.Department_Name, 
									  dbo.Instrument_Description.Description_Name + ' ' + dbo.Instrument_Description.D + ' ' + dbo.Instrument_Description.E AS Description_Name, DATEDIFF(day, 
									  dbo.Instrument_RFID.Instrument_LastSeen_Date, GETDATE()) AS Day_To_Now, dbo.Instrument_RFID.Description_ID, dbo.Instrument_RFID.SERIAL_NR
				FROM         dbo.Instrument_Description INNER JOIN
									  dbo.Instrument_RFID ON dbo.Instrument_Description.Description_ID = dbo.Instrument_RFID.Description_ID LEFT OUTER JOIN
									  dbo.Department ON dbo.Instrument_RFID.Department_ID = dbo.Department.Department_ID
				GO
				/****** Object:  View [dbo].[View_Information_Schema]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO

				CREATE VIEW [dbo].[View_Information_Schema]
				AS
				SELECT     INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_NAME, INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_CATALOG, 
									  INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_SCHEMA, sys.objects.modify_date, sys.dm_db_partition_stats.row_count
				FROM         INFORMATION_SCHEMA.KEY_COLUMN_USAGE INNER JOIN
									  sys.objects ON INFORMATION_SCHEMA.KEY_COLUMN_USAGE.TABLE_NAME = sys.objects.name INNER JOIN
									  sys.dm_db_partition_stats ON sys.objects.object_id = sys.dm_db_partition_stats.object_id

				GO
				/****** Object:  View [dbo].[View_Information_Station]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Information_Station]
				AS
				SELECT     TOP (100) PERCENT dbo.Instrument_RFID.Description_ID, dbo.Instrument_Description.Description_Name, dbo.Instrument_RFID_Life.Demand_Service, 
									  dbo.Instrument_RFID_Life.Sent_Service, dbo.Instrument_RFID_Life.Return_Service, dbo.Instrument_RFID_Life.Number_Service, 
									  dbo.Instrument_RFID_Life.Used_In_OR, dbo.Instrument_RFID_Life.Passed_Steri, dbo.Instrument_RFID_Life.DaysInService, 
									  dbo.Instrument_RFID.Instrument_LastSeen_Date, dbo.Instrument_RFID.EPC_Nr
				FROM         dbo.Instrument_RFID INNER JOIN
									  dbo.Instrument_Description ON dbo.Instrument_RFID.Description_ID = dbo.Instrument_Description.Description_ID INNER JOIN
									  dbo.Instrument_RFID_Life ON dbo.Instrument_RFID.EPC_Nr = dbo.Instrument_RFID_Life.EPC_Nr
				GO
				/****** Object:  View [dbo].[View_Instru_To_Tray]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Instru_To_Tray]
				AS
				SELECT        dbo.Instrument_Description.Instrument_Company, dbo.Instrument_Description.Description_Name + N' ' + dbo.Instrument_Description.D + N' ' + dbo.Instrument_Description.E AS Name, 
										 dbo.Instrument_RFID.EPC_Nr, dbo.Tray_Description.Tray_Name, dbo.Tray_Description.Tray_Description, dbo.Tray_Description.Tray_Lock, dbo.Instrument_RFID.Tray_ID, 
										 dbo.Tray_Description.Description_ID
				FROM            dbo.Instrument_RFID INNER JOIN
										 dbo.Instrument_Description ON dbo.Instrument_RFID.Description_ID = dbo.Instrument_Description.Description_ID INNER JOIN
										 dbo.Tray_RFID ON dbo.Instrument_RFID.Tray_ID = dbo.Tray_RFID.Tray_ID INNER JOIN
										 dbo.Tray_Description ON dbo.Tray_RFID.Description_ID = dbo.Tray_Description.Description_ID
				GO
				/****** Object:  View [dbo].[View_Instruments_DISTINCT]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Instruments_DISTINCT]
				AS
				SELECT DISTINCT 
										 dbo.Instrument_Description.Description_ID, dbo.Instrument_Description.Description_Name, dbo.Instrument_Description.D, dbo.Instrument_Description.E, dbo.Instrument_Description.Instrument_Company, 
										 dbo.Instrument_Description.Description_Name + dbo.Instrument_Description.D + dbo.Instrument_Description.E AS FullName
				FROM            dbo.Instrument_RFID INNER JOIN
										 dbo.Instrument_Description ON dbo.Instrument_RFID.Description_ID = dbo.Instrument_Description.Description_ID
				GO
				/****** Object:  View [dbo].[View_Life_GridView]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Life_GridView]
				AS
				SELECT     dbo.Instrument_RFID_Life.EPC_Nr, dbo.Instrument_RFID_Life.Date_Birth, dbo.Instrument_RFID_Life.Date_End, dbo.Instrument_RFID_Life.Used_In_OR, 
									  dbo.Instrument_RFID_Life.Passed_Steri, dbo.Instrument_RFID_Life.Wash_Counter, 
									  dbo.Instrument_Description.Description_Name + dbo.Instrument_Description.D + dbo.Instrument_Description.E AS Full_Name, 
									  dbo.Instrument_RFID_Life.Last_Change, DATEDIFF(day, dbo.Instrument_RFID_Life.Date_Birth, GETDATE()) AS Life_Days, dbo.Instrument_RFID_Life.Steri_In, 
									  dbo.Instrument_RFID_Life.Steri_Out, dbo.Instrument_RFID_Life.Steri_Name, dbo.Instrument_RFID_Life.OR_In, dbo.Instrument_RFID_Life.OR_Out, 
									  dbo.Instrument_RFID_Life.OR_Name
				FROM         dbo.Instrument_RFID_Life INNER JOIN
									  dbo.Instrument_Description ON dbo.Instrument_RFID_Life.Description_ID = dbo.Instrument_Description.Description_ID
				GO
				/****** Object:  View [dbo].[View_Most_Frequent]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Most_Frequent]
				AS
				SELECT        TOP (20) PERCENT Description_Name, COUNT(Description_Name) AS FREQ
				FROM            dbo.Instrument_Description
				GROUP BY Description_Name
				ORDER BY FREQ DESC
				GO
				/****** Object:  View [dbo].[View_Not_InPackList]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Not_InPackList]
				AS
				SELECT     dbo.Instrument_Description.Description_Name, dbo.Instrument_Description.D, dbo.Instrument_Description.E, dbo.Instrument_Description.Description_ID, 
									  dbo.Instrument_Description.Instrument_Company, 
									  dbo.Instrument_Description.Description_Name + dbo.Instrument_Description.D + dbo.Instrument_Description.E AS Full_Name, dbo.Tray_PackList.Number, 
									  dbo.Tray_PackList.Tray_Descrip_ID, dbo.Tray_PackList.Index_ID
				FROM         dbo.Tray_PackList INNER JOIN
									  dbo.Instrument_Description ON dbo.Tray_PackList.Instrument_Descrip_ID = dbo.Instrument_Description.Description_ID
				GO
				/****** Object:  View [dbo].[View_Packed_Time]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Packed_Time]
				AS
				SELECT        dbo.Tray_Description.Tray_Name, dbo.Tray_Description.Tray_Description, dbo.Tray_Description.Tray_Lock, dbo.Tray_Log.Packed_Name, dbo.Tray_Log.Tray_Packed_Place, dbo.Tray_Log.Tray_Packed_Start, 
										 dbo.Tray_Log.Tray_Packed_End, dbo.Tray_Log.Number_Instruments, dbo.Tray_Log.Packed_Locked, DATEDIFF(minute, dbo.Tray_Log.Tray_Packed_Start, dbo.Tray_Log.Tray_Packed_End) AS Minutes, DATEDIFF(day, GETDATE(),
										  dbo.Tray_Log.Tray_Packed_End) AS ToDay
				FROM            dbo.Tray_Log INNER JOIN
										 dbo.Tray_Description ON dbo.Tray_Log.Tray_ID = dbo.Tray_Description.Description_ID
				GO
				/****** Object:  View [dbo].[View_Packed_Trays]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Packed_Trays]
				AS
				SELECT        dbo.Tray_Packed.Tray_EPC_Nr, dbo.Tray_Description.Tray_Name, dbo.Tray_Description.Tray_Description, dbo.Tray_Description.Tray_Lock, dbo.Tray_Packed.EPC_Nr, dbo.Tray_Packed.Packed_Locked, 
										 dbo.Tray_Packed.Pack_User_ID, dbo.Tray_Packed.Pack_Station_ID, dbo.Tray_Packed.Date_Changed, dbo.Reader_Description.Reader_Name, 
										 dbo.Instrument_Description.Description_Name + dbo.Instrument_Description.D + dbo.Instrument_Description.E AS FullName, dbo.TblPassword.UserName, DATEDIFF(day, GETDATE(), dbo.Tray_Packed.Date_Changed) 
										 AS ToDay
				FROM            dbo.Tray_Packed INNER JOIN
										 dbo.Tray_Description ON dbo.Tray_Packed.Tray_Description_ID = dbo.Tray_Description.Description_ID INNER JOIN
										 dbo.TblPassword ON dbo.Tray_Packed.Pack_User_ID = dbo.TblPassword.UserID INNER JOIN
										 dbo.Instrument_Description ON dbo.Tray_Packed.Description_ID = dbo.Instrument_Description.Description_ID LEFT OUTER JOIN
										 dbo.Reader_Description ON dbo.Tray_Packed.Pack_Station_ID = dbo.Reader_Description.Reader_ID
				GO
				/****** Object:  View [dbo].[View_Reader_Log_Error]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Reader_Log_Error]
				AS
				SELECT        TOP (100) PERCENT dbo.Reader_ErrorLog.ErrorLog_ID, dbo.Reader_ErrorLog.Error_Description, dbo.Reader_ErrorLog.ChangeDate, dbo.Area_Name_List.Area_Name, dbo.Reader_Description.Reader_Name, 
										 dbo.Reader_Description.Reader_Description, dbo.Reader_ErrorLog.IP_Address, dbo.Reader_ErrorLog.Reader_ID, dbo.Reader_ErrorLog.Department_ID
				FROM            dbo.Reader_ErrorLog INNER JOIN
										 dbo.Reader_Description ON dbo.Reader_ErrorLog.Reader_ID = dbo.Reader_Description.Reader_ID LEFT OUTER JOIN
										 dbo.Area_Name_List ON dbo.Reader_Description.Area_ID = dbo.Area_Name_List.Area_ID
				GO
				/****** Object:  View [dbo].[View_Reader_Overview]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Reader_Overview]
				AS
				SELECT        dbo.Reader_Description.Reader_Name, dbo.Reader_Description.Reader_Description, dbo.Area_Name_List.Area_Name, dbo.Area_Name_List.Area_Description, dbo.Reader_Description.In_Use, 
										 dbo.Reader_Description.Reader_ID, dbo.Reader_Description.CheckBox_IN, dbo.Reader_Description.Area_ID, dbo.Reader_Description.IP_Address
				FROM            dbo.Reader_Description LEFT OUTER JOIN
										 dbo.Area_Name_List ON dbo.Reader_Description.Area_ID = dbo.Area_Name_List.Area_ID
				GO
				/****** Object:  View [dbo].[View_ReaderList]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_ReaderList]
				AS
				SELECT        TOP (100) PERCENT dbo.Reader_Description.Reader_Description, dbo.Reader_Description.In_Use AS R_In_Use, dbo.Reader_Description.Area_ID, dbo.Antenna_Reader.Antenna_Area_ID, dbo.Reader_Description.Reader_ID, 
										 dbo.Antenna_Reader.Antenna_Name, dbo.Antenna_Reader.Antenna_Type, dbo.Antenna_Reader.Antenna_Location, dbo.Antenna_Reader.In_Use, dbo.Reader_Description.Last_Edited, dbo.Reader_Description.Start_Date, 
										 dbo.Area_Name_List.Area_Name, dbo.Area_Name_List.Area_Description, dbo.Reader_Description.Reader_Name, dbo.Reader_Description.IP_Address
				FROM            dbo.Antenna_Reader INNER JOIN
										 dbo.Reader_Description ON dbo.Antenna_Reader.Reader_ID = dbo.Reader_Description.Reader_ID LEFT OUTER JOIN
										 dbo.Area_Name_List ON dbo.Antenna_Reader.Antenna_Area_ID = dbo.Area_Name_List.Area_ID
				GO
				/****** Object:  View [dbo].[View_Rules_Log_New]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Rules_Log_New]
				AS
				SELECT        dbo.Rules_Log.EPC_Nr, dbo.Instrument_Rules.Rules_ID, dbo.Instrument_Rules.Description_ID, dbo.Instrument_Rules.Default_Rule, dbo.Instrument_Rules.Maintenance_Text, dbo.TblPassword.UserName, 
										 dbo.Rules_Log.Types_Service, dbo.Rules_Log.ServiceVendor_ID, dbo.Rules_Log.ChangeDate, dbo.Instrument_Rules.Maintenance_Value, dbo.Rules_Log.UserID, DATEDIFF(day, dbo.Rules_Log.ChangeDate, GETDATE()) 
										 AS ToDay, dbo.Service_Vendor.Vendor_Name, dbo.Service_Vendor.Vendor_City, dbo.Instrument_RFID.Description_Text, dbo.Rules_Log.Rules_ID AS Expr1
				FROM            dbo.Rules_Log INNER JOIN
										 dbo.Instrument_Rules ON dbo.Rules_Log.Rules_ID = dbo.Instrument_Rules.Rules_ID INNER JOIN
										 dbo.TblPassword ON dbo.Rules_Log.UserID = dbo.TblPassword.UserID INNER JOIN
										 dbo.Service_Vendor ON dbo.Rules_Log.ServiceVendor_ID = dbo.Service_Vendor.ServiceVendor_ID INNER JOIN
										 dbo.Instrument_RFID ON dbo.Rules_Log.EPC_Nr = dbo.Instrument_RFID.EPC_Nr
				GO
				/****** Object:  View [dbo].[View_Rules_Report]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Rules_Report]
				AS
				SELECT        dbo.Instrument_Rules.Rules_ID, dbo.Instrument_Rules.Description_ID, dbo.Instrument_Rules.Default_Rule, dbo.Instrument_Rules.Maintenance_Text, dbo.Instrument_Rules.Maintenance_Value, 
										 dbo.Instrument_Rules.Maintenance_Periods, dbo.Instrument_Rules.Maintenance_Period_Start, dbo.Instrument_Rules.Maintenance_Alarm, dbo.Instrument_Rules.Deleted, 
										 dbo.Instrument_Maintenance_RFID.Maintenance_RFID_ID, dbo.Instrument_Maintenance_RFID.EPC_Nr, dbo.Instrument_Maintenance_RFID.Check_Ciffer, dbo.Instrument_Maintenance_RFID.Check_Status, 
										 dbo.Instrument_Maintenance_RFID.Sendt_To_Service, dbo.Instrument_Maintenance_RFID.Return_From_Service, dbo.Instrument_Maintenance_RFID.ServiceVendor_ID, dbo.Instrument_Maintenance_RFID.Service_Counter, 
										 dbo.Instrument_Maintenance_RFID.Service_Date, dbo.Instrument_RFID_Life.Demand_Service, dbo.Service_Vendor.Vendor_Name, dbo.Service_Vendor.Vendor_City
				FROM            dbo.Instrument_RFID_Life INNER JOIN
										 dbo.Instrument_Maintenance_RFID ON dbo.Instrument_RFID_Life.EPC_Nr = dbo.Instrument_Maintenance_RFID.EPC_Nr INNER JOIN
										 dbo.Service_Vendor ON dbo.Instrument_RFID_Life.ServiceVendor_ID = dbo.Service_Vendor.ServiceVendor_ID INNER JOIN
										 dbo.Instrument_Rules ON dbo.Instrument_Maintenance_RFID.Rules_ID = dbo.Instrument_Rules.Rules_ID
				GO
				/****** Object:  View [dbo].[View_Rules_Station]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Rules_Station]
				AS
				SELECT        TOP (100) PERCENT dbo.Instrument_Maintenance_RFID.EPC_Nr, dbo.Instrument_RFID.Description_ID, dbo.Instrument_Rules.Maintenance_Text, dbo.Instrument_Rules.Maintenance_Value, 
										 dbo.Instrument_Rules.Maintenance_Periods, dbo.Instrument_Rules.Default_Rule, dbo.Instrument_Maintenance_RFID.Check_Ciffer, dbo.Instrument_Maintenance_RFID.Check_Status, 
										 dbo.Instrument_RFID.Instrument_LastSeen_Date, dbo.Instrument_Maintenance_RFID.Maintenance_RFID_ID, dbo.Instrument_Description.Description_Name, dbo.Instrument_Maintenance_RFID.Sendt_To_Service, 
										 dbo.Instrument_Maintenance_RFID.Service_Counter, dbo.Instrument_Maintenance_RFID.Return_From_Service, dbo.Instrument_Maintenance_RFID.Service_Date, DATEDIFF(day, GETDATE(), 
										 dbo.Instrument_Maintenance_RFID.Service_Date) AS Service_Diff, dbo.Instrument_RFID_Life.Demand_Service, dbo.Instrument_Maintenance_RFID.Rules_ID
				FROM            dbo.Instrument_RFID INNER JOIN
										 dbo.Instrument_Description ON dbo.Instrument_RFID.Description_ID = dbo.Instrument_Description.Description_ID INNER JOIN
										 dbo.Instrument_Maintenance_RFID ON dbo.Instrument_RFID.EPC_Nr = dbo.Instrument_Maintenance_RFID.EPC_Nr INNER JOIN
										 dbo.Instrument_RFID_Life ON dbo.Instrument_Maintenance_RFID.EPC_Nr = dbo.Instrument_RFID_Life.EPC_Nr INNER JOIN
										 dbo.Instrument_Rules ON dbo.Instrument_Maintenance_RFID.Description_ID = dbo.Instrument_Rules.Description_ID
				GO
				/****** Object:  View [dbo].[View_Rules_Status]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Rules_Status]
				AS
				SELECT        dbo.Instrument_Maintenance_RFID.Maintenance_RFID_ID, dbo.Instrument_Maintenance_RFID.EPC_Nr, dbo.Instrument_Maintenance_RFID.Check_Ciffer, dbo.Instrument_Maintenance_RFID.Reset_Check_Ciffer, 
										 dbo.Instrument_Maintenance_RFID.Check_Status, dbo.Instrument_Maintenance_RFID.Sendt_To_Service, dbo.Instrument_Maintenance_RFID.Return_From_Service, dbo.Instrument_Maintenance_RFID.Service_Counter, 
										 dbo.Instrument_Maintenance_RFID.Service_Date, dbo.Instrument_Maintenance_RFID.Maintenance_Period_Start, dbo.Instrument_Maintenance_RFID.ServiceVendor_ID, dbo.Instrument_Maintenance_RFID.Description_ID, 
										 dbo.Instrument_RFID_Life.Demand_Service, dbo.Instrument_Rules.Maintenance_Text, dbo.Instrument_Rules.Maintenance_Value, dbo.Instrument_Rules.Maintenance_Periods, 
										 dbo.Instrument_Maintenance_RFID.Rules_ID
				FROM            dbo.Instrument_Maintenance_RFID INNER JOIN
										 dbo.Instrument_RFID_Life ON dbo.Instrument_Maintenance_RFID.EPC_Nr = dbo.Instrument_RFID_Life.EPC_Nr INNER JOIN
										 dbo.Instrument_Rules ON dbo.Instrument_Maintenance_RFID.Rules_ID = dbo.Instrument_Rules.Rules_ID
				GO
				/****** Object:  View [dbo].[View_Schemas]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Schemas]
				AS
				SELECT        SCHEMA_NAME(schema_id) AS [schema], name
				FROM            sys.procedures
				GO
				/****** Object:  View [dbo].[View_Service_GridView]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Service_GridView]
				AS
				SELECT     dbo.Instrument_RFID_Life.EPC_Nr, dbo.Instrument_RFID_Life.Date_Birth, dbo.Instrument_RFID_Life.Date_End, dbo.Instrument_RFID_Life.Sent_Service, 
									  dbo.Instrument_RFID_Life.Return_Service, dbo.Instrument_RFID_Life.Number_Service, dbo.Instrument_RFID_Life.Last_Change, 
									  dbo.Instrument_Description.Description_Name + dbo.Instrument_Description.D + dbo.Instrument_Description.E AS Full_Name, DATEDIFF(day, 
									  dbo.Instrument_RFID_Life.Sent_Service, dbo.Instrument_RFID_Life.Return_Service) AS Service_Days, dbo.Instrument_RFID_Life.DaysInService, 
									  dbo.Instrument_RFID_Life.Passed_Steri, dbo.Instrument_RFID_Life.Used_In_OR
				FROM         dbo.Instrument_RFID_Life INNER JOIN
									  dbo.Instrument_Description ON dbo.Instrument_RFID_Life.Description_ID = dbo.Instrument_Description.Description_ID
				GO
				/****** Object:  View [dbo].[View_Service_Log]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Service_Log]
				AS
				SELECT        dbo.TblPassword.UserName, dbo.Instrument_RFID.Description_Text, dbo.Service_Log.ChangeDate, dbo.Service_Log.ServiceVendor_ID, dbo.Service_Vendor.Vendor_Name, dbo.Service_Log.EPC_Nr, 
										 dbo.Service_Vendor.Vendor_City, dbo.Instrument_Rules.Maintenance_Text, dbo.Instrument_Rules.Maintenance_Value, dbo.Instrument_Rules.Maintenance_Periods, dbo.Instrument_Rules.Maintenance_Period_Start
				FROM            dbo.Service_Log INNER JOIN
										 dbo.TblPassword ON dbo.Service_Log.UserID = dbo.TblPassword.UserID INNER JOIN
										 dbo.Instrument_RFID ON dbo.Service_Log.EPC_Nr = dbo.Instrument_RFID.EPC_Nr INNER JOIN
										 dbo.Instrument_Rules ON dbo.Service_Log.Rules_ID = dbo.Instrument_Rules.Rules_ID LEFT OUTER JOIN
										 dbo.Service_Vendor ON dbo.Service_Log.ServiceVendor_ID = dbo.Service_Vendor.ServiceVendor_ID
				GO

				/****** Object:  View [dbo].[View_TotalInstruments]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_TotalInstruments]
				AS
				SELECT        dbo.Instrument_RFID.EPC_Nr, dbo.Instrument_Description.Description_Name, dbo.Instrument_Description.D, dbo.Instrument_Description.E, dbo.Instrument_Description.Instrument_Company, 
										 dbo.Instrument_RFID.Instrument_LastSeen_Place, dbo.Instrument_RFID.Instrument_LastSeen_Date, dbo.Instrument_RFID.Instrument_InUse, dbo.Department.Department_Name, dbo.Instrument_RFID.SERIAL_NR
				FROM            dbo.Instrument_RFID INNER JOIN
										 dbo.Instrument_Description ON dbo.Instrument_RFID.Description_ID = dbo.Instrument_Description.Description_ID LEFT OUTER JOIN
										 dbo.Department ON dbo.Instrument_RFID.Department_ID = dbo.Department.Department_ID
				GO
				/****** Object:  View [dbo].[View_Tray_EPC_Description]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Tray_EPC_Description]
				AS
				SELECT        dbo.Tray_RFID.EPC_Nr, dbo.Tray_Description.Tray_Name, dbo.Tray_Description.Tray_Description, dbo.Tray_RFID.Description_ID
				FROM            dbo.Tray_Description INNER JOIN
										 dbo.Tray_RFID ON dbo.Tray_Description.Description_ID = dbo.Tray_RFID.Description_ID
				GO
				/****** Object:  View [dbo].[View_Tray_Life_GridView]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Tray_Life_GridView]
				AS
				SELECT     DATEDIFF(day, dbo.Tray_RFID_Life.Date_Birth, GETDATE()) AS Life_Days, dbo.Tray_Description.Tray_Description AS Full_Name, dbo.Tray_RFID_Life.EPC_Nr, 
									  dbo.Tray_RFID.Tray_ID, dbo.Tray_RFID.Description_ID, dbo.Tray_RFID.Tray_Contents, dbo.Tray_RFID.Tray_LastSeen_Place, dbo.Tray_RFID.Tray_LastSeen_Date, 
									  dbo.Tray_RFID.Date_Changed, dbo.Tray_Description.Tray_Name, dbo.Tray_Description.Tray_Description, dbo.Tray_RFID_Life.Date_Birth, 
									  dbo.Tray_RFID_Life.Date_End, dbo.Tray_RFID_Life.Return_Service, dbo.Tray_RFID_Life.Last_Service, dbo.Tray_RFID_Life.Number_Service, 
									  dbo.Tray_RFID_Life.Wash_Counter, dbo.Tray_RFID_Life.Steri_In, dbo.Tray_RFID_Life.Steri_Out, dbo.Tray_RFID_Life.Steri_Name, dbo.Tray_RFID_Life.OR_In, 
									  dbo.Tray_RFID_Life.OR_Out, dbo.Tray_RFID_Life.OR_Name, dbo.Tray_RFID_Life.Used_In_OR, dbo.Tray_RFID_Life.Passed_Steri, 
									  dbo.Tray_RFID_Life.Description_ID AS Expr1, dbo.Tray_RFID_Life.Last_Change
				FROM         dbo.Tray_RFID INNER JOIN
									  dbo.Tray_Description ON dbo.Tray_RFID.Description_ID = dbo.Tray_Description.Description_ID INNER JOIN
									  dbo.Tray_RFID_Life ON dbo.Tray_RFID.EPC_Nr = dbo.Tray_RFID_Life.EPC_Nr
				GO
				/****** Object:  View [dbo].[View_Tray_PackList]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Tray_PackList]
				AS
				SELECT        dbo.Tray_Description.Tray_Description, dbo.Tray_Description.Tray_Name, dbo.Tray_PackList.Tray_Descrip_ID, dbo.Tray_PackList.Number, dbo.Instrument_Description.Description_Name, 
										 dbo.Instrument_Description.D, dbo.Instrument_Description.E, dbo.Instrument_Description.Description_ID, dbo.Instrument_Description.Instrument_Company, 
										 dbo.Instrument_Description.Description_Name + N' ' + dbo.Instrument_Description.D + N' ' + dbo.Instrument_Description.E AS Full_Name, dbo.Tray_PackList.Index_ID
				FROM            dbo.Tray_PackList LEFT OUTER JOIN
										 dbo.Tray_Description ON dbo.Tray_PackList.Tray_Descrip_ID = dbo.Tray_Description.Description_ID LEFT OUTER JOIN
										 dbo.Instrument_Description ON dbo.Tray_PackList.Instrument_Descrip_ID = dbo.Instrument_Description.Description_ID
				WHERE        (NOT (dbo.Instrument_Description.Description_Name IS NULL))
				GO
				/****** Object:  View [dbo].[View_Trays_ALL_Report]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Trays_ALL_Report]
				AS
				SELECT        dbo.Tray_RFID.EPC_Nr, dbo.Tray_Description.Tray_Name, dbo.Tray_RFID.Tray_LastSeen_Place, dbo.Tray_RFID.Tray_LastSeen_Date, dbo.Tray_Description.Tray_Description, dbo.Tray_Description.Tray_Lock, 
										 dbo.Tray_Description.Date_Changed, dbo.Tray_RFID.Description_ID
				FROM            dbo.Tray_RFID INNER JOIN
										 dbo.Tray_Description ON dbo.Tray_RFID.Description_ID = dbo.Tray_Description.Description_ID
				GO
				/****** Object:  View [dbo].[View_Trays_In_Database]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Trays_In_Database]
				AS
				SELECT        dbo.Tray_PackList.Tray_Descrip_ID, dbo.Tray_PackList.Number, dbo.Tray_PackList.Date_Changed, dbo.Tray_PackList.Instrument_Descrip_ID, dbo.Tray_Description.Tray_Name, dbo.Tray_RFID.EPC_Nr, 
										 dbo.Instrument_Description.Description_Name, dbo.Tray_Description.Tray_Description, dbo.Tray_Description.Tray_Lock, dbo.Tray_RFID.Tray_Contents, dbo.Tray_RFID.Tray_LastSeen_Place, 
										 dbo.Tray_RFID.Tray_LastSeen_Date, DATEDIFF(day, dbo.Tray_RFID.Tray_LastSeen_Date, GETDATE()) AS Days, 
										 dbo.Instrument_Description.Description_Name + dbo.Instrument_Description.D + dbo.Instrument_Description.E AS Full_Name, dbo.Tray_RFID.Special_Text
				FROM            dbo.Tray_PackList INNER JOIN
										 dbo.Tray_Description ON dbo.Tray_PackList.Tray_Descrip_ID = dbo.Tray_Description.Description_ID INNER JOIN
										 dbo.Instrument_Description ON dbo.Tray_PackList.Instrument_Descrip_ID = dbo.Instrument_Description.Description_ID LEFT OUTER JOIN
										 dbo.Tray_RFID ON dbo.Tray_PackList.Tray_Descrip_ID = dbo.Tray_RFID.Tray_ID
				GO
				/****** Object:  View [dbo].[View_Treatment_Detail]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Treatment_Detail]
				AS
				SELECT        dbo.Instrument_RFID.EPC_Nr, dbo.Treatment_Detail.Detail_ID, dbo.Treatment_Detail.The_Order, dbo.Treatment_Detail.Detail_Text, dbo.Treatment_Detail.Change_Date, dbo.Treatment_Description.Treatment_Description, 
										 dbo.Instrument_RFID.Description_Text, dbo.Instrument_Description.Treatment_ID, dbo.Instrument_Description.Description_ID, dbo.Treatment_Detail.Treatment_Type, dbo.Treatment_Type.Description_Type
				FROM            dbo.Instrument_Description INNER JOIN
										 dbo.Instrument_RFID ON dbo.Instrument_Description.Description_ID = dbo.Instrument_RFID.Description_ID INNER JOIN
										 dbo.Treatment_Detail INNER JOIN
										 dbo.Treatment_Description ON dbo.Treatment_Detail.Treatment_ID = dbo.Treatment_Description.Treatment_ID ON dbo.Instrument_Description.Treatment_ID = dbo.Treatment_Description.Treatment_ID LEFT OUTER JOIN
										 dbo.Treatment_Type ON dbo.Treatment_Detail.Treatment_Type = dbo.Treatment_Type.Index_ID
				GO
				/****** Object:  View [dbo].[View_Treatment_Detail_Report]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				CREATE VIEW [dbo].[View_Treatment_Detail_Report]
				AS
				SELECT        dbo.Treatment_Detail.Detail_ID, dbo.Treatment_Detail.Treatment_ID, dbo.Treatment_Detail.The_Order, dbo.Treatment_Detail.Detail_Text, dbo.Treatment_Description.Treatment_Description, 
										 dbo.Instrument_Description.Description_ID + N' :  ' + dbo.Instrument_Description.Description_Name + N' ' + dbo.Instrument_Description.D + N' ' + dbo.Instrument_Description.E AS Full_Name, 
										 dbo.Instrument_Description.Description_ID
				FROM            dbo.Treatment_Description INNER JOIN
										 dbo.Treatment_Detail ON dbo.Treatment_Description.Treatment_ID = dbo.Treatment_Detail.Treatment_ID LEFT OUTER JOIN
										 dbo.Instrument_Description ON dbo.Treatment_Detail.Treatment_ID = dbo.Instrument_Description.Treatment_ID
			");
        }

        private void DropViews()
        {
	        DropView("dbo.View_Treatment_Detail_Report");
	        DropView("dbo.View_Treatment_Detail");
	        DropView("dbo.View_Tray_PackList");
	        DropView("dbo.View_Tray_Life_GridView");
	        DropView("dbo.View_TotalInstruments");
	        DropView("dbo.View_Service_GridView");
	        DropView("dbo.View_Schemas");
	        DropView("dbo.View_Rules_Status");
	        DropView("dbo.View_Rules_Station");
	        DropView("dbo.View_Rules_Report");
	        DropView("dbo.View_Rules_Log_New");
	        DropView("dbo.View_ReaderList");
	        DropView("dbo.View_Reader_Overview");
	        DropView("dbo.View_Reader_Log_Error");
	        DropView("dbo.View_Packed_Trays");
	        DropView("dbo.View_Not_InPackList");
	        DropView("dbo.View_Life_GridView");
	        DropView("dbo.View_Instruments_DISTINCT");
	        DropView("dbo.View_Instru_To_Tray");
	        DropView("dbo.View_Information_Station");
	        DropView("dbo.View_Information_Schema");
	        DropView("dbo.View_GridView_1");
	        DropView("dbo.View_Full_UserName");
	        DropView("dbo.View_EPC_To_Tray");
	        DropView("dbo.View_EPC_DescriptionName_Org");
	        DropView("dbo.View_EPC_DescriptionName_New");
	        DropView("dbo.View_CostCenter");
	        DropView("dbo.View_Combine");
	        DropView("dbo.View_Carts_In_Database");
	        DropView("dbo.View_AllInstruments");
	        DropView("dbo.View_Trays_In_Database");
	        DropView("dbo.View_Trays_ALL_Report");
	        DropView("dbo.View_Tray_EPC_Description");
	        DropView("dbo.View_Service_Log");
	        DropView("dbo.View_Packed_Time");
	        DropView("dbo.View_Most_Frequent");
	        DropView("dbo.View_Containers_In_Database");
        }
    }
}

