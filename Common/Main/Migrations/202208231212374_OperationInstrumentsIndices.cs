namespace Caretag_Class.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OperationInstrumentsIndices : DbMigration
    {
        public override void Up()
        {
            Sql(
                "CREATE NONCLUSTERED INDEX [NonClusteredIndex-20220823-144124] ON [dbo].[OperationInstruments] ([Id] ASC, [InstrumentId] ASC, [OperationId] ASC ) INCLUDE([InstrumentEPC]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]");
//            CreateIndex("OperationInstruments", new string[] { "OperationId", "InstrumentId" },false, "IX_OperationInstruments");
        }
        
        public override void Down()
        {
            DropIndex("OperationInstruments", "IX_OperationInstruments");
        }
    }
}
