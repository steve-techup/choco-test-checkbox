namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtraInstrumentInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Instrument_RFID", "InstrumentProductionDate", c => c.DateTime());
            AddColumn("dbo.Instrument_RFID", "LotNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Instrument_RFID", "LotNumber");
            DropColumn("dbo.Instrument_RFID", "InstrumentProductionDate");
        }
    }
}
