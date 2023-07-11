namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Instrument_RFID", "EPC_Nr", c => c.String(maxLength: 50));
            AddPrimaryKey("dbo.Instrument_RFID", "Instrument_ID", name: "PK_Instrument_RFID");

            AlterColumn("dbo.OperationInstruments", "InstrumentEPC", c => c.String());
            CreateIndex("dbo.OperationInstruments", "InstrumentId", name: "IX_OperationInstruments_InstrumentId");
            AddForeignKey("dbo.OperationInstruments", "InstrumentId", "dbo.Instrument_RFID", "Instrument_ID", name: "FK_OperationInstruments_InstrumentId_Instrument_RFID_Instrument_ID", cascadeDelete: true);

            CreateIndex("dbo.ServiceRequests", "InstrumentId", name: "IX_ServiceRequests_InstrumentId");
            AddForeignKey("dbo.ServiceRequests", "InstrumentId", "dbo.Instrument_RFID", "Instrument_ID", name: "FK_ServiceRequests_InstrumentId_Instrument_RFID_Instrument_ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OperationInstruments", name: "FK_OperationInstruments_InstrumentId_Instrument_RFID_Instrument_ID");
            DropIndex("dbo.OperationInstruments", name: "IX_OperationInstruments_InstrumentId");
            AlterColumn("dbo.OperationInstruments", "InstrumentEPC", c => c.String(nullable: false, maxLength: 50));

            DropForeignKey("dbo.ServiceRequests", name: "FK_ServiceRequests_InstrumentId_Instrument_RFID_Instrument_ID");
            DropIndex("dbo.ServiceRequests", name: "IX_ServiceRequests_InstrumentId");

            AlterColumn("dbo.Instrument_RFID", "EPC_Nr", c => c.String(nullable: false, maxLength: 50));
            DropPrimaryKey("dbo.Instrument_RFID", name: "PK_Instrument_RFID");
        }
    }
}
