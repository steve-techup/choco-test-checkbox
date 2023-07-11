namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PackingPt3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PackingLogLines", "InstrumentRfidId", "dbo.Instrument_RFID");
            DropIndex("dbo.PackingLogLines", new[] { "InstrumentRfidId" });
            AddColumn("dbo.Tray_Packed", "Id", c => c.Long(nullable: false, identity: true));
            AddColumn("dbo.Tray_Packed", "QuantityPackedManually", c => c.Int(nullable: false));
            AddColumn("dbo.PackingLogLines", "PackedManually", c => c.Boolean(nullable: false));
            AddColumn("dbo.PackingLogs", "TotalPackedManually", c => c.Int(nullable: false));
            AlterColumn("dbo.Tray_Packed", "EPC_Nr", c => c.String(maxLength: 50));
            AlterColumn("dbo.PackingLogLines", "InstrumentRfidId", c => c.Long());
            AddPrimaryKey("dbo.Tray_Packed", "Id");
            CreateIndex("dbo.PackingLogLines", "InstrumentRfidId");
            AddForeignKey("dbo.PackingLogLines", "InstrumentRfidId", "dbo.Instrument_RFID", "Instrument_ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PackingLogLines", "InstrumentRfidId", "dbo.Instrument_RFID");
            DropIndex("dbo.PackingLogLines", new[] { "InstrumentRfidId" });
            DropPrimaryKey("dbo.Tray_Packed");
            AlterColumn("dbo.PackingLogLines", "InstrumentRfidId", c => c.Long(nullable: false));
            AlterColumn("dbo.Tray_Packed", "EPC_Nr", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.PackingLogs", "TotalPackedManually");
            DropColumn("dbo.PackingLogLines", "PackedManually");
            DropColumn("dbo.Tray_Packed", "QuantityPackedManually");
            DropColumn("dbo.Tray_Packed", "Id");
            AddPrimaryKey("dbo.Tray_Packed", new[] { "Tray_Description_ID", "EPC_Nr" });
            CreateIndex("dbo.PackingLogLines", "InstrumentRfidId");
            AddForeignKey("dbo.PackingLogLines", "InstrumentRfidId", "dbo.Instrument_RFID", "Instrument_ID", cascadeDelete: true);
        }
    }
}
