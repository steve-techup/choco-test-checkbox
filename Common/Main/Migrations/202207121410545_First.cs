namespace Caretag_Class.Migrations
{
	using Caretag_Class.Migrations.Base;

	public partial class First : DbMigrationBase
    {
         public override void Up()
         {
	         CreateTables();
	         CreateViews();
	         SeedRoles();
	         SeedData();
         }
         
         public override void Down()
         {
	         DropViews();
	         DropTables();
	         DropProcedures();
         }
         
         private void SeedRoles()
         {
	         Sql(@"
				if not exists(select * from sys.database_principals where name = 'Surgical_Admin')
					CREATE USER [Surgical_Admin] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo];
				GO
				/****** Object:  User [Surgical_User]    Script Date: 27-04-2022 12:00:12 ******/
				if not exists(select * from sys.database_principals where name = 'Surgical_User')
					CREATE USER [Surgical_User] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo];
				GO
				/****** Object:  User [SurgicalControl]    Script Date: 27-04-2022 12:00:12 ******/
				if not exists(select * from sys.database_principals where name = 'SurgicalControl')
					CREATE USER [SurgicalControl] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo];
				GO
				ALTER ROLE [db_owner] ADD MEMBER [Surgical_Admin]
				GO
				ALTER ROLE [db_owner] ADD MEMBER [Surgical_User]
				GO
				ALTER ROLE [db_owner] ADD MEMBER [SurgicalControl]
				GO
			 ");
         }
    }
}
