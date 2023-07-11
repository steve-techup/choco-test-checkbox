namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MultiInstrument : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instrument_Description", "RfidUntaggable", c => c.Boolean(nullable: false));
            AddColumn("dbo.Instrument_Description", "ParentDescriptionId", c => c.String(maxLength: 255, nullable: true));
            AlterColumn("dbo.Tray_RFID", "Description_ID", c => c.Long(nullable: false));
            CreateIndex("dbo.Instrument_Description", "ParentDescriptionId");
            CreateIndex("dbo.Tray_RFID", "Description_ID");
            AddForeignKey("dbo.Instrument_Description", "ParentDescriptionId", "dbo.Instrument_Description", "Description_ID");
   //         AddForeignKey("dbo.Tray_RFID", "Description_ID", "dbo.Tray_Description", "Description_ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
     //       DropForeignKey("dbo.Tray_RFID", "Description_ID", "dbo.Tray_Description");
            DropForeignKey("dbo.Instrument_Description", "ParentDescriptionId", "dbo.Instrument_Description");
            DropIndex("dbo.Tray_RFID", new[] { "Description_ID" });
            DropIndex("dbo.Instrument_Description", new[] { "ParentDescriptionId" });
            AlterColumn("dbo.Tray_RFID", "Description_ID", c => c.Int());
            DropColumn("dbo.Instrument_Description", "ParentDescriptionId");
            DropColumn("dbo.Instrument_Description", "RfidUntaggable");
        }
    }
}
