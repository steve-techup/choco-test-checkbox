namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidatedPackingListsTrayIdNullable : DbMigration
    {
        public override void Up()
        {
            Sql(@"IF EXISTS((SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_dbo.ValidatedPackingLists_dbo.Tray_Description_TrayId]') AND parent_object_id = OBJECT_ID('ValidatedPackingLists')))
                    ALTER TABLE ValidatedPackingLists DROP CONSTRAINT [FK_dbo.ValidatedPackingLists_dbo.Tray_Description_TrayId];
                GO");
            Sql(@"IF EXISTS((SELECT 1 FROM sys.indexes  WHERE name = 'IX_TrayId' AND object_id = OBJECT_ID('ValidatedPackingLists')))
                    DROP INDEX IX_TrayId ON ValidatedPackingLists;
                GO");
            AlterColumn("dbo.ValidatedPackingLists", "TrayId", c => c.Long());
            Sql(@"UPDATE ValidatedPackingLists SET TrayId = NULL WHERE TrayId = 0;
                 GO");
            CreateIndex("dbo.ValidatedPackingLists", "TrayId");
            AddForeignKey("dbo.ValidatedPackingLists", "TrayId", "dbo.Tray_Description", "Description_ID");
        }
        
        public override void Down()
        {
            Sql(@"IF EXISTS((SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'[FK_dbo.ValidatedPackingLists_dbo.Tray_Description_TrayId]') AND parent_object_id = OBJECT_ID('ValidatedPackingLists')))
                    ALTER TABLE ValidatedPackingLists DROP CONSTRAINT [FK_dbo.ValidatedPackingLists_dbo.Tray_Description_TrayId];
                GO");
            Sql(@"IF EXISTS((SELECT 1 FROM sys.indexes  WHERE name = 'IX_TrayId' AND object_id = OBJECT_ID('ValidatedPackingLists')))
                    DROP INDEX IX_TrayId ON ValidatedPackingLists;
                GO");
            AlterColumn("dbo.ValidatedPackingLists", "TrayId", c => c.Long(nullable: false));
            CreateIndex("dbo.ValidatedPackingLists", "TrayId");
            AddForeignKey("dbo.ValidatedPackingLists", "TrayId", "dbo.Tray_Description", "Description_ID", cascadeDelete: true);
        }
    }
}
