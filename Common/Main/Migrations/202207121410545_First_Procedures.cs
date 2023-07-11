namespace Caretag_Class.Migrations
{
	using Caretag_Class.Migrations.Base;
	
    public partial class First : DbMigrationBase
    {
        private void CreateProcedures()
        {
            Sql(@"
				/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[ChangePassword] 
					-- Add the parameters for the stored procedure here
					@UserName NVARCHAR(50),
					@PassCode NVARCHAR(MAX) 
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					UPDATE dbo.TblPassword SET PassCode=@PassCode, LastLogin=GETDATE() WHERE UserName=@UserName COLLATE Latin1_General_CS_AI
			
					SELECT SecurityLevel FROM dbo.TblPassword WHERE UserName=@username COLLATE Latin1_General_CS_AI
					RETURN @@ROWCOUNT
				END
				GO
				/****** Object:  StoredProcedure [dbo].[ChangeSecurity]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[ChangeSecurity] 
					-- Add the parameters for the stored procedure here
					@UserName NVARCHAR(50),
					@ChangeBy NVARCHAR(50),
					@Security int = 0 
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					UPDATE dbo.TblPassword SET SecurityLevel=@Security, ChangedBy=@ChangeBy WHERE UserName=@UserName COLLATE Latin1_General_CS_AI
			
					SELECT SecurityLevel FROM dbo.TblPassword WHERE UserName=@username COLLATE Latin1_General_CS_AI
					RETURN @@ROWCOUNT

				END
				GO
				/****** Object:  StoredProcedure [dbo].[CheckSecurity]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[CheckSecurity] 
					-- Add the parameters for the stored procedure here
					@UserName NVARCHAR(50),
					@Security int = 0 
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					SELECT SecurityLevel FROM dbo.TblPassword WHERE UserName=@username COLLATE Latin1_General_CS_AI
					RETURN @@ROWCOUNT
				END
				GO
				/****** Object:  StoredProcedure [dbo].[CheckUser]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		<Author,,Name>
				-- Create date: <Create Date,,>
				-- Description:	<Description,,>
				-- =============================================
				CREATE PROCEDURE [dbo].[CheckUser]
					-- Add the parameters for the stored procedure here
					@username AS NVARCHAR(50), 
					@password AS NVARCHAR(MAX)
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					SELECT PassCode FROM dbo.TblPassword WHERE UserName=@username COLLATE Latin1_General_CS_AI
					RETURN @@ROWCOUNT
				END
				GO
				/****** Object:  StoredProcedure [dbo].[Create_New_Rule]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[Create_New_Rule] 
					-- Add the parameters for the stored procedure here
					@Descrip_ID NVARCHAR(255),
					@Maint_Text NVARCHAR(MAX),
					@Maint_Value INT,
					@Maint_Periods INT
		    
		    
				AS
					BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
						SET NOCOUNT ON;
						DECLARE @id AS BIGINT = 0;

					-- Insert statements for procedure here
						INSERT  dbo.Instrument_Maintenance_Rules
								( Description_ID ,
								  Maintenance_Text ,
								  Maintenance_Value ,
								  Maintenance_Periods ,
								  Maintenance_Period_Start ,
								  Maintenance_Alarm
								)
						VALUES  ( @Descrip_ID , -- Description_ID - nvarchar(255)
								  @Maint_Text , -- Maintenance_Text - nvarchar(max)
								  @Maint_Value , -- Maintenance_Value - smallint
								  @Maint_Periods , -- Maintenance_Periods - smallint
								  NULL , -- Maintenance_Period_Start - datetime
								  1  -- Maintenance_Alarm - bit
								);
			        
						SELECT   SCOPE_IDENTITY();
						--RETURN @id
					END;
				GO
				/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[CreateUser] 
					-- Add the parameters for the stored procedure here
					@FirstName NVARCHAR(50),
					@FamName NVARCHAR(50),
					@UserName NVARCHAR(50),
					@ChangedBy NVARCHAR(50), 
					@SecurityLevel int = 0,
					@UserGuid UNIQUEIDENTIFIER
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					INSERT dbo.TblPassword
							( UserName ,
							  FirstName,
							  FamilyName,
							  PassCode ,
							  UserGuid,
							  LastLogin ,
							  NumberLogins ,
							  WindowsUser ,
							  DashBoard ,
							  DashBoardAdmin ,
							  SecurityLevel ,
							  ChangedBy ,
							  ChangeDate
							)
					VALUES  ( @UserName , -- UserName - nvarchar(50)
							  @FirstName,
							  @FamName,
							  N'' , -- PassCode - nvarchar(max)
							  @UserGuid, -- Unique Identifier part of SALT
							  NULL , -- LastLogin - datetime
							  -1 , -- NumberLogins - int
							  N'' , -- WindowsUser - nvarchar(50)
							  1 , -- DashBoard - bit
							  0 , -- DashBoardAdmin - bit
							  @SecurityLevel , -- SecurityLevel - smallint
							  @ChangedBy , -- ChangedBy - nvarchar(50)
							  GETDATE()  -- ChangeDate - datetime
							)
			        
							SELECT dbo.TblPassword.UserID FROM dbo.TblPassword WHERE UserName=@UserName COLLATE Latin1_General_CS_AI
							RETURN @@ROWCOUNT
				END
				GO
				/****** Object:  StoredProcedure [dbo].[CreateUser_RFID]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[CreateUser_RFID] 
					-- Add the parameters for the stored procedure here
					@FirstName NVARCHAR(50),
					@FamName NVARCHAR(50),
					@RFIDCode NVARCHAR(MAX),
					@SEQCode NVARCHAR(MAX),
					@UserName NVARCHAR(50),
					@ChangedBy NVARCHAR(50), 
					@SecurityLevel int = 0
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					INSERT dbo.TblPassword
							( UserName ,
							  FirstName,
							  FamilyName,
							  PassCode ,
							  LastLogin ,
   							  NumberLogins ,
							  RFID_Code,
							  SEQ_Code,
							  WindowsUser ,
							  DashBoard ,
							  DashBoardAdmin ,
							  SecurityLevel ,
							  ChangedBy ,
							  ChangeDate
							)
					VALUES  ( @UserName , -- UserName - nvarchar(50)
							  @FirstName,
							  @FamName,
							  N'' , -- PassCode - nvarchar(max)
							  NULL , -- LastLogin - datetime
							  -1 , -- NumberLogins - int
							  @RFIDCode,
							  @SEQCode,
							  N'' , -- WindowsUser - nvarchar(50)
							  1 , -- DashBoard - bit
							  0 , -- DashBoardAdmin - bit
							  @SecurityLevel , -- SecurityLevel - smallint
							  @ChangedBy , -- ChangedBy - nvarchar(50)
							  GETDATE()  -- ChangeDate - datetime
							)
			        
							SELECT dbo.TblPassword.UserID FROM dbo.TblPassword WHERE UserName=@UserName COLLATE Latin1_General_CS_AI
							RETURN @@ROWCOUNT
					END
			        
				GO
				/****** Object:  StoredProcedure [dbo].[Delete_RFID_Rules]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[Delete_RFID_Rules] 
					-- Add the parameters for the stored procedure here
					@Descrip_ID NVARCHAR(255), 
					@Maint_ID int = 0
			
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					DELETE  dbo.Instrument_Maintenance_RFID
					FROM Instrument_Maintenance_RFID
					WHERE     (Maintenance_RFID_ID = @Maint_ID) AND (Description_ID = @Descrip_ID)
				END
				GO
				/****** Object:  StoredProcedure [dbo].[Delete_Unique_Rule]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[Delete_Unique_Rule] 
					-- Add the parameters for the stored procedure here
					@Maint_ID BIGINT
			
			
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					DELETE  dbo.Instrument_Special_Rules
					FROM Instrument_Special_Rules
					WHERE     (Maintenance_ID = @Maint_ID);
				END
				GO
				/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[DeleteUser] 
					-- Add the parameters for the stored procedure here
					@UserName NVARCHAR(50)AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					DELETE	dbo.TblPassword  WHERE UserName=@UserName COLLATE Latin1_General_CS_AI
			
					SELECT dbo.TblPassword.UserID FROM dbo.TblPassword WHERE UserName=@UserName COLLATE Latin1_General_CS_AI
					RETURN @@ROWCOUNT
				END
				GO
				/****** Object:  StoredProcedure [dbo].[DoLogin]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[DoLogin] 
					-- Add the parameters for the stored procedure here
					@username AS NVARCHAR(50) 
			
			
			
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;
					DECLARE @NumLogins AS INT

					SET @NumLogins =(SELECT NumberLogins FROM dbo.TblPassword WHERE UserName=@username COLLATE Latin1_General_CS_AI)
					SET @NumLogins=@NumLogins +1
					UPDATE dbo.TblPassword SET NumberLogins=@NumLogins, LastLogin=GETDATE() WHERE UserName=@UserName
					SELECT UserID FROM dbo.TblPassword WHERE UserName=@username COLLATE Latin1_General_CS_AI
					RETURN @@ROWCOUNT
				END
				GO
				/****** Object:  StoredProcedure [dbo].[Find_Max_EPC]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		<Bilsoe>
				-- Create date: <Create Date,,>
				-- Description:	<Description,,>
				-- =============================================
				CREATE PROCEDURE [dbo].[Find_Max_EPC]
					-- Add the parameters for the stored procedure here
					@Owner_Serie NVARCHAR(50),
					@EPC_Length int = 24
					--@test int OUTPUT
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					DECLARE @test AS int =2

					-- Insert statements for procedure here
					SELECT     @test = MAX(CAST(SUBSTRING([EPC_Nr], @EPC_Length -7, 8) AS INT))
					FROM       Instrument_RFID
					WHERE     (EPC_Nr LIKE '5701%')
					--	WHERE     (EPC_Nr LIKE  @Owner_Serie)

					SET @test = @test + 1
					RETURN  @test
				END
				GO
				/****** Object:  StoredProcedure [dbo].[Get_EPC_Add_One]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: Sep 2019
				-- Description:	Retrieve EPC and add one securily
				-- =============================================
				CREATE PROCEDURE [dbo].[Get_EPC_Add_One] 
					-- Add the parameters for the stored procedure here

				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					DECLARE @Old_EPC AS int =0;
					DECLARE @New_EPC AS int =0

					-- Insert statements for procedure here

					SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
					BEGIN TRANSACTION;

					SELECT @Old_EPC = New_EPC FROM dbo.EPC_Number_Serie

					SET @New_EPC = @Old_EPC + 1

					UPDATE dbo.EPC_Number_Serie 
					SET		New_EPC=@New_EPC,
							Last_Used_EPC=@Old_EPC
					WHERE   Owner_Ship IS NOT NULL;

					COMMIT TRANSACTION;
					RETURN  @New_EPC

				END;
				GO
				/****** Object:  StoredProcedure [dbo].[InportCSVData]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		<Author,,Name>
				-- Create date: <Create Date,,>
				-- Description:	<Description,,>
				-- =============================================
				CREATE PROCEDURE [dbo].[InportCSVData] 
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
				  exec  sp_configure 'show advanced options',1;
				RECONFIGURE with override;
				exec sp_configure 'Ad Hoc Distributed Queries', 1
				RECONFIGURE;END
				GO
				/****** Object:  StoredProcedure [dbo].[Insert_RFID_Rules]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[Insert_RFID_Rules] 
					-- Add the parameters for the stored procedure here
					@Descrip_ID NVARCHAR(255),
					@Maint_ID BIGINT,
					@Serv_Date datetime
		    
				AS
					BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
						SET NOCOUNT ON;

						INSERT  INTO dbo.Instrument_Maintenance_RFID
								( EPC_Nr ,
								  Description_ID,
								  Rules_ID,
								  Service_Date
								)
								SELECT  EPC_Nr ,
										Description_ID,
										@Maint_ID,
										@Serv_Date
								FROM    dbo.Instrument_RFID
								WHERE   Description_ID = @Descrip_ID;
					END;
				GO
				/****** Object:  StoredProcedure [dbo].[Insert_Tray_Department]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: <Create Date,,>
				-- Description:	<Description,,>
				-- =============================================
				CREATE PROCEDURE [dbo].[Insert_Tray_Department]
					-- Add the parameters for the stored procedure here
					@pTray_Name NVARCHAR(50),
					@pDescrip_Text NVARCHAR(MAX), 
					@pTray_Locked int = 0,
					@pDepartment int =0

				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					INSERT INTO dbo.Tray_Description
							( Tray_Name ,
							  Tray_Description ,
							  Tray_Lock,
							  Cost_ID
							)
					VALUES  ( @pTray_Name , -- Tray_Name - nvarchar(50)
							  @pDescrip_Text , -- Tray_Description - nvarchar(max)
							  @pTray_Locked,  -- Tray_Lock - bit
							  @pDepartment 
							);

					SELECT  SCOPE_IDENTITY();

				END
				GO
				/****** Object:  StoredProcedure [dbo].[Insert_Tray_Description]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[Insert_Tray_Description] 
					-- Add the parameters for the stored procedure here
					@pTray_Name NVARCHAR(50),
					@pDescrip_Text NVARCHAR(MAX), 
					@pTray_Locked int = 0
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					INSERT INTO dbo.Tray_Description
							( Tray_Name ,
							  Tray_Description ,
							  Tray_Lock 
							)
					VALUES  ( @pTray_Name , -- Tray_Name - nvarchar(50)
							  @pDescrip_Text , -- Tray_Description - nvarchar(max)
							  @pTray_Locked  -- Tray_Lock - bit
							);

					SELECT  SCOPE_IDENTITY();

				END
				GO
				/****** Object:  StoredProcedure [dbo].[Insert_Unique_Rules]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[Insert_Unique_Rules] 
					-- Add the parameters for the stored procedure here
					@Descrip_ID NVARCHAR(255) ,
					@Maint_Text NVARCHAR(MAX) ,
					@Maint_Value INT ,
					@Maint_Periods INT ,
					@Maint_Period_Start DATETIME
				AS
					BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
						SET NOCOUNT ON;

						INSERT  INTO dbo.Instrument_Special_Rules
								( Description_ID ,
								  Maintenance_Text ,
								  Maintenance_Value ,
								  Maintenance_Periods ,
								  Maintenance_Period_Start ,
								  Maintenance_Alarm
								)
						VALUES  ( @Descrip_ID , -- Description_ID - nvarchar(255)
								  @Maint_Text , -- Maintenance_Text - nvarchar(max)
								  @Maint_Value , -- Maintenance_Value - smallint
								  @Maint_Periods , -- Maintenance_Periods - smallint
								  @Maint_Period_Start , -- Maintenance_Period_Start - datetime
								  1  -- Maintenance_Alarm - bit
								);
		                
						SELECT  SCOPE_IDENTITY();

					END;
				GO
				/****** Object:  StoredProcedure [dbo].[LockOut_User]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[LockOut_User] 
					-- Add the parameters for the stored procedure here
					@UserName NVARCHAR(50)

				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					DELETE	dbo.TblPassword  WHERE UserName=@UserName COLLATE Latin1_General_CS_AI
			
					SELECT dbo.TblPassword.UserID FROM dbo.TblPassword WHERE	UserName=@UserName COLLATE Latin1_General_CS_AI
					RETURN @@ROWCOUNT
			
				END
				GO
				/****** Object:  StoredProcedure [dbo].[Main_PassWord]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 2016 feb
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[Main_PassWord]
					-- Add the parameters for the stored procedure here
					@PassCode NVARCHAR(MAX) 

				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					UPDATE dbo.systeminfo SET AdgangsKode=@PassCode COLLATE Latin1_General_CS_AI
			
				END
				GO
				/****** Object:  StoredProcedure [dbo].[ResetUser]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[ResetUser] 
					-- Add the parameters for the stored procedure here
					@UserName NVARCHAR(50),
					@NumLogins int 
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					UPDATE dbo.TblPassword SET PassCode=N'' WHERE UserName=@UserName COLLATE Latin1_General_CS_AI
				END
				GO
				/****** Object:  StoredProcedure [dbo].[Strip_Char_Table]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				-- Author:		Bilsoe
				-- Create date: 2018
				-- Description:	
				-- =============================================
				CREATE PROCEDURE [dbo].[Strip_Char_Table] 
					-- Add the parameters for the stored procedure here
					@p1 int = 0, 
					@p2 int = 0
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

					-- Insert statements for procedure here
					UPDATE Instrument_Description
					SET Description_Name = REPLACE(Description_Name, '""', '')

				END
				GO
				/****** Object:  StoredProcedure [dbo].[Strip_Space_Table]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO

				-- =============================================
				--Author:		Bilsoe
				-- Create date: 2018
				-- Description:
				-- =============================================
				CREATE PROCEDURE[dbo].[Strip_Space_Table]
					-- Add the parameters for the stored procedure here
					@p1 int = 0,
					@p2 int = 0
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;

							--Insert statements for procedure here
			   
						   UPDATE Instrument_Vendor
			   
						   SET Vendor_Abbreviation = RTRIM(Vendor_Abbreviation)
			   

					   END
					   GO
					   /****** Object:  StoredProcedure [dbo].[TEST]    Script Date: 27-04-2022 11:32:55 ******/
					   SET ANSI_NULLS ON
					   GO
					   SET QUOTED_IDENTIFIER ON
					   GO
					   -- =============================================
					   --Author:		Bilsoe
					   -- Create date: 
				--Description:	
				-- =============================================
					   CREATE PROCEDURE[dbo].[TEST]
						   -- Add the parameters for the stored procedure here
			   

					   AS
					   BEGIN
						   -- SET NOCOUNT ON added to prevent extra result sets from
						   -- interfering with SELECT statements.
			   
						   SET NOCOUNT ON;
							/* GRANT EXECUTE TO THE ROLE */
							GRANT EXECUTE TO db_datareader




					--Insert statements for procedure here

				   SELECT * FROM TblPassword
				END
				GO
				/****** Object:  StoredProcedure [dbo].[Update_Tray_Description]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				--Author:		Bilsoe
				-- Create date: 
				--Description:	
				-- =============================================
				CREATE PROCEDURE[dbo].[Update_Tray_Description]
				   -- Add the parameters for the stored procedure here

				   @pDescrip_ID INT,
				   @pDescrip_Text NVARCHAR(MAX)


				AS
				BEGIN
				   -- SET NOCOUNT ON added to prevent extra result sets from
				   -- interfering with SELECT statements.

				   SET NOCOUNT ON;
							--Insert statements for procedure here
					   UPDATE dbo.Tray_Description
					   SET Tray_Description = @pDescrip_Text
					   WHERE Description_ID = @pDescrip_ID
					   END
					   GO
					   /****** Object:  StoredProcedure [dbo].[Update_Unique_Rules]    Script Date: 27-04-2022 11:32:55 ******/
					   SET ANSI_NULLS ON
					   GO
					   SET QUOTED_IDENTIFIER ON
					   GO
					   -- =============================================
					   --Author:		Bilsoe
					   -- Create date: 
				--Description:	
				-- =============================================
					   CREATE PROCEDURE[dbo].[Update_Unique_Rules]
						   -- Add the parameters for the stored procedure here
			   
						   @Maint_ID BIGINT,
						   @Maint_Text NVARCHAR(MAX),
						   @Maint_Value INT,
						   @Maint_Periods INT,
						   @Maint_Period_Start DATETIME
					   AS
			   
						   BEGIN
						   -- SET NOCOUNT ON added to prevent extra result sets from
						   -- interfering with SELECT statements.
			   
							   SET NOCOUNT ON;

							--Insert statements for procedure here
			   
							   UPDATE  Instrument_Special_Rules
			   
							   SET     Maintenance_Text = @Maint_Text,
									   Maintenance_Value = @Maint_Value,
									   Maintenance_Periods = @Maint_Periods,
									   Maintenance_Period_Start = @Maint_Period_Start
			   
							   WHERE   Maintenance_ID = @Maint_ID;

							END;
							GO
							/****** Object:  StoredProcedure [dbo].[Update_User]    Script Date: 27-04-2022 11:32:55 ******/
							SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				--Author:		Bilsoe
				-- Create date: 
				--Description:	
				-- =============================================
				CREATE PROCEDURE[dbo].[Update_User]
					-- Add the parameters for the stored procedure here
					@UserID int,
					@FirstName NVARCHAR(50),
					@FamName NVARCHAR(50),
					@UserName NVARCHAR(50),
					@ChangedBy NVARCHAR(50),
					@SecurityLevel int = 0

				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;


							UPDATE dbo.TblPassword SET
					 UserName = @UserName ,
							  FirstName = @FirstName,
							  FamilyName = @FamName,
							  SecurityLevel = @SecurityLevel,
							  ChangedBy = @ChangedBy ,
							  ChangeDate = GETDATE()

					WHERE UserID = @UserID


					SELECT SecurityLevel FROM dbo.TblPassword WHERE UserName = @username COLLATE Latin1_General_CS_AI
					RETURN @@ROWCOUNT
				END
				GO
				/****** Object:  StoredProcedure [dbo].[Update_User_RFID]    Script Date: 27-04-2022 11:32:55 ******/
				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =============================================
				--Author:		Bilsoe
				-- Create date: 
				--Description:	
				-- =============================================
				CREATE PROCEDURE[dbo].[Update_User_RFID]
					-- Add the parameters for the stored procedure here
					@FirstName NVARCHAR(50),
					@FamName NVARCHAR(50),
					@RFIDCode NVARCHAR(MAX),
					@SEQCode NVARCHAR(MAX),
					@UserName NVARCHAR(50),
					@ChangedBy NVARCHAR(50),
					@SecurityLevel int = 0
				AS
				BEGIN
					-- SET NOCOUNT ON added to prevent extra result sets from
					-- interfering with SELECT statements.
					SET NOCOUNT ON;
							--Insert statements for procedure here
			   


						   UPDATE dbo.TblPassword SET
			   
							UserName = @UserName,
									 FirstName = @FirstName,
									 FamilyName = @FamName,
									 RFID_Code = @RFIDCode,
									 SEQ_Code = @SEQCode,
									 SecurityLevel = @SecurityLevel,
									 ChangedBy = @ChangedBy,
									 ChangeDate = GETDATE()
			   
						   WHERE UserName = @UserName COLLATE Latin1_General_CS_AI
			   

						   SELECT SecurityLevel FROM dbo.TblPassword WHERE UserName = @username COLLATE Latin1_General_CS_AI
			   
						   RETURN @@ROWCOUNT
			   

					   END
			");
        }

        private void DropProcedures()
        {
	        Sql(@"
				/****** Object:  StoredProcedure [dbo].[Update_User_RFID]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Update_User_RFID]
				GO
				/****** Object:  StoredProcedure [dbo].[Update_User]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Update_User]
				GO
				/****** Object:  StoredProcedure [dbo].[Update_Unique_Rules]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Update_Unique_Rules]
				GO
				/****** Object:  StoredProcedure [dbo].[Update_Tray_Description]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Update_Tray_Description]
				GO
				/****** Object:  StoredProcedure [dbo].[TEST]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[TEST]
				GO
				/****** Object:  StoredProcedure [dbo].[Strip_Space_Table]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Strip_Space_Table]
				GO
				/****** Object:  StoredProcedure [dbo].[Strip_Char_Table]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Strip_Char_Table]
				GO
				/****** Object:  StoredProcedure [dbo].[ResetUser]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[ResetUser]
				GO
				/****** Object:  StoredProcedure [dbo].[Main_PassWord]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Main_PassWord]
				GO
				/****** Object:  StoredProcedure [dbo].[LockOut_User]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[LockOut_User]
				GO
				/****** Object:  StoredProcedure [dbo].[Insert_Unique_Rules]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Insert_Unique_Rules]
				GO
				/****** Object:  StoredProcedure [dbo].[Insert_Tray_Description]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Insert_Tray_Description]
				GO
				/****** Object:  StoredProcedure [dbo].[Insert_Tray_Department]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Insert_Tray_Department]
				GO
				/****** Object:  StoredProcedure [dbo].[Insert_RFID_Rules]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Insert_RFID_Rules]
				GO
				/****** Object:  StoredProcedure [dbo].[InportCSVData]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[InportCSVData]
				GO
				/****** Object:  StoredProcedure [dbo].[Get_EPC_Add_One]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Get_EPC_Add_One]
				GO
				/****** Object:  StoredProcedure [dbo].[Find_Max_EPC]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Find_Max_EPC]
				GO
				/****** Object:  StoredProcedure [dbo].[DoLogin]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[DoLogin]
				GO
				/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[DeleteUser]
				GO
				/****** Object:  StoredProcedure [dbo].[Delete_Unique_Rule]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Delete_Unique_Rule]
				GO
				/****** Object:  StoredProcedure [dbo].[Delete_RFID_Rules]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Delete_RFID_Rules]
				GO
				/****** Object:  StoredProcedure [dbo].[CreateUser_RFID]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[CreateUser_RFID]
				GO
				/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[CreateUser]
				GO
				/****** Object:  StoredProcedure [dbo].[Create_New_Rule]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[Create_New_Rule]
				GO
				/****** Object:  StoredProcedure [dbo].[CheckUser]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[CheckUser]
				GO
				/****** Object:  StoredProcedure [dbo].[CheckSecurity]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[CheckSecurity]
				GO
				/****** Object:  StoredProcedure [dbo].[ChangeSecurity]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[ChangeSecurity]
				GO
				/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 22/08/2022 16:36:24 ******/
				DROP PROCEDURE [dbo].[ChangePassword]
				GO
			");
        }
    }
}

