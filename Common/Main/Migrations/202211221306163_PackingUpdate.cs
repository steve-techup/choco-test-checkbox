namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackingUpdate : DbMigration
    {
        public override void Up()
        {
            AddPrimaryKey("dbo.Cost_Item", "Index_ID");
            AddPrimaryKey("dbo.Cost_Type", "Index_ID");
            AddPrimaryKey("dbo.Cost_Log", "Log_ID");
            AddPrimaryKey("dbo.Tray_RFID", "Tray_ID");

            CreateTable(
                "dbo.PackingLogLines",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PackingLogId = c.Long(nullable: false),
                        InstrumentRfidId = c.Long(nullable: false),
                        InstrumentDescriptionId = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Instrument_Description", t => t.InstrumentDescriptionId)
                .ForeignKey("dbo.Instrument_RFID", t => t.InstrumentRfidId)
                .ForeignKey("dbo.PackingLogs", t => t.PackingLogId)
                .Index(t => t.PackingLogId)
                .Index(t => t.InstrumentRfidId)
                .Index(t => t.InstrumentDescriptionId);
            
            CreateTable(
                "dbo.PackingLogs",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Timestamp = c.DateTime(nullable: false),
                        TrayTypeId = c.Long(nullable: false),
                        TrayRfidId = c.Long(nullable: false),
                        ContainerRfidId = c.Long(),
                        CostLogId = c.Long(),
                        SterilizationIndicatorLotNumber = c.String(),
                        PackedLocked = c.Boolean(nullable: false),
                        TotalInstruments = c.Int(nullable: false),
                        TotalInstrumentTypes = c.Int(nullable: false),
                        PackedByUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Container_RFID", t => t.ContainerRfidId)
                .ForeignKey("dbo.Cost_Log", t => t.CostLogId)
                .ForeignKey("dbo.TblPassword", t => t.PackedByUserId)
                .ForeignKey("dbo.Tray_Description", t => t.TrayTypeId)
                .ForeignKey("dbo.Tray_RFID", t => t.TrayRfidId)
                .Index(t => t.TrayTypeId)
                .Index(t => t.TrayRfidId)
                .Index(t => t.ContainerRfidId)
                .Index(t => t.CostLogId)
                .Index(t => t.PackedByUserId);
            
            
            AddColumn("dbo.Cost_Log", "TrayDescriptionId", c => c.Long());
            AlterColumn("dbo.Cost_Item", "Index_ID", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Cost_Item", "Cost_Type_ID", c => c.Long());
            CreateIndex("dbo.Cost_Item", "Cost_Center");
            CreateIndex("dbo.Cost_Item", "Cost_Type_ID");
            AddForeignKey("dbo.Cost_Item", "Cost_Center", "dbo.Cost_Center", "Index_ID");
            AddForeignKey("dbo.Cost_Item", "Cost_Type_ID", "dbo.Cost_Type", "Index_ID");
            DropColumn("dbo.Cost_Log", "Cost_Center");
            DropColumn("dbo.Cost_Log", "Cost_Item");
            DropColumn("dbo.Cost_Log", "The_Tray_Log_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cost_Log", "The_Tray_Log_ID", c => c.Long());
            AddColumn("dbo.Cost_Log", "Cost_Item", c => c.Long(nullable: false));
            AddColumn("dbo.Cost_Log", "Cost_Center", c => c.Long(nullable: false));
            DropForeignKey("dbo.PackingLogLines", "PackingLogId", "dbo.PackingLogs");
            DropForeignKey("dbo.PackingLogs", "TrayRfidId", "dbo.Tray_RFID");
            DropForeignKey("dbo.PackingLogs", "TrayTypeId", "dbo.Tray_Description");
            DropForeignKey("dbo.PackingLogs", "PackedByUserId", "dbo.TblPassword");
            DropForeignKey("dbo.PackingLogs", "CostLogId", "dbo.Cost_Log");
            DropForeignKey("dbo.PackingLogs", "ContainerRfidId", "dbo.Container_RFID");
            DropForeignKey("dbo.PackingLogLines", "InstrumentRfidId", "dbo.Instrument_RFID");
            DropForeignKey("dbo.PackingLogLines", "InstrumentDescriptionId", "dbo.Instrument_Description");
            DropForeignKey("dbo.Cost_Log", "CostTypeId", "dbo.Cost_Type");
            DropForeignKey("dbo.Cost_Log", "CostCenterId", "dbo.Cost_Center");
            DropForeignKey("dbo.Cost_Item", "Cost_Type_ID", "dbo.Cost_Type");
            DropForeignKey("dbo.Cost_Item", "Cost_Center", "dbo.Cost_Center");
            DropIndex("dbo.PackingLogs", new[] { "PackedByUserId" });
            DropIndex("dbo.PackingLogs", new[] { "CostLogId" });
            DropIndex("dbo.PackingLogs", new[] { "ContainerRfidId" });
            DropIndex("dbo.PackingLogs", new[] { "TrayRfidId" });
            DropIndex("dbo.PackingLogs", new[] { "TrayTypeId" });
            DropIndex("dbo.PackingLogLines", new[] { "InstrumentDescriptionId" });
            DropIndex("dbo.PackingLogLines", new[] { "InstrumentRfidId" });
            DropIndex("dbo.PackingLogLines", new[] { "PackingLogId" });
            DropIndex("dbo.Cost_Log", new[] { "CostTypeId" });
            DropIndex("dbo.Cost_Log", new[] { "CostCenterId" });
            DropIndex("dbo.Cost_Item", new[] { "Cost_Type_ID" });
            DropIndex("dbo.Cost_Item", new[] { "Cost_Center" });
            DropPrimaryKey("dbo.Cost_Item");
            AlterColumn("dbo.Cost_Item", "Cost_Type_ID", c => c.Long());
            AlterColumn("dbo.Cost_Item", "Index_ID", c => c.Long(nullable: false));
            DropColumn("dbo.Cost_Log", "TrayDescriptionId");
            DropColumn("dbo.Cost_Log", "CostTypeId");
            DropColumn("dbo.Cost_Log", "CostCenterId");
            DropTable("dbo.PackingLogs");
            DropTable("dbo.PackingLogLines");
        }
    }
}
